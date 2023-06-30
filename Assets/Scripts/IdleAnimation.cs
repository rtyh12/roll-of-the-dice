using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimation : MonoBehaviour
{
    public Vector3 amplitude;
    public Vector3 frequency;
    public Vector3 offset;

    private float time;
    private Vector3 originalPosition;

    Vector3 GetPositionOffset(float time)
    {
        return new Vector3(
            Mathf.Sin((time + offset.x) * frequency.x * (2 * Mathf.PI)) * amplitude.x / 10,
            Mathf.Sin((time + offset.y) * frequency.y * (2 * Mathf.PI)) * amplitude.y / 10,
            Mathf.Sin((time + offset.z) * frequency.z * (2 * Mathf.PI)) * amplitude.z / 10
        );
    }

    void Update()
    {
        time += Time.deltaTime;
        transform.position = originalPosition + GetPositionOffset(time);
    }

    void Start()
    {
        time = 0;
        originalPosition = transform.position;
    }
}
