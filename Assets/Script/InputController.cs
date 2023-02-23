using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private TouchInputGame left;
    private TouchInputGame right;

    [SerializeField] PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        left = gameObject.transform.GetChild(0).GetComponent<TouchInputGame>();
        right = gameObject.transform.GetChild(1).GetComponent<TouchInputGame>();

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (left.isActive())
        {
            player.SetPosition(PlayerController.Position.Left);
            player.ClimbNextBranch();
        }
        else if (right.isActive())
        {
            player.SetPosition(PlayerController.Position.Right);
            player.ClimbNextBranch();
        }


    }
}
