using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ChangeTubeMaterial : MonoBehaviour
{
    public Material mat;
    public RenderTexture rTexture;
    public RenderTexture rTexture2;
    public RenderTexture rTexture3;
    [SerializeField, Range(0, 1)] float _bleeding = 0.5f;
    [SerializeField, Range(0, 1)] float _fringing = 0.5f;
    [SerializeField, Range(0, 1)] float _scanline = 0.5f;

    private readonly int _BleedTaps = Shader.PropertyToID("_BleedTaps");
    private readonly int _BleedDelta = Shader.PropertyToID("_BleedDelta");
    private readonly int _FringeDelta = Shader.PropertyToID("_FringeDelta");
    private readonly int _Scanline = Shader.PropertyToID("_Scanline");

    void Update()
    {
        var bleedWidth = 0.04f * _bleeding;  // width of bleeding
        var bleedStep = 2.5f / rTexture.width; // max interval of taps
        var bleedTaps = Mathf.CeilToInt(bleedWidth / bleedStep);
        var bleedDelta = bleedWidth / bleedTaps;
        var fringeWidth = 0.0025f * _fringing; // width of fringing

        mat.SetInt(_BleedTaps, bleedTaps);
        mat.SetFloat(_BleedDelta, bleedDelta);
        mat.SetFloat(_FringeDelta, fringeWidth);
        mat.SetFloat(_Scanline, _scanline);

        Graphics.Blit(rTexture, rTexture2, mat);
        //Graphics.Blit(rTexture, rTexture3, new Vector2(0, 0), new Vector2(0, 0));
        Graphics.Blit(rTexture, rTexture3);
    }
}