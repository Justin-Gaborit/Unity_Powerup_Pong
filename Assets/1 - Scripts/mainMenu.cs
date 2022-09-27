using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Bug maybe caused by scene switch

public class mainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioClip _Select;

    [SerializeField]
    private AudioClip _Back;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (_audioSource == null)
        {
            Debug.LogError("Audio Source is NULL");
        }
    }
    
    public void PlayGame()
    {
        _audioSource.clip = _Select;
        _audioSource.Play();
        SceneManager.LoadScene("pong_game_scene");
    }

    public void Tutorial()
    {
        _audioSource.clip = _Select;
        _audioSource.Play();
        SceneManager.LoadScene("tutorial_scene");
    }

    public void Credits()
    {
        _audioSource.clip = _Select;
        _audioSource.Play();
        SceneManager.LoadScene("credits_scene");
    }

    public void Back()
    {
        _audioSource.clip = _Back;
        _audioSource.Play();
        SceneManager.LoadScene("SampleScene");
    }
}
