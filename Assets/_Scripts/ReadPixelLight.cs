using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPixelLight : MonoBehaviour
{
    public RenderTexture rTexture;
    //public RenderTexture rTexture3;
    public int posicion = 21333;
    public Color32 valor;
    public float valorSumado = 0;
    public float dividir = 0;
    public float dividirTapa = 0;
    public float ValorFinal = 0;
    public Light luz;
    public Light luzTapa;

    private Rect rec;

    private void Awake()
    {
        rec = new Rect(0, 0, rTexture.width, rTexture.height);
    }

    private Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
        //RenderTexture.active = rTex;
        tex.ReadPixels(rec, 0, 0, false);
        //tex.Apply();
        return tex;
    }

    private void LateUpdate()
    {
        //Graphics.CopyTexture(rTexture, 0, 0, (int)rec.x, (int)rec.y, 1, 1, rTexture3, 0, 0, 0, 0);

        var data = toTexture2D(rTexture).GetRawTextureData<Color32>();
        valor = data[posicion];

        float suma = 0;
        for (int i = 0; i < data.Length; i++)
        {
            suma += data[i].a;
        }
        valorSumado = suma / data.Length;
        ValorFinal = valorSumado / dividir;
        luz.intensity = ValorFinal;
        luzTapa.intensity = valorSumado / dividirTapa;
    }
}