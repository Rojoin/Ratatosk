using System.Collections;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public Branch[] branches;
    public Transform[] branchPlaces;
    [SerializeField] public float branchMoveDuration = 1.0f;
    void Start()
    {
        int x = 0;
        foreach (var branches in branches)
        {
            branches.id = x;
            branches.SetFreePosition((x > 1) ? Random.Range(0, 2) : 2);
            branches.gameObject.transform.position = branchPlaces[x].position;
            x++;
        }
    }


    void Update()
    {

    }
    public void Reset()
    {
        int x = 0;
        foreach (var branch in branches)
        {
            branch.id = x;
            branch.SetFreePosition((x >1) ? Random.Range(0, 2) : 2);
            branch.gameObject.transform.position = branchPlaces[x].position;
            branch.SetPlayerOnBranch(false);
            x++;
        }
    }
    public Branch GetCurrentBranch()
    {


        foreach (var branch1 in branches)
        {
            if (branch1.id == 1)
            {
                return branch1;
            }
        }

        return null;
    }
    public void CyclePositions()
    {

        foreach (var branch in branches)
        {

            if (branch.id == 0)
            {
                branch.SetFreePosition(Random.Range(0, 2));
                branch.id = branches.Length - 1;
                branch.SetPlayerOnBranch(false);
                StartCoroutine(changePosBranch(branch, true));
           
            }
            else
            {
                branch.id--;
                StartCoroutine(changePosBranch(branch, false));


            }
        }

    }
    IEnumerator changePosBranch(Branch branch, bool firstLine)
    {
        bool isMoving = true;
        float timer = 0.0f;
        Vector3 initalPos = branch.transform.position;
        Vector3 finalPos = branchPlaces[branch.id].position;
        while (isMoving)
        {
            if (firstLine)
            {

                branch.gameObject.transform.position = branchPlaces[branchPlaces.Length - 1].position;
                finalPos = branchPlaces[branchPlaces.Length - 1].position;

                timer = branchMoveDuration;
            }
            else
            {
                branch.gameObject.transform.position = Vector3.Lerp(initalPos, finalPos, timer / branchMoveDuration);

            }
            timer += Time.deltaTime;
            isMoving = timer <= branchMoveDuration;
          
            yield return new WaitForEndOfFrame();
        }
        branch.transform.position = finalPos;
    }


}
