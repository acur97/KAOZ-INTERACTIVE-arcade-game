using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public Transform Jroot;
    [Space]
    public AudioSource rainInside;
    public AudioSource rainOutside;
    public float test1;
    public float test2;

    private void Update()
    {
        test1 = (Mathf.Clamp(Jroot.position.z, 2.5f, 3.5f)) - 3.5f;
        test2 = (3.5f + test1) - 2.5f;
        test1 = -test1;

        rainInside.volume = test1;
        rainOutside.volume = test2;
    }
}