using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawneadorAsteroides : MonoBehaviour
{
    public GameObject prefab;
    public Transform padre;
    [Space]
    public int cantidad = 1;
    public float tiempo = 1;
    [Space]
    public Vector2 limites;

    private void Start()
    {
        InvokeRepeating("Spawnear", 0, tiempo);
    }

    public void Spawnear()
    {
        for (int i = 0; i < cantidad; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-limites.x, limites.x), Random.Range(-limites.y, limites.y));
            Instantiate(prefab, pos, Quaternion.identity, padre);
        }
    }
}