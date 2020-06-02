using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawneadorAsteroides : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform padre;
    [Space]
    public int nivel;
    public int puntaje;
    public static bool enJuego;
    public float contTiempo;
    public int tiempoFinalOleada = 10;
    [Space]
    public int cantidad = 1;
    public float tiempo = 1;
    [Space]
    public Vector2 limites;
    public static float velocidadAsteroides;

    private bool finalizadoFull = false;

    [Space]
    public AudioSource musicSource;
    private float musicPitch = 0.98f;

    private void OnEnable()
    {
        enJuego = true;
        velocidadAsteroides = 10;
        nivel = 1;
        tiempo = 1;

        StartCoroutine(DescansoOleada());
    }

    private void OnDisable()
    {
        StopCoroutine(DescansoOleada());
        CancelInvoke("Spawnear");
        musicPitch = 0.98f;
        musicSource.pitch = 1;
        StopAllCoroutines();
        finalizadoFull = false;
    }

    public void Update()
    {
        if (enabled && !VidaNave.conVida && !enJuego && !finalizadoFull)
        {
            StopAllCoroutines();
            Debug.Log("todo frenado");
            finalizadoFull = true;
        }

    }


    public void Spawnear()
    {
        
        if (enJuego == true) { 
            Vector2 pos = new Vector2(Random.Range(-limites.x, limites.x), Random.Range(-limites.y, limites.y));
            //Instantiate(prefab, pos, Quaternion.identity, padre);
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], pos, Quaternion.identity, padre);
        }
    
    }

    IEnumerator DescansoOleada() {

        enJuego = true;
        InvokeRepeating("Spawnear", 0, tiempo);
        musicPitch += 0.02f;
        musicSource.pitch = musicPitch;
        //Debug.Log("Creando Asteroides");
        yield return new WaitForSecondsRealtime(10);
        enJuego = false;
        //Debug.Log("Descansando");
        yield return new WaitForSecondsRealtime(7);
        if (tiempo > 0)
        {
            tiempo -= 0.25f;
            //Debug.Log("Se aumento la cantidad de Asteroides y ahora salen cada: " + tiempo + " segundos");
        }
        else
        {
            velocidadAsteroides += 3;
            //Debug.Log("Se aumentó la velocidad de los asteroides y ahora tienen una velocidad de: "+ velocidadAsteroides);
        }
        
       
        StartCoroutine(DescansoOleada());
    }
}