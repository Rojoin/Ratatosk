using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Slider timerSlider;
   
    public enum Position
    {
        Left,
        Right
    }
     
    private Position pos;
    uint jumpCount;
    public float gameSpeed;
    public float acornValue;
    public float timer;
    private float currentVelocity = 100;
    void Start()
    {
        jumpCount = 0;
        pos = Position.Right;
        timerSlider.maxValue = timer;
        timerSlider.value = timer;
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
        jumpCount++;
    }

    private void LoseTime()
    {
        //multiplicar por gameSpeed
        timer -= Time.deltaTime* gameSpeed;
        if (timer <= 0.0f)
        {
            timer = 0.0f;
        }
    }

    public void AddTime()
    {
        //Hacer escalados de tiempo
        timer += Time.deltaTime* acornValue;
        if (timer > 30.0f)
        {
            timer = 30.0f;
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
}
