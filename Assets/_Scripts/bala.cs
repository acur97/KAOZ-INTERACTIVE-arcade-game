using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 velocidad;
    public ForceMode force;

    void OnEnable()
    {
        rb.AddForce(velocidad, force);
    }

    private void Update()
    {
        if (transform.position.z <= -100)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroide"))
        {
            Destroy(gameObject);
        }
    }
}