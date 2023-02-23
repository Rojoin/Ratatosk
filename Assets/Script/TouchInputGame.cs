using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TouchInputGame : MonoBehaviour
{
    public string name;
    // Start is called before the first frame update
    private bool activeStatus;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Debug.Log(name);
        activeStatus = true;
        

    }

    private void OnMouseUp()
    {
        activeStatus = false;
    }

  
    public bool isActive() => activeStatus;
    
}
