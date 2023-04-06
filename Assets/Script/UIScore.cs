using UnityEngine;
using TMPro;

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
    public float GetScore() => score;
}
