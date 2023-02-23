using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class UIScore : MonoBehaviour
{
    private float score;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMesh.text = score.ToString("0");
    }

   public void SetScore(uint currentScore)
    {
        this.score = currentScore;
    }
}
