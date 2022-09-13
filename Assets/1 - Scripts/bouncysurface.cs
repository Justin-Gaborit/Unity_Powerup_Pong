using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncysurface : MonoBehaviour
{
    public float _bouncestrength;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ball ball = collision.gameObject.GetComponent<ball>();

        if (ball != null)
        {
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * this._bouncestrength);
        }
    }
}
