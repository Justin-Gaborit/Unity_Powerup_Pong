using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuNav : MonoBehaviour
{
    //establish button objects
    public GameObject PlayButton_obj;
    public GameObject TutorialButton_obj;
    public GameObject CreditsButton_obj;

    //establish TMP objects
    public TMP_Text PlayButton_TMP;
    public TMP_Text TutorialButton_TMP;
    public TMP_Text CreditsButton_TMP;

    public int MenuStateVal;

    void Awake()
    {

        //get button objects
        PlayButton_obj = GameObject.Find("playButton");
        TutorialButton_obj = GameObject.Find("tutorialButton");
        CreditsButton_obj = GameObject.Find("creditsButton");

        //Get TMP opbjects
        PlayButton_TMP = PlayButton_obj.GetComponentInChildren<TMP_Text>();
        TutorialButton_TMP = TutorialButton_obj.GetComponentInChildren<TMP_Text>();
        CreditsButton_TMP = CreditsButton_obj.GetComponentInChildren<TMP_Text>();
    }

    void Start()
    {
        MenuStateVal = 1;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            MenuStateVal++;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            MenuStateVal--;
        }

        if (MenuStateVal > 3)
        {
            MenuStateVal = 1;
        }
        else if (MenuStateVal < 1)
        {
            MenuStateVal = 3;
        }

        if (MenuStateVal == 1)
        {
            StartSelected();
        }
        else if (MenuStateVal == 2)
        {
            TutorialSelected();
        }
        else if (MenuStateVal == 3)
        {
            CreditsSelected();
        }

        if (MenuStateVal == 1 && Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("pong_game_scene");
        }
        if (MenuStateVal == 2 && Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("tutorial_scene");
        }
        if (MenuStateVal == 3 && Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("credits_scene");
        }


    }

    void StartSelected()
    {
        PlayButton_TMP.color = new Color32(0, 0, 0, 255);
        TutorialButton_TMP.color = new Color32(255, 255, 255, 255);
        CreditsButton_TMP.color = new Color32(255, 255, 255, 255);

        PlayButton_TMP.outlineColor = new Color32(225, 225, 225, 255);
        TutorialButton_TMP.outlineColor = new Color32(0, 9, 125, 255);
        CreditsButton_TMP.outlineColor = new Color32(0, 9, 125, 255);
    }

    void TutorialSelected()
    {
        PlayButton_TMP.color = new Color32(255, 255, 255, 255);
        TutorialButton_TMP.color = new Color32(0, 0, 0, 255);
        CreditsButton_TMP.color = new Color32(255, 255, 255, 255);

        PlayButton_TMP.outlineColor = new Color32(0, 9, 125, 255);
        TutorialButton_TMP.outlineColor = new Color32(225, 225, 225, 255);
        CreditsButton_TMP.outlineColor = new Color32(0, 9, 125, 255);
    }

    void CreditsSelected()
    {
        PlayButton_TMP.color = new Color32(255, 255, 255, 255);
        TutorialButton_TMP.color = new Color32(255, 255, 255, 255);
        CreditsButton_TMP.color = new Color32(0, 0, 0, 255);

        PlayButton_TMP.outlineColor = new Color32(0, 9, 125, 255);
        TutorialButton_TMP.outlineColor = new Color32(0, 9, 125, 255);
        CreditsButton_TMP.outlineColor = new Color32(225, 225, 225, 255);
    }
}
