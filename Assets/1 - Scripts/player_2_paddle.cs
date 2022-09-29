using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_2_paddle : MonoBehaviour
{
    public Vector2 _direction;
    public float speed = 12.5f;
    public Rigidbody2D _rigidbody;
    public AudioSource SFX;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        SFX = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
        }
        else
        {
            _direction = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D ballcontact_paddle_2)
    {
        if (ballcontact_paddle_2.gameObject.tag == "Ball")
        {
            SFX.Play();
        }
    }

    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0)
        {
            _rigidbody.AddForce(_direction * this.speed);
        }
    }
}
