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

    void OnEnable()
    {
        uint finalScore = scoreValue.GetScore();
        uint highestScore = (uint)PlayerPrefs.GetFloat("HighScore");

        if (finalScore > highestScore)
        {
            highestScore = finalScore;
            PlayerPrefs.SetFloat("HighScore", (float)finalScore);
        }

        score.text = "Score: " + finalScore;
        highScore.text = "HighScore: " + highestScore;
    }

#if UNITY_ANDROID
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMenu();
        }
    }
#endif

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
