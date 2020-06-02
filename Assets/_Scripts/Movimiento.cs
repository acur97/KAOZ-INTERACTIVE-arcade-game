using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Transform joystick_root;
    private Vector3 initialRot;
    public Transform joyBtn_root;
    private float btn_val = 0;

    public float movementSpeed = 10;

    public Vector2 rangoH = Vector2.zero;
    public Vector2 rangoV = Vector2.zero;

    private Vector3 move;

    private void Start()
    {
        initialRot = joystick_root.localEulerAngles;
    }

    void Update()
    {
        if (JugController.Jugando && VidaNave.conVida)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            bool click = Input.GetMouseButton(0);

            if (click)
            {
                btn_val = 0.005f;
                joyBtn_root.localPosition = new Vector3(0, -btn_val, 0);
            }
            else
            {
                if (btn_val > 0)
                {
                    btn_val -= Time.deltaTime / 25;
                }
                btn_val = Mathf.Clamp(btn_val, 0, 0.005f);
                joyBtn_root.localPosition = new Vector3(0, -btn_val, 0);
            }

            //Movimiento vertical
            move = new Vector3(0, vertical, 0) * Time.deltaTime * movementSpeed;
            transform.Translate(move);

            //Movimiento horizontal
            Vector3 lados = new Vector3(horizontal, 0, 0) * Time.deltaTime * movementSpeed;
            transform.Translate(lados);

            //Limites Pantalla
            transform.localPosition = new Vector3(Mathf.Clamp(transform.position.x, rangoH.x, rangoH.y), Mathf.Clamp(transform.position.y, rangoV.x, rangoV.y), transform.position.z);

            joystick_root.localEulerAngles = new Vector3(initialRot.x + (-vertical * 45), initialRot.y, initialRot.z + (horizontal * 45));
        }
        else
        {
            joystick_root.localEulerAngles = new Vector3(initialRot.x, initialRot.y, initialRot.z);
        }

    }
}
