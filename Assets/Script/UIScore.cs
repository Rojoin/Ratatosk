using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    private float score;
    private TextMeshProUGUI textMesh;

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void SetScore(uint currentScore)
    {
        this.score = currentScore;

        if (textMesh != null)
            textMesh.text = score.ToString("0");
    }

    public float GetScore() => score;
}
