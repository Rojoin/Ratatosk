using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] TreeGenerator tree;
    [SerializeField] GameObject squirrel;
    public enum Position
    {
        Left,
        Right,
        Any
    }
    [SerializeField] Position pos;
    [SerializeField] AudioClip  acornSound, bushSound;
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
    private bool firstTimeState = false;
    private int jumpsBeforeSpeedUp = 0;
    [SerializeField] int jumpMax = 100;


    void Start()
    {
        defaultGameSpeed = gameSpeed;
    }


    void Update()
    {
        if (!gameplayState) return;
        if (aliveState)
        {

            LoseTime();
            CheckTimePass();
        }
        else
        {
            Debug.Log("GameOver");
        }
            ChangePosition();

    }

    Position GetPosition() => pos;

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
            aliveState = false;
        }
    }

    public void AddTime()
    {
        timer += Time.deltaTime * acornValue;
        if (timer > maxTimer)
        {
            timer = maxTimer;
        }
    }

    private void CheckBranchPosition()
    {
        if (tree.GetCurrentBranch().GetFreePosition() != pos && tree.GetCurrentBranch().GetFreePosition() != Position.Any)
        {
            aliveState = false;
            squirrel.SetActive(false);
            SoundManager.Instance.PlaySound(bushSound);
        }
        else
        {
            tree.GetCurrentBranch().SetPlayerOnBranch(true);
            SoundManager.Instance.PlaySound(acornSound);
            jumpCount++;
            jumpsBeforeSpeedUp++;
        }
    }
    void ChangePosition()
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
    uint GetScore() => jumpCount;

    public void ClimbNextBranch()
    {
        AddTime();
        CheckBranchPosition();
        uiScore.SetScore(jumpCount);
    }
    void OnDrawGizmos()
    {

    }

    public bool IsGameplayOn() => gameplayState;
    public bool IsFirstTime() => firstTimeState;
    public void SetGameState(bool status) => gameplayState = status;
    public void SetFirstTimeState(bool status) => firstTimeState = status;
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
