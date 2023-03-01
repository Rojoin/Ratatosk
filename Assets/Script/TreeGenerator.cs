using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public Branch[] branch;
    public Transform[] branchPlaces;
    void Start()
    {
        int x = 0;
        foreach (var branches in branch)
        {
            branches.id = x;
            branches.SetFreePosition(x != 0 ? Random.Range(0, 2) : 2);
            branches.gameObject.transform.position = branchPlaces[x].position;
            x++;
        }
    }


    void Update()
    {

    }

  public  Branch GetCurrentBranch()
    {
       

        foreach (var branch1 in branch)
        {
            if (branch1.id == 0)
            {
                return branch1;
            }
        }

        return null;
    }
    public void CyclePositions()
    {
        //fijarse que se va del array
        foreach (var branch1 in branch)
        {

            if (branch1.id == 0)
            {
                branch1.SetFreePosition(Random.Range(0, 2));
                branch1.gameObject.transform.position = branchPlaces[branchPlaces.Length-1].position;
                branch1.id = branch.Length-1;
            }
            else
            {
                branch1.gameObject.transform.position = branchPlaces[branch1.id - 1].position;
                branch1.id--;

            }
        }

    }
}
