using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] TreeGenerator tree;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Retry()
    {
        tree.Reset();
        player.Reset();
        this.gameObject.SetActive(false);
    }
    public void ReturnToMenu()
    {
        player.SetGameState(false);
        this.gameObject.SetActive(false);
    }
    
}
