using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] GameObject screenGameOver;
    [SerializeField] GameObject screenMenu;
    [SerializeField] GameObject screenCredits;
    [SerializeField] PlayerController player;
    public bool creditsOn = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsGameplayOn())
        {
            GameOverScreen();
        }
        else
        {
            MainMenuScreen();
            CreditsScreen();
        }

    }
    void ScreenVisibility(GameObject screen, bool status)
    {
        screen.SetActive(status);
    }
    void GameOverScreen()
    {
        ScreenVisibility(screenGameOver, !player.isAlive());
    }
    void MainMenuScreen()
    {
        ScreenVisibility(screenMenu, !player.IsGameplayOn() && !creditsOn);
    }
    void CreditsScreen()
    {
        ScreenVisibility(screenCredits, creditsOn);

    }
    public void SetCredits()
    {
        if (creditsOn)
        {
            creditsOn = false;
        }
        else
        {
            creditsOn = true;
        }
    }
}
