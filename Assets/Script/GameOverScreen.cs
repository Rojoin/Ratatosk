using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] TreeGenerator tree;
    [SerializeField] TMPro.TextMeshProUGUI score;
    [SerializeField] TMPro.TextMeshProUGUI highScore;
    [SerializeField] UIScore scoreValue;
    private float highiestScore = 0;

    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue.GetScore();
        if (scoreValue.GetScore() > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", scoreValue.GetScore());
        }
        highScore.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore");
    }
    public void Retry()
    {
        tree.Reset();
        player.Reset();
        this.gameObject.SetActive(false);
    }
    public void ReturnToMenu()
    {
        player.SetGameState(false);
        this.gameObject.SetActive(false);
    }

}
