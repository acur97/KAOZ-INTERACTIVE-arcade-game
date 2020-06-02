using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{
    public int puntaje;
    public int record;
    public Text textoPuntaje;
    public Text textoRecord;
  
    void OnEnable()
    {
        puntaje = 0;
        textoPuntaje.text = "Puntaje: " + puntaje.ToString();
        record = PlayerPrefs.GetInt("Record", 0);
        textoRecord.text = "Record: "+record.ToString();
    }

   
    void FixedUpdate()
    {

        textoPuntaje.text = "Puntaje: "+puntaje.ToString();


        if (JugController.Jugando && VidaNave.conVida == true && SpawneadorAsteroides.enJuego == true) {

            puntaje += 1;
        }
        if (VidaNave.conVida == false) {
            if (puntaje > record) {
                record = puntaje;
                PlayerPrefs.SetInt("Record", record);
                textoRecord.text = "Record: " + record.ToString();
            }
        }
    }
}
