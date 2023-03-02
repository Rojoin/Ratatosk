using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    [SerializeField] PlayerController player;
    public TreeGenerator generator;


    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (!player.IsGameplayOn()) return;
        if (!player.isAlive()) return;
        if (Input.touchCount <= 0) return;
        Touch touch = Input.GetTouch(0);
        if (Input.GetTouch(0).phase != TouchPhase.Began) return;
        if (touch.position.x < Screen.width / 2)
        {
            player.SetPosition(PlayerController.Position.Left);
            generator.CyclePositions();
            player.ClimbNextBranch();
        }
        else
        {
            player.SetPosition(PlayerController.Position.Right);
            generator.CyclePositions();
            player.ClimbNextBranch();

        }


    }



}
