using UnityEngine;

public class CreditsMenuScreen : MonoBehaviour
{

   [SerializeField] GameObject MainMenuObject;
    void Start()
    {
        gameObject.SetActive(false);
    }

   
    void Update()
    {
        
    }

    public void Exit()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.button);
        MainMenuObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
