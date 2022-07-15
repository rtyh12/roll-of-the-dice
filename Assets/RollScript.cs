using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollScript : MonoBehaviour
{
    public float time = 0;
    public float rotationTimeScale;

    // Vector3 RandomVector(Vector3 min, Vector3 max)
    // {
    //     return new Vector3(Random.Range(min.x, max.x),
    //                        Random.Range(min.y, max.y),
    //                        Random.Range(min.z, max.z));
    // }

    // Vector3 RandomVector(float min, float max)
    // {
    //     return new Vector3(Random.Range(min, max),
    //                        Random.Range(min, max),
    //                        Random.Range(min, max));
    // }

    Vector3 getRotationAtTime(float t)
    {
        t *= rotationTimeScale;
        return new Vector3(0, t, t);
    }

    void Update()
    {
        time += Time.deltaTime;
        transform.eulerAngles = getRotationAtTime(time);
    }
}
