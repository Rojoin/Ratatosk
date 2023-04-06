using UnityEngine;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] TreeGenerator tree;
    [SerializeField] GameObject CreditsMenu;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

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
