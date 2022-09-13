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
    public int player1Scorevalue;

    public void Awake()
    {
        player_2_score_text = GameObject.Find("player_2_scoretext").GetComponent<TMP_Text>();
        player1Scorevalue = 0;
        player_2_score_text.text = player1Scorevalue.ToString();
    }

    public void Update()
    {
        player_2_score_text.text = player1Scorevalue.ToString();

        if (player1Scorevalue > 2)
        {
            SceneManager.LoadScene("pong_game_scene");
        }
    }

    private void OnCollisionEnter2D(Collision2D player2scorecollision)
    {
        if (player2scorecollision.gameObject.tag == "Ball")
        {
            player1Scorevalue++;
            this.ball.ResetPosition();
        }
    }
}
