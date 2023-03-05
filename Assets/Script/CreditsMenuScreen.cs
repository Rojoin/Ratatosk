using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenuScreen : MonoBehaviour
{

   [SerializeField] GameObject MainMenuObject;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void Exit()
    {
        MainMenuObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
