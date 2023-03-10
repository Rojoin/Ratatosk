using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    [SerializeField] PlayerController player;
    [SerializeField] AudioClip jumpSound;
    public TreeGenerator tree;
    private float lastMoveTime = 0.0f;
    [SerializeField] Animator animator;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (!player.IsGameplayOn()) return;
        if (!player.isAlive())
        {
            lastMoveTime = 0.0f;
        }
        else
        {
            if (Input.touchCount <= 0) return;
            Touch touch = Input.GetTouch(0);
            if (Input.GetTouch(0).phase != TouchPhase.Began) return;
            if (Time.time - lastMoveTime < tree.branchMoveDuration) return;
            if (player.isHawkActive) return;
            if (touch.position.x < Screen.width / 2)
            {
                player.SetPosition(PlayerController.Position.Left);
                tree.CyclePositions();
                player.ClimbNextBranch();
                
            }
            else
            {
                player.SetPosition(PlayerController.Position.Right);
                tree.CyclePositions();
                player.ClimbNextBranch();

            }
            lastMoveTime = Time.time;
            animator.SetTrigger("Jump");
            SoundManager.Instance.PlaySound(jumpSound);
        }


    }



}
