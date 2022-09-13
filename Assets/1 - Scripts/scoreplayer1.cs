using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class scoreplayer1 : MonoBehaviour
{
    public ball ball;
    public TMP_Text player_1_score_text;
    public int player1Scorevalue;

    public void Awake()
    {
        player_1_score_text = GameObject.Find("player_1_scoretext").GetComponent<TMP_Text>();
        player1Scorevalue = 0;
        player_1_score_text.text = player1Scorevalue.ToString();
    }

    public void Update()
    {
        player_1_score_text.text = player1Scorevalue.ToString();

        if (player1Scorevalue > 2)
        {
            SceneManager.LoadScene("pong_game_scene");
        }
    }

    private void OnCollisionEnter2D(Collision2D player1scorecollision)
    {
        if (player1scorecollision.gameObject.tag == "Ball")
        {
            player1Scorevalue++;
            this.ball.ResetPosition();
        }
    }
}