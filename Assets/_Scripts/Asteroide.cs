using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public float velocidad;
    public float puntoMuerte;

    private Rigidbody rb;
    private ConstantForce cf;

    private void Awake()
    {
        cf = GetComponent<ConstantForce>();
        rb = GetComponent<Rigidbody>();
        cf.torque = new Vector3(Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f));
    }

    private void Update()
    {
        velocidad = SpawneadorAsteroides.velocidadAsteroides;
        if (transform.position.z >= puntoMuerte)
        {
            Destroy(gameObject);
        }
        //transform.Translate(0, 0, velocidad * Time.deltaTime, Space.World);
        rb.AddForce(0, 0, velocidad * Time.deltaTime, ForceMode.VelocityChange);
    }
}