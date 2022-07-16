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
    public float stoppedTime;   // only for debug

    public int currentFace;
    public bool forceFace;
    public int forceFaceNumber;

    private Vector3 translationOffset = new Vector3(0, 0, 0);
    private Vector3 translationOrigin;
    public float yeetDistance;

    public AudioSource audioSource;
    public float rollVolume;

    public State state;

    public StateManager stateManager;

    public List<Vector3> eulerFromFace = new List<Vector3> {
        /* 0 */ new Vector3(0, 0, 0),       // ignore
        /* 1 */ new Vector3(0, -90, 0),
        /* 2 */ new Vector3(0, -180, 0),    
        /* 3 */ new Vector3(180, 0, 90),
        /* 4 */ new Vector3(180, 0, 270),
        /* 5 */ new Vector3(0, 0, 0),
        /* 6 */ new Vector3(0, -270, 0)
    };

    Vector3 getRotationAtTime(float t)
    {
        t *= rotationTimeScale;
        return new Vector3(0, t, t);
    }

    public void GenerateNewFace()
    {
        if (forceFace)
            currentFace = forceFaceNumber;
        else
            currentFace = Random.Range(1, 7);
    }

    public void SwitchToRotating()
    {
        state = State.rotating;
        time = 0;
    }

    public void SwitchToYeet()
    {
        transform.localEulerAngles = eulerFromFace[currentFace];
        state = State.yeet;
        time = 0;
    }

    public void SwitchToStopped()
    {
        stateManager.MessageDiceStopped();
        state = State.stopped;
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (state == State.rotating)
        {
            transform.localEulerAngles = getRotationAtTime(time);
            if (time >= rotatingTime)
                SwitchToYeet();
            audioSource.mute = false;
        }
        else if (state == State.yeet)
        {
            float x = time / yeetTime;
            translationOffset = (-x * x + x) * 4 * yeetDistance * Vector3.up;
            transform.position = translationOrigin + translationOffset;
            if (time >= yeetTime)
                SwitchToStopped();
            audioSource.mute = true;
        }
        else if (state == State.stopped)
        {
            transform.position = translationOrigin;
            if (time >= stoppedTime)
                SwitchToRotating();
            audioSource.mute = true;
        }
    }

    void Start()
    {
        audioSource.mute = true;
        time = 0;
        translationOrigin = transform.position;
    }
}
