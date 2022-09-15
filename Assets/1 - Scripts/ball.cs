using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float speed = 200.0f;
    public float ball_x;
    public float ball_y;
    public Vector2 ball_vector;

    private Rigidbody2D _rigidbody;

    public GameManager game_manager_script;
    public GameObject game_manager_obj;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        game_manager_obj = GameObject.Find("GameManager");
        game_manager_script = game_manager_obj.GetComponent<GameManager>();
    }

    private void Start()
    {
        ResetPosition();
    }

    public void ResetPosition()
    {
        _rigidbody.position = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;

        AddStartingForce();
    }

    private void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) :
                                        Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        _rigidbody.AddForce(direction * this.speed);
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

    private void OnCollisionEnter2D(Collision2D powerup_speed_collision)
    {
        if (powerup_speed_collision.gameObject.tag == "powerup_speed")
        {
            //float x = _rigidbody.velocity.x;
            //float y = _rigidbody.velocity.y;
            
            

            StartCoroutine(SpeedCountDown());
        }
    }

    IEnumerator SpeedCountDown()
    {
        yield return new WaitForSeconds(5);
        _rigidbody.velocity = _rigidbody.velocity * -1.5f;
        game_manager_script.countdown_start = true;

        StopCoroutine(SpeedCountDown());
    }

}
