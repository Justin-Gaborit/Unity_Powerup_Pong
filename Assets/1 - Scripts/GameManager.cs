using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ball ball;
    public int _player1score;
    public int _player2score;

    public void Player1Scores()
    {
        _player1score++;
        this.ball.ResetPosition();
    }

    public void Player2Scores()
    {
        _player2score++;
        this.ball.ResetPosition();
    }
}
