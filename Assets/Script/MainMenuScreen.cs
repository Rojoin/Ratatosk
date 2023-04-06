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

#if UNITY_ANDROID
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }
#endif

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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
   	    Application.Quit();
#endif
    }
    
    public void OpenMoreGamesUrl()
    {
        Application.OpenURL("https://imagecampus.itch.io/");
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
