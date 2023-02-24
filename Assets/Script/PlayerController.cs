using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public enum Position
    {
        Left,
        Right,
        Any
    }
    private Position pos;

    public Slider timerSlider;
    public UIScore uiScore;
    uint jumpCount;
    public float gameSpeed;
    public float acornValue;
    public float timer;
    public float maxTimer;
    private float currentVelocity = 100;

    void Start()
    {
        jumpCount = 0;
        pos = Position.Right;
        timerSlider.maxValue = maxTimer;
        timerSlider.value = timer;
        uiScore.SetScore(0);
    }


    void Update()
    {
        ChangePosition();
        LoseTime();
        float currentTimer = Mathf.SmoothDamp(timerSlider.value, timer, ref currentVelocity, 100 * Time.deltaTime);
        timerSlider.value = currentTimer;
    }

    Position GetPosition() => pos;

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


    void ChangePosition()
    {
        switch (pos)
        {
            case Position.Left:
                transform.position = new Vector3(-0.65f, transform.position.y, transform.position.z);
                break;
            case Position.Right:
                transform.position = new Vector3(0.59f, transform.position.y, transform.position.z);
                break;
        }

    }
    uint GetScore() => jumpCount;

    public void ClimbNextBranch()
    {
        AddTime();
        jumpCount++;
        uiScore.SetScore(jumpCount);
    }
    void OnDrawGizmos()
    {
        timerSlider.value = timer;
    }
}
