using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] GameObject screenMenu;
    [SerializeField] GameObject screenCredits;
    [SerializeField] GameObject screenInGame;
    [SerializeField] GameObject screenGameOver;
    [SerializeField] GameObject uiBlur;
    [SerializeField] PlayerController player;
    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip gameplayMusic;
    [SerializeField] AudioClip gameOverMusic;
    [SerializeField] AudioClip previousClip;
    [SerializeField] AudioSource music;
    public bool creditsOn = false;

    void Awake()
    {
        ScreenVisibility(screenMenu, true);
        ScreenVisibility(screenCredits, false);
        ScreenVisibility(screenInGame, false);
        ScreenVisibility(screenGameOver, false);
    }

    void Update()
    {
        if (player.IsGameplayOn())
        {
            GameOverScreen();
            InGameScreen();
            uiBlur.SetActive(!player.isAlive());
            music.clip = player.isAlive() ? gameplayMusic : gameOverMusic;
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

    private void ScreenVisibility(GameObject screen, bool status)
    {
        screen.SetActive(status);
    }

    private void InGameScreen()
    {
        ScreenVisibility(screenInGame, player.isAlive());
    }

    private void GameOverScreen()
    {
        ScreenVisibility(screenGameOver, !player.isAlive());
        if (!player.isAlive())
        {
            uiBlur.SetActive(true);
        }
    }

    private void MainMenuScreen()
    {
        ScreenVisibility(screenMenu, !player.IsGameplayOn() && !creditsOn);
        if (!player.IsGameplayOn() && !creditsOn)
        {
            uiBlur.SetActive(true);
        }
    }

    private void CreditsScreen()
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
