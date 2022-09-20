using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("pong_game_scene");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("tutorial_scene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("credits_scene");
    }
}
