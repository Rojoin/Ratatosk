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
                AcornMeshController(true);
                BushMeshController(true);
                break;
            case PlayerController.Position.Right:
                acorn.transform.position = Right.position;
                bush.transform.position = Left.position;
                AcornMeshController(true);
                BushMeshController(true);
                break;
            case PlayerController.Position.Any:
                AcornMeshController(false);
                BushMeshController(false);
                break;
            default:
                break;
        }
    }

    public void AcornMeshController(bool status)
    {
        MeshRenderer[] meshAcorn = acorn.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < meshAcorn.Length; i++)
        {
            meshAcorn[i].enabled = status;
        }


    }

    private void BushMeshController(bool status)
    {
        MeshRenderer[] meshBush = bush.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < meshBush.Length; i++)
        {
            meshBush[i].enabled = status;
        }
    }

    public Transform GetLeftPosition() => Left;
    public Transform GetRightPosition() => Right;
    public void SetFreePosition(int x)
    {
        freePosition = (PlayerController.Position)x;
    }
    public PlayerController.Position GetFreePosition() => freePosition;
    public bool isPlayerOnBranch() => isPlayerOn;
}