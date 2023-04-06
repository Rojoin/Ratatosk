using UnityEngine;

public class TouchInputGame : MonoBehaviour
{
    public string name;
    private bool activeStatus = false;
    
 
    
    private void OnMouseOver()
    {
        activeStatus = Input.GetMouseButtonDown(0) ? true : false;
    }

    public bool isActive() => activeStatus;

}
