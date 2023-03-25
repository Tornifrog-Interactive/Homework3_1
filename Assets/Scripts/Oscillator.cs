using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private float StartSpeed = 1f;
    [SerializeField] private float SpeedGrowRate = 0.1f;
    [SerializeField] private bool IsGoingRight = true;
    private new Camera _Camera;
    public float movespeed;
    private bool isFirstRound = true;

    // Start is called before the first frame update

    void MoveMyObject()
    {

        float leftEdge = 0.0f;
        float rightEdge = 1.0f;

        if (!IsGoingRight)
        {

            if (_Camera.WorldToViewportPoint(transform.position).x <= leftEdge)
            {
                IsGoingRight = true;
                movespeed = StartSpeed;
                isFirstRound = false;
                return;
            }

            transform.Translate(Vector3.left * movespeed * Time.deltaTime);
        }
        else
        {
            if (_Camera.WorldToViewportPoint(transform.position).x >= rightEdge)
            {
                IsGoingRight = false;
                movespeed = StartSpeed;
                isFirstRound = false;
                return;
            }

            transform.Translate(Vector3.right * movespeed * Time.deltaTime);
        }
    }


    public void IncreaseSpeed()
    {
        if (!isFirstRound)
        {
            if (IsGoingRight)
            {
                movespeed -= SpeedGrowRate * (_Camera.WorldToViewportPoint(transform.position).x - 0.5f);

            }
            else
            {
                movespeed += SpeedGrowRate * (_Camera.WorldToViewportPoint(transform.position).x - 0.5f);

            }
        }
    }

    void Awake()
    {
        _Camera = Camera.main;
        movespeed = StartSpeed;
    }

    void Start()
    {
        InvokeRepeating("IncreaseSpeed", 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveMyObject();
    }
}