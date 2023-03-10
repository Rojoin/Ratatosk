using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] GameObject screenGameOver;
    [SerializeField] GameObject screenMenu;
    [SerializeField] GameObject screenCredits;
    [SerializeField] GameObject screenInGame;
    [SerializeField] GameObject uiBlur;
    [SerializeField] PlayerController player;
    [SerializeField] AudioClip menuMusic, gameplayMusic, gameOverMusic, previousClip;
    [SerializeField] AudioSource music;
    public bool creditsOn = false;
    void Awake()
    {
        ScreenVisibility(screenInGame, false);
        ScreenVisibility(screenMenu, true);
        ScreenVisibility(screenCredits, false);
        ScreenVisibility(screenGameOver, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsGameplayOn())
        {
            GameOverScreen();
            InGameScreen();
            uiBlur.SetActive(!player.isAlive());
            music.clip = player.isAlive() ? gameplayMusic : gameOverMusic;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                player.SetGameState(false);
            }

        }
        else
        {
            MainMenuScreen();
            CreditsScreen();
            uiBlur.SetActive(true);
            music.clip = menuMusic;
        }
        if (previousClip != music.clip)
        {
            music.Play();

        }
        previousClip = music.clip;

    }
    void ScreenVisibility(GameObject screen, bool status)
    {
        screen.SetActive(status);
    }
    void InGameScreen()
    {
        ScreenVisibility(screenInGame, player.isAlive());

    }
    void GameOverScreen()
    {
        ScreenVisibility(screenGameOver, !player.isAlive());
        if (!player.isAlive())
        {
            uiBlur.SetActive(true);
        }
    }
    void MainMenuScreen()
    {
        ScreenVisibility(screenMenu, !player.IsGameplayOn() && !creditsOn);
        if (!player.IsGameplayOn() && !creditsOn)
        {
            uiBlur.SetActive(true);
        }
    }
    void CreditsScreen()
    {
        ScreenVisibility(screenCredits, creditsOn);
        if (creditsOn)
        {
            uiBlur.SetActive(true);
        }
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
        SoundManager.Instance.PlaySound(SoundManager.Instance.button);

    }
}
