using UnityEngine;

public class CreditsMenuScreen : MonoBehaviour
{
    //[SerializeField] GameObject MainMenuObject;
    [SerializeField] UiController uiController;

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

    public void Exit()
    {
        uiController.SetCredits();
        //SoundManager.Instance.PlaySound(SoundManager.Instance.button);
        //MainMenuObject.SetActive(true);
        //this.gameObject.SetActive(false);
    }
}
