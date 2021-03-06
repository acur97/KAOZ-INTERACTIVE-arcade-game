﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverJugador : MonoBehaviour {

    //public GameObject proyectil;
    public Transform PuntoDisparo1;
    public Transform PuntoDisparo2;
    public Transform PadreDisparos;
    public float velocidad;
    [Space]
    public Vector2 margenes;
    public float EsperaEntreBalas;

    private Rigidbody rb;
    private Vector3 move;
    private float Hmove;
    private float Vmove;
    private float naveX;
    private float naveY;
    private Quaternion rotacionZero = Quaternion.identity;
    private bool undido;
    public static bool recibeInputs = true;

    private readonly string horizontal = "Horizontal";
    private readonly string vertical = "Vertical";
    private readonly string disparo = "Disparo";

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        move = new Vector3(Hmove, Vmove, 0);
        rb.AddForce(move);

        naveX = transform.localPosition.x;
        naveY = transform.localPosition.y;

        transform.localPosition = new Vector3(Mathf.Clamp(naveX, -margenes.x, margenes.x), Mathf.Clamp(naveY, -margenes.y, margenes.y), 0);

        transform.localEulerAngles = new Vector3(0, -(rb.velocity.x / 2), 0);

        if (recibeInputs)
        {
            Hmove = Input.GetAxis(horizontal) * velocidad;
            Vmove = Input.GetAxis(vertical) * velocidad;

            //if (Input.GetButtonDown(disparo))
            //{
            //    undido = true;
            //    StartCoroutine(Disparar());
            //}
        }

        //if (Input.GetButtonUp(disparo))
        //{
        //    undido = false;
        //    StopAllCoroutines();
        //}
    }

    //IEnumerator Disparar()
    //{
    //    //Instantiate(proyectil, PuntoDisparo1.position, rotacionZero, PadreDisparos);
    //    //Instantiate(proyectil, PuntoDisparo2.position, rotacionZero, PadreDisparos);
    //    PoolActivos.Pool.I_BalaJugador(PuntoDisparo1.position);
    //    PoolActivos.Pool.I_BalaJugador(PuntoDisparo2.position);
    //    yield return new WaitForSeconds(EsperaEntreBalas);
    //    if (undido)
    //    {
    //        yield return new WaitForSeconds(EsperaEntreBalas * 2);
    //        StartCoroutine(Disparar());
    //    }
    //}
}