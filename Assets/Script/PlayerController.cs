using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] TreeGenerator tree;
    public enum Position
    {
        Left,
        Right,
        Any
    }
    [SerializeField] Position pos;

    public Slider timerSlider;
    public UIScore uiScore;
    uint jumpCount;
    public float gameSpeed;
    public float acornValue;
    public float timer;
    public float maxTimer;
    public float normalizeTime = 1.0f;
    private float currentVelocity = 100;
    private bool aliveState = true;
    void Start()
    {
        Reset();
    }


    void Update()
    {
        if (aliveState)
        {
            
        ChangePosition();
        LoseTime();
            //float currentTimer = Mathf.SmoothDamp(timerSlider.value, timer, ref currentVelocity, 100 * Time.deltaTime);
            timerSlider.value = timer;
        }
        else
        {
            Debug.Log("GameOver");
        }
        
    }

    Position GetPosition() => pos;

    public void Reset()
    {
        jumpCount = 0;
        pos = Position.Right;
        timerSlider.maxValue = maxTimer;
        timerSlider.value = timer;
        timer = maxTimer;
        uiScore.SetScore(0);
        aliveState = true;
    }
    public bool isAlive() => aliveState;
    public void SetPosition(Position side)
    {
        pos = side;
    }

    private void LoseTime()
    {
        timer -= Time.deltaTime * gameSpeed;
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
        }
        else
        {
            tree.GetCurrentBranch().SetPlayerOnBranch(true);
            jumpCount++;
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
        timerSlider.value = timer;
    }
}
