using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneM : MonoBehaviour
{
    public Vector2 offset;
    public string shaderString = "_DetailAlbedoMap";
    private int shaderID;

    private Vector2 offset2;
    private Material mat;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().sharedMaterial;
        shaderID = Shader.PropertyToID(shaderString);
    }

    private void Update()
    {
        offset2 = new Vector2(Time.time * offset.x, Time.time * offset.y);
        mat.SetTextureOffset(shaderID, offset2);
    }
}