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
            branches.SetFreePosition(x!= 0 ?Random.Range(0,2):2);
            branches.gameObject.transform.position = branchPlaces[x].position;
            x++;
        }
    }


    void Update()
    {

    }
   public void CyclePositions()
    {
        //fijarse que se va del array
        int x = 0;
        foreach (var branches in branch)
        {
            x++;
            if (x >branch.Length)
            {
                x = 0;
                branches.SetFreePosition(Random.Range(0, 2));
            }
            branches.gameObject.transform.position = branchPlaces[x].position;
        }
    }
}
