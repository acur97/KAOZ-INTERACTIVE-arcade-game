using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public float velocidad;
    public float puntoMuerte;

    private void Update()
    {
        if (transform.position.z >= puntoMuerte)
        {
            Destroy(gameObject);
        }
        transform.Translate(0, 0, velocidad * Time.unscaledDeltaTime);
    }
}