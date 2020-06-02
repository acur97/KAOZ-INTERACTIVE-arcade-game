using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugController : MonoBehaviour
{
    public static bool Jugando = false;
    private bool Ready = false;
    public GameObject Vcam1;
    public GameObject Vcam2;
    public Canvas canvasUIplay;
    public Canvas canvasUIexit;
    public SpawneadorAsteroides spawneador;
    public Transform padreBasura;
    public Puntaje puntos;
    public VidaNave Vnave;
    [Space]
    public Transform cameraFoward;
    [Space]
    public float velocidad;

    private CharacterController cc;
    private Vector3 move;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Vcam2.SetActive(false);
        Vcam1.SetActive(true);
        canvasUIexit.enabled = false;
        canvasUIplay.enabled = false;
        spawneador.enabled = false;
        puntos.enabled = false;
        Vnave.enabled = false;
    }

    void Update()
    {
        if (!Jugando)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            //transform.Translate(horizontal * velocidad * Time.deltaTime, 0, vertical * velocidad * Time.deltaTime, Space.Self);
            move = new Vector3(horizontal * velocidad * Time.deltaTime, 0, vertical * velocidad * Time.deltaTime);
            move = transform.TransformDirection(move);
            cc.Move(move);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Ready && Input.GetMouseButtonDown(0))
        {
            Jugando = true;
            Vcam2.SetActive(true);
            Vcam1.SetActive(false);
            canvasUIexit.enabled = true;
            canvasUIplay.enabled = false;
            spawneador.enabled = true;
            Vnave.enabled = true;
            puntos.enabled = true;
            //Vnave.vida = 100;
            //VidaNave.conVida = true;
            //Vnave.textVida.text = "Vida: 100";
        }
        if (Jugando && Input.GetKeyDown(KeyCode.Space))
        {
            SalirDelArcade();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Salir aplicacion");
            Application.Quit();
        }
    }

    public void SalirDelArcade()
    {
        Jugando = false;
        Vcam2.SetActive(false);
        Vcam1.SetActive(true);
        canvasUIexit.enabled = false;
        canvasUIplay.enabled = true;
        spawneador.enabled = false;
        Vnave.enabled = false;
        puntos.enabled = false;
        Transform[] objetos = padreBasura.GetComponentsInChildren<Transform>();
        for (int i = 1; i < objetos.Length; i++)
        {
            Destroy(objetos[i].gameObject);
        }
        Vnave.vida = 100;
        VidaNave.conVida = true;
        Vnave.textVida.text = "Vida: 100";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arcade1"))
        {
            Ready = true;
            canvasUIplay.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Arcade1"))
        {
            Ready = false;
            canvasUIplay.enabled = false;
        }
    }
}