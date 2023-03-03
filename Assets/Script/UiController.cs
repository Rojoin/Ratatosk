using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] GameObject screenGameOver;
    [SerializeField] GameObject screenMenu;
    // [SerializeField] GameObject screenPause;
    [SerializeField] PlayerController player;
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
        ScreenVisibility(screenMenu, !player.IsGameplayOn());
    }

}