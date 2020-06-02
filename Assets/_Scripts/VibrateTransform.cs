using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateTransform : MonoBehaviour
{
    public Vector3 pos;
    
    void Update()
    {
        transform.localPosition = new Vector3(Random.Range(0, pos.x), Random.Range(0, pos.y), Random.Range(0, pos.z));
    }
}