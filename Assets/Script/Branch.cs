using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    [SerializeField] PlayerController.Position freePosition;

    [SerializeField] Transform Left;
    [SerializeField] Transform Right;
    public GameObject bush;
    public GameObject acorn;
    bool isPlayerOn = false;


    private void Start()
    {

    }
    void Update()
    {
        switch (freePosition)
        {
            case PlayerController.Position.Left:
                acorn.transform.position = Left.position;
                bush.transform.position = Right.position;
                break;
            case PlayerController.Position.Right:
                acorn.transform.position = Right.position;
                bush.transform.position = Left.position;
                break;
            case PlayerController.Position.Any:
                acorn.SetActive(false);
                bush.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void SetFreePosition(int x)
    {
        freePosition = (PlayerController.Position)x;
    }
    public PlayerController.Position GetFreePosition() => freePosition;
    public bool isPlayerOnBranch() => isPlayerOn;
}