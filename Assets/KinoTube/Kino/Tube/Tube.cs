// KinoTube - Old TV/video artifacts simulation
// https://github.com/keijiro/KinoTube

using UnityEngine;

namespace Kino
{
    [ExecuteInEditMode]
    public class Tube : MonoBehaviour
    {
        #region Editable attributes

        [SerializeField, Range(0, 1)] float _bleeding = 0.5f;
        [SerializeField, Range(0, 1)] float _fringing = 0.5f;
        [SerializeField, Range(0, 1)] float _scanline = 0.5f;
        [SerializeField] RenderTexture _Rtexture;
        [SerializeField] RenderTexture _Rtexture2;

        #endregion

        #region Private resources

        [SerializeField] Shader _shader;
        Material _material;
        private readonly RenderTexture _rtexture;
        private readonly RenderTexture _rtexture2;
        private readonly int _BleedTaps = Shader.PropertyToID("_BleedTaps");
        private readonly int _BleedDelta = Shader.PropertyToID("_BleedDelta");
        private readonly int _FringeDelta = Shader.PropertyToID("_FringeDelta");
        private readonly int _Scanline = Shader.PropertyToID("_Scanline");

        #endregion

        #region MonoBehaviour methods

        //void OnDestroy()
        //{
        //    if (_material == null)
        //    {
        //        if (Application.isPlaying)
        //            Destroy(_material);
        //        else
        //            DestroyImmediate(_material);
        //    }
        //}

        void Update()
        {
            if (_material == null)
            {
                _material = new Material(_shader)
                {
                    hideFlags = HideFlags.DontSave
                };
            }

            //var bleedWidth = 0.04f * _bleeding;  // width of bleeding
            //var bleedStep = 2.5f / source.width; // max interval of taps
            //var bleedTaps = Mathf.CeilToInt(bleedWidth / bleedStep);
            //var bleedDelta = bleedWidth / bleedTaps;
            //var fringeWidth = 0.0025f * _fringing; // width of fringing

            //_material.SetInt(_BleedTaps, bleedTaps);
            //_material.SetFloat(_BleedDelta, bleedDelta);
            //_material.SetFloat(_FringeDelta, fringeWidth);
            //_material.SetFloat(_Scanline, _scanline);

            //Graphics.Blit(source, dest, _material, 0);

            if (_rtexture != null && _rtexture2 != null)
            {
                var bleedWidth = 0.04f * _bleeding;  // width of bleeding
                var bleedStep = 2.5f / _Rtexture.width; // max interval of taps
                var bleedTaps = Mathf.CeilToInt(bleedWidth / bleedStep);
                var bleedDelta = bleedWidth / bleedTaps;
                var fringeWidth = 0.0025f * _fringing; // width of fringing

                _material.SetInt(_BleedTaps, bleedTaps);
                _material.SetFloat(_BleedDelta, bleedDelta);
                _material.SetFloat(_FringeDelta, fringeWidth);
                _material.SetFloat(_Scanline, _scanline);

                Graphics.Blit(_Rtexture, _Rtexture2, _material, 0);
            }

            Debug.Log("oli");
        }

        #endregion
    }
}
