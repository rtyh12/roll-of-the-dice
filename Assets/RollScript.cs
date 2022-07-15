using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollScript : MonoBehaviour
{
    public float time = 0;
    public float rotationTimeScale;
    public bool rotating = false;

    void StartRotation()
    {
        rotating = true;
        time = 0;
    }

    void StopRotation()
    {

    }

    Vector3 getRotationAtTime(float t)
    {
        t *= rotationTimeScale;
        return new Vector3(0, t, t);
    }

    void Update()
    {
        time += Time.deltaTime;
        
        if (rotating)
        {
            transform.eulerAngles = getRotationAtTime(time);
        }
    }
}
