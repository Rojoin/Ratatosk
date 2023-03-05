using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreditsList : MonoBehaviour
{
   [SerializeField] TMPro.TMP_Text[] title;
   [SerializeField] TMPro.TMP_Text[] names;
    public float minTitle;
    public float minNames;
    void Start()
    {
        foreach (TMP_Text item in title)
        {
            item.fontSizeMin = minTitle;
        }
        foreach (TMP_Text item in names)
        {
            item.fontSizeMin = minNames;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        foreach (TMP_Text item in title)
        {
            item.fontSizeMin = minTitle;
        }
    }
}
