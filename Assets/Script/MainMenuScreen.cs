using UnityEngine;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] TreeGenerator tree;
    [SerializeField] GameObject CreditsMenu;

    void Start()
    {
        gameObject.SetActive(false);

    }

    public void Play()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.button);
        tree.Reset();
        player.Reset();
        player.SetFirstTimeState(true);
        player.SetGameState(true);
        CreditsMenu.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void Exit()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.button);
        Application.Quit();
    }

    public void ToggleSFX()
    {
        SoundManager.Instance.ToggleEffects();
    }

    public void ToggleMusic()
    {
        SoundManager.Instance.ToggleMusic();
    }
}
