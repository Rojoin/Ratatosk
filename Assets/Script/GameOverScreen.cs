using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] TreeGenerator tree;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] UIScore scoreValue;

    void Start()
    {
        gameObject.SetActive(false);
    }

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
        SoundManager.Instance.PlaySound(SoundManager.Instance.button);
        tree.Reset();
        player.Reset();
        this.gameObject.SetActive(false);
    }

    public void ReturnToMenu()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.button);
        player.SetGameState(false);
        this.gameObject.SetActive(false);
    }
}
