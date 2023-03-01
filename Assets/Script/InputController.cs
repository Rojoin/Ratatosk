using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    [SerializeField] PlayerController player;
    // Start is called before the first frame update
    private bool isTouchingLeft = false;
    private bool isTouchingRight = false;
    public TreeGenerator generator;
    void Start()
    {
        isTouchingLeft = false;
        isTouchingRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (player.isAlive())
        {

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (Input.GetTouch(0).phase == TouchPhase.Began)

                {
                    if (touch.position.x < Screen.width / 2)
                    {
                        isTouchingLeft = true;
                        isTouchingRight = false;
                        player.SetPosition(PlayerController.Position.Left);
                        player.ClimbNextBranch();
                        generator.CyclePositions();
                    }
                    else
                    {
                        isTouchingLeft = false;
                        isTouchingRight = true;
                        player.SetPosition(PlayerController.Position.Right);
                        player.ClimbNextBranch();
                        generator.CyclePositions();

                    }
                }
            }
            else
            {
                isTouchingLeft = false;
                isTouchingRight = false;
            }
        }


    }

    public bool IsTouchingLeft()
    {
        return isTouchingLeft;
    }

    public bool IsTouchingRight()
    {
        return isTouchingRight;
    }

}
