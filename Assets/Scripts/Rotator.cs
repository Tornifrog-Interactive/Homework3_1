using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    [SerializeField] private float Speed;

    [SerializeField] private Transform pivot;
    
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivot.position, Vector3.forward, Time.deltaTime * Speed);
    }
}
