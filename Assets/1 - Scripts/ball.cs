using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float speed = 200.0f;
    public float ball_x;
    public float ball_y;
    public Vector2 ball_vector;

    public bool lasthit_player_1;
    public bool lasthit_player_2;

    public GameObject Player1_paddle;
    public GameObject Player2_paddle;

    private Rigidbody2D _rigidbody;

    public GameManager game_manager_script;
    public GameObject game_manager_obj;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        game_manager_obj = GameObject.Find("GameManager");
        game_manager_script = game_manager_obj.GetComponent<GameManager>();
        lasthit_player_1 = false;
        lasthit_player_2 = false;
    }

    private void Start()
    {
        ResetPosition();
    }

    public void ResetPosition()
    {
        _rigidbody.position = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;

        //AddStartingForce();
        StartCoroutine(StartCountDown());
    }

    private void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) :
                                        Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        _rigidbody.AddForce(direction * this.speed * 1.5f);
    }

    public void AddForce(Vector2 force)
    {
        _rigidbody.AddForce(force);
    }

    private void Update()
    {
        ball_x = _rigidbody.velocity.x;
        ball_y = _rigidbody.velocity.y;

        ball_vector = new Vector2(ball_x, ball_y);
    }

    private void OnCollisionEnter2D(Collision2D powerup_paddle_collision)
    {
        if (powerup_paddle_collision.gameObject.tag == "player_1")
        {
            lasthit_player_1 = true;
            lasthit_player_2 = false;
        }

        if (powerup_paddle_collision.gameObject.tag == "player_2")
        {
            lasthit_player_1 = false;
            lasthit_player_2 = true;
        }

        if (powerup_paddle_collision.gameObject.tag == "powerup_size" && lasthit_player_1 == true)
        {
            Player1_paddle.transform.localScale = new Vector3(0.2f, 3f, 0f);
            StartCoroutine(PaddleSizeCountDown_1());
        }

        if (powerup_paddle_collision.gameObject.tag == "powerup_size" && lasthit_player_2 == true)
        {
            Player2_paddle.transform.localScale = new Vector3(0.2f, 3f, 0f);
            StartCoroutine(PaddleSizeCountDown_2());
        }

        if (powerup_paddle_collision.gameObject.tag == "powerup_paddlespeed" && lasthit_player_1 == true)
        {
            Player1_paddle.GetComponent<player_1_paddle>().speed = 25;
            StartCoroutine(PaddleSpeedCountDown_1());
        }

        if (powerup_paddle_collision.gameObject.tag == "powerup_paddlespeed" && lasthit_player_2 == true)
        {
            Player2_paddle.GetComponent<player_2_paddle>().speed = 25;
            StartCoroutine(PaddleSpeedCountDown_2());
        }

        if (powerup_paddle_collision.gameObject.tag == "powerup_shrink" && lasthit_player_1 == true)
        {
            Player2_paddle.transform.localScale = new Vector3(0.2f, 0.7f, 0f);
            StartCoroutine(PaddleShrinkCountDown_2());
        }

        if (powerup_paddle_collision.gameObject.tag == "powerup_shrink" && lasthit_player_2 == true)
        {
            Player1_paddle.transform.localScale = new Vector3(0.2f, 0.7f, 0f);
            StartCoroutine(PaddleShrinkCountDown_1());
        }
    }

#region Powerup 1 Countdown
    IEnumerator PaddleSizeCountDown_1()
    {
        yield return new WaitForSeconds(10);

        Player1_paddle.transform.localScale = new Vector3(0.2f, 1.5f, 0f);
        game_manager_script.countdown_start = true;

        StopCoroutine(PaddleSizeCountDown_1());
    }

    IEnumerator PaddleSizeCountDown_2()
    {
        yield return new WaitForSeconds(10);

        Player2_paddle.transform.localScale = new Vector3(0.2f, 1.5f, 0f);
        game_manager_script.countdown_start = true;

        StopCoroutine(PaddleSizeCountDown_2());
    }
    #endregion

#region Powerup 2 Countdown
    IEnumerator PaddleSpeedCountDown_1()
    {
        yield return new WaitForSeconds(15);

        Player1_paddle.GetComponent<player_1_paddle>().speed = 12.5f;

        StopCoroutine(PaddleSizeCountDown_1());
    }

    IEnumerator PaddleSpeedCountDown_2()
    {
        yield return new WaitForSeconds(15);

        Player1_paddle.GetComponent<player_2_paddle>().speed = 12.5f;

        StopCoroutine(PaddleSizeCountDown_2());
    }
    #endregion

#region Powerup 3 Countdown
    IEnumerator PaddleShrinkCountDown_1()
    {
        yield return new WaitForSeconds(10);

        Player1_paddle.transform.localScale = new Vector3(0.2f, 1.5f, 0f);

        StopCoroutine(PaddleShrinkCountDown_1());
    }

    IEnumerator PaddleShrinkCountDown_2()
    {
        yield return new WaitForSeconds(10);

        Player2_paddle.transform.localScale = new Vector3(0.2f, 1.5f, 0f);

        StopCoroutine(PaddleShrinkCountDown_2());
    }
#endregion

    IEnumerator StartCountDown()
    {
        yield return new WaitForSeconds(3.5f);

        AddStartingForce();

        StopCoroutine(StartCountDown());
    }
}
