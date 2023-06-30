using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorbiusAnimation : MonoBehaviour
{
    public Material material;
    public float y;
    public float time;
    public float frequency;
    public float amplitude;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        y = Mathf.Sin(time * frequency) * amplitude;
        material.mainTextureScale = new Vector2(material.mainTextureScale.x, y);
    }
}
