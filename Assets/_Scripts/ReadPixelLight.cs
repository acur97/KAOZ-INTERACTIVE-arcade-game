﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPixelLight : MonoBehaviour
{
    public RenderTexture rTexture;
    public int posicion = 21333;
    public Color32 valor;
    public float valorSumado = 0;
    public float dividir = 0;
    public float dividirTapa = 0;
    public float ValorFinal = 0;
    public Light[] luz;
    public Light luzTapa;

    private Rect rec;
    private Texture2D tex;
    private float suma = 0;

    private void Awake()
    {
        rec = new Rect(0, 0, rTexture.width, rTexture.height);
        tex = new Texture2D(rTexture.width, rTexture.height, TextureFormat.RGB24, false);
    }

    private Texture2D toTexture2D(RenderTexture rTex)
    {
        Destroy(tex);
        tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
        tex.ReadPixels(rec, 0, 0, false);
        return tex;
    }

    private void LateUpdate()
    {
        var data = toTexture2D(rTexture).GetRawTextureData<Color32>();
        valor = data[posicion];

        suma = 0;
        for (int i = 0; i < data.Length; i++)
        {
            suma += data[i].a;
        }
        valorSumado = suma / data.Length;
        ValorFinal = valorSumado / dividir;
        if (luz.Length != 0)
        {
            for (int i = 0; i < luz.Length; i++)
            {
                luz[i].intensity = ValorFinal;
            }
        }
        if (luzTapa != null)
        {
            luzTapa.intensity = valorSumado / dividirTapa;
        }
    }
}