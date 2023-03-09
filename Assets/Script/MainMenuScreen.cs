using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        tree.Reset();
        player.Reset();
        player.SetFirstTimeState(true);
        player.SetGameState(true);
        CreditsMenu.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void ShowCredits()
    {
        CreditsMenu.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
