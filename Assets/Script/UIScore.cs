using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    private uint score;
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

    public uint GetScore() => score;
}
