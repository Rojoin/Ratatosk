using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    [SerializeField] PlayerController.Position freePosition;

    [SerializeField] Transform Left;
    [SerializeField] Transform Right;
    public int id;
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
                PropsMeshController(true);
                break;
            case PlayerController.Position.Right:
                acorn.transform.position = Right.position;
                bush.transform.position = Left.position;
                PropsMeshController(true);
                break;
            case PlayerController.Position.Any:
                PropsMeshController(false);
                break;
            default:
                break;
        }
    }

    private void PropsMeshController(bool status)
    {
        MeshRenderer[] meshAcorn = acorn.GetComponentsInChildren<MeshRenderer>();
        MeshRenderer[] meshBush = bush.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < meshAcorn.Length; i++)
        {
            meshAcorn[i].enabled = status;
        }

        for (int i = 0; i < meshBush.Length; i++)
        {
            meshBush[i].enabled = status;
        }

    }


    public void SetFreePosition(int x)
    {
        freePosition = (PlayerController.Position)x;
    }
    public PlayerController.Position GetFreePosition() => freePosition;
    public bool isPlayerOnBranch() => isPlayerOn;
}