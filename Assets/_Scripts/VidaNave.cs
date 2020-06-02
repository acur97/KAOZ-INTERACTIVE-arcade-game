using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaNave : MonoBehaviour
{
    public GameObject particlesVFX;
    public Transform padre;
    public JugController Jcontroller;
    
    public static bool conVida;
    public int vida;
    public int dañoRecibido;
    public Text textVida;

    [Space]
    public GameObject balaPrefab;
    public Transform punto1;
    public Transform punto2;
    public Transform basura;

    void OnEnable()
    {
        conVida = true;
        vida = 100;
        textVida.text = "Vida: " + vida;
    }

    private void Update()
    {
        if (JugController.Jugando && conVida && Input.GetMouseButtonDown(0))
        {
            Instantiate(balaPrefab, punto1.position, Quaternion.identity, basura);
            Instantiate(balaPrefab, punto2.position, Quaternion.identity, basura);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroide" && conVida == true)
        {
            vida -= dañoRecibido;
            textVida.text = "Vida: " + vida;
            //Debug.Log("La vida actual es: " + vida);

            if (vida == 0)
            {
                Debug.Log("Estás Muerto");
                Jcontroller.SalirDelArcade();
                conVida = false;
            }

            Instantiate(particlesVFX, collision.contacts[0].point, Quaternion.identity, padre);
        }
    }
}
