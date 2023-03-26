using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartbeat : MonoBehaviour
{
    [SerializeField] private float scaleSpeed;
    [SerializeField] private float minScale;
    [SerializeField] private float maxScale;

    void Update()
    {
        float scale = Mathf.PingPong(Time.time * scaleSpeed, maxScale - minScale) + minScale;
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
