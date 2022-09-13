using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoringzone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D scorecollision)
    {
        if (scorecollision.gameObject.tag == "Ball")
        { 
            
        }
    }
}
