using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class scoreplayer2 : MonoBehaviour
{
    public ball ball;
    public TMP_Text player_2_score_text;
    public int player2Scorevalue;

    public void Awake()
    {
        player_2_score_text = GameObject.Find("player_2_scoretext").GetComponent<TMP_Text>();
        player2Scorevalue = 0;
        player_2_score_text.text = player2Scorevalue.ToString();
    }

    public void Update()
    {
        player_2_score_text.text = player2Scorevalue.ToString();

        if (player2Scorevalue > 2)
        {
            SceneManager.LoadScene("player_2_win_scene");
        }
    }

    private void OnCollisionEnter2D(Collision2D player2scorecollision)
    {
        if (player2scorecollision.gameObject.tag == "Ball")
        {
            player2Scorevalue++;
            this.ball.ResetPosition();
        }
    }
}
