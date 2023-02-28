using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    private PlayerController.Position freePosition;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void SetFreePosition(int x)
    {
        freePosition = (PlayerController.Position)x;
    }
    PlayerController.Position GetFreePosition() => freePosition;
}
