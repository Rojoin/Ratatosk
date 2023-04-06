using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] TreeGenerator tree;
    [SerializeField] GameObject squirrel;
    [SerializeField] Animator hawk;

    public enum Position
    {
        Left,
        Right,
        Any
    }

    [SerializeField] Position pos;
    [SerializeField] AudioClip[] acornSounds;
    [SerializeField] AudioClip[] bushSounds;
    [SerializeField] AudioClip hawkSound;

    public Image sliderImage;
    public UIScore uiScore;
    uint jumpCount;
    public float gameSpeed;
    private float defaultGameSpeed = 0;
    private float totalTime = 0.0f;
    public float timeToSpeedUp = 10.0f;
    public float gameSpeedModifier = 1.0f;
    public float speedValue = 0.25f;
    public float acornValue;
    public float timer;
    public float maxTimer;
    public float normalizeTime = 1.0f;
    private bool aliveState = true;
    private bool gameplayState = false;
    public bool isHawkActive = false;
    private int jumpsBeforeSpeedUp = 0;
    [SerializeField] int jumpMax = 100;

    void Start()
    {
        defaultGameSpeed = gameSpeed;
    }

    void Update()
    {
        if (!gameplayState)
            return;

        if (aliveState)
        {
            LoseTime();
            CheckTimePass();
        }

        ChangePosition();
    }

    public void Reset()
    {
        jumpCount = 0;
        pos = Position.Right;
        squirrel.SetActive(true);
        timer = maxTimer;
        uiScore.SetScore(0);
        aliveState = true;
        gameSpeedModifier = 1.0f;
        totalTime = 0.0f;
        normalizeTime = 1.0f;
        sliderImage.fillAmount = 1.0f;
        gameSpeed = defaultGameSpeed;
        jumpCount = 0;
        isHawkActive = false;
    }

    public bool isAlive() => aliveState;

    public void SetPosition(Position side)
    {
        pos = side;
    }

    private void LoseTime()
    {
        timer -= Time.deltaTime * gameSpeed * gameSpeedModifier;
        if (timer <= 0.0f)
        {
            timer = 0.0f;
            if (!isHawkActive)
            {
                StartCoroutine(HawkAppears());
            }
        }
    }

    private void AddTime()
    {
        timer += Time.deltaTime * acornValue;
        if (timer > maxTimer)
        {
            timer = maxTimer;
        }
    }

    private IEnumerator HawkAppears()
    {
        bool isHawkMoving = true;
        isHawkActive = true;
        float timer = 0.0f;
        SoundManager.Instance.PlaySound(hawkSound);
        hawk.SetTrigger("GameOver");
        while (isHawkMoving)
        {
            timer += Time.deltaTime;
            if (timer >= 0.15f)
            {
                squirrel.SetActive(false);
            }
            isHawkMoving = timer <= 0.50f;
            yield return new WaitForEndOfFrame();
        }
        aliveState = false;
        hawk.SetTrigger("Base");
    }

    private void CheckBranchPosition()
    {
        if (tree.GetCurrentBranch().GetFreePosition() != pos && tree.GetCurrentBranch().GetFreePosition() != Position.Any)
        {
            aliveState = false;
            squirrel.SetActive(false);
            SoundManager.Instance.PlaySound(bushSounds[Random.Range(0, bushSounds.Length)]);
        }
        else
        {
            tree.GetCurrentBranch().SetPlayerOnBranch(true);
            SoundManager.Instance.PlaySound(acornSounds[Random.Range(0,acornSounds.Length)]);
            jumpCount++;
            jumpsBeforeSpeedUp++;
        }
    }

    private void ChangePosition()
    {
        switch (pos)
        {
            case Position.Left:
                transform.position = tree.GetCurrentBranch().GetLeftPosition().position;
                break;
            case Position.Right:
                transform.position = tree.GetCurrentBranch().GetRightPosition().position;
                break;
        }
    }

    public void ClimbNextBranch()
    {
        AddTime();
        CheckBranchPosition();
        uiScore.SetScore(jumpCount);
    }

    public bool IsGameplayOn() => gameplayState;

    public void SetGameState(bool status) => gameplayState = status;

    private void CheckTimePass()
    {
        totalTime += Time.deltaTime;
        if (totalTime >= timeToSpeedUp)
        {
            gameSpeedModifier += speedValue;
            totalTime = 0.0f;
        }
        normalizeTime = timer / maxTimer;
        sliderImage.fillAmount = normalizeTime;
        if (jumpsBeforeSpeedUp == jumpMax)
        {
            jumpsBeforeSpeedUp = 0;
            gameSpeed += speedValue / 2;
        }
    }
}
