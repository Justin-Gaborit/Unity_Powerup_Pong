using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup_block : MonoBehaviour
{
    //public GameManager game_manager_script;
    //public GameObject game_manager_obj;

    private void Awake()
    {
        //game_manager_obj = GameObject.Find("GameManager");
        //game_manager_script = game_manager_obj.GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D powerup_collision)
    {
        if (powerup_collision.gameObject.tag == "Ball")
        {
            Destroy(gameObject);
        }
    }
}
