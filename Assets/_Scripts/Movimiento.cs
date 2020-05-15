using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float movementSpeed = 10;

    public Vector2 rangoH = Vector2.zero;
    public Vector2 rangoV = Vector2.zero;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Movimiento
        Vector3 movement = new Vector3(0, vertical, 0)* Time.unscaledDeltaTime * movementSpeed;
        transform.Translate(movement);
        
        Vector3 lados = new Vector3(horizontal, 0, 0) * Time.unscaledDeltaTime * movementSpeed;
        transform.Translate(lados);

        //Limites Pantalla
        transform.localPosition = new Vector3(Mathf.Clamp(transform.position.x, rangoH.x, rangoH.y), Mathf.Clamp(transform.position.y, rangoV.x, rangoV.y), transform.position.z);
      
    }
}
