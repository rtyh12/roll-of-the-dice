using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    rotating,
    yeet,
    stopped
};

public class RollScript : MonoBehaviour
{
    public float time = 0;
    public float rotationTimeScale;

    public float rotatingTime;
    public float yeetTime;
    public float stoppedTime;   // will be removed

    public int currentFace;

    private Vector3 translationOffset = new Vector3(0, 0, 0);
    private Vector3 translationOrigin;
    public float yeetDistance;

    public State state;

    public List<Vector3> lookVecFromFace = new List<Vector3> {
        Vector3.zero,       // ignore
        Vector3.up,         // 1
        Vector3.down,       // 2
        Vector3.left,       // 3
        Vector3.right,      // 4
        Vector3.forward,    // 5
        Vector3.back        // 6
    };

    Vector3 getRotationAtTime(float t)
    {
        t *= rotationTimeScale;
        return new Vector3(0, t, t);
    }

    public void SwitchToRotating()
    {
        state = State.rotating;
        time = 0;
    }

    public void SwitchToYeet()
    {
        currentFace = Random.Range(1, 7);
        var rotation = Quaternion.LookRotation(lookVecFromFace[currentFace]);
        transform.rotation = rotation;
        state = State.yeet;
        time = 0;
    }

    public void SwitchToStopped()
    {
        state = State.stopped;
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (state == State.rotating)
        {
            transform.eulerAngles = getRotationAtTime(time);
            if (time >= rotatingTime)
                SwitchToYeet();
        }
        else if (state == State.yeet)
        {
            float x = time / yeetTime;
            translationOffset = (-x * x + x) * 4 * yeetDistance * Vector3.up;
            transform.position = translationOrigin + translationOffset;
            if (time >= yeetTime)
                SwitchToStopped();
        }
        else if (state == State.stopped)
        {
            transform.position = translationOrigin;
            if (time >= stoppedTime)
                SwitchToRotating();
        }
    }

    void Start()
    {
        time = 0;
        state = State.rotating;
        translationOrigin = transform.position;
    }
}
