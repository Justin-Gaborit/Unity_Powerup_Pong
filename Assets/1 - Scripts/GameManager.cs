using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool countdown_start;
    private bool powerup_countdown_completed;
    public int spawn_value;
    public int powerup_value;
    public Transform[] powerup_spawner;
    public GameObject[] powerup_obj;

    public void Awake()
    {
        countdown_start = true;
        powerup_countdown_completed = false;
    }

    public void Update()
    {
        if (countdown_start == true)
        {
            StartCoroutine(PowerupCountDown());
        }
    }

    IEnumerator PowerupCountDown()
    {
        countdown_start = false;
        yield return new WaitForSeconds(5);
        spawn_value = Random.Range(0, powerup_spawner.Length);
        powerup_value = Random.Range(0, powerup_obj.Length);
        Instantiate(powerup_obj[powerup_value], powerup_spawner[spawn_value].transform.position, Quaternion.identity);
       
    }
}
