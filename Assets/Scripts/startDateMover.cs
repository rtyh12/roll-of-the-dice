using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDateMover : MonoBehaviour
{
    public float speed = 4f;

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
    }
}
