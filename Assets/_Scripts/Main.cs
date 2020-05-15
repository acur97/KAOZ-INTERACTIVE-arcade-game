using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public Transform mira;

    private int puntos;
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        RaycastHit hit;
        if (Physics.Raycast(mira.position, mira.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider)
            {
                Destroy(hit.collider.gameObject);
                puntos = puntos + 100;
                Debug.Log("Tengo " + puntos);
            }
        }
    }
}
