using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Position
    {
        Left,
        Right
    }

    private Position pos;
    uint jumpCount;
    float timer;
    float addTime;
    void Start()
    {
        jumpCount = 0;
        pos = Position.Right;
    }

    // Update is called once per frame
    void Update()
    {
        ChangePosition();
    }

    Position GetPosition() => pos;

    public void SetPosition(Position side)
    {
        pos = side;
        jumpCount++;
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
