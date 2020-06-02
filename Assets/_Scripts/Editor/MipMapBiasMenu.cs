using UnityEngine;
using UnityEditor;

class MipMapBiasMenu
{
    static Object[] selection;

    //  Calidad ultra
    [MenuItem("Assets/Seleccionar Mipmap Bias/Calidad Ultra (-1.5)", true)]
    static bool ValidateSetBias0()
    {
        selection = Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
        return (selection.Length > 0);
    }
    [MenuItem("Assets/Seleccionar Mipmap Bias/Calidad Ultra (-1.5)", false, 1011)]
    static void SetBias0()
    {
        foreach (Texture texture in selection)
        {
            string path = AssetDatabase.GetAssetPath(texture);
            (AssetImporter.GetAtPath(path) as TextureImporter).mipMapBias = -1.5F;
            AssetDatabase.ImportAsset(path);
        }
    }

    //  Maxima calidad
    [MenuItem("Assets/Seleccionar Mipmap Bias/Maxima Calidad (-1.0)", true)]
    static bool ValidateSetBias1()
    {
        selection = Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
        return (selection.Length > 0);
    }
    [MenuItem("Assets/Seleccionar Mipmap Bias/Maxima Calidad (-1.0)", false, 1011)]
    static void SetBias1()
    {
        foreach (Texture texture in selection)
        {
            string path = AssetDatabase.GetAssetPath(texture);
            (AssetImporter.GetAtPath(path) as TextureImporter).mipMapBias = -1;
            AssetDatabase.ImportAsset(path);
        }
    }

    //  Alta calidad
    [MenuItem("Assets/Seleccionar Mipmap Bias/Alta Calidad (-0.5)", true)]
    static bool ValidateSetBias2()
    {
        selection = Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
        return (selection.Length > 0);
    }
    [MenuItem("Assets/Seleccionar Mipmap Bias/Alta Calidad (-0.5)", false, 1011)]
    static void SetBias2()
    {
        foreach (Texture texture in selection)
        {
            string path = AssetDatabase.GetAssetPath(texture);
            (AssetImporter.GetAtPath(path) as TextureImporter).mipMapBias = -0.5F;
            AssetDatabase.ImportAsset(path);
        }
    }

    //  Calidad Media
    [MenuItem("Assets/Seleccionar Mipmap Bias/Calidad Media (-0.25)", true)]
    static bool ValidateSetBias3()
    {
        selection = Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
        return (selection.Length > 0);
    }
    [MenuItem("Assets/Seleccionar Mipmap Bias/Calidad Media (-0.25)", false, 1011)]
    static void SetBias3()
    {
        foreach (Texture texture in selection)
        {
            string path = AssetDatabase.GetAssetPath(texture);
            (AssetImporter.GetAtPath(path) as TextureImporter).mipMapBias = -0.25F;
            AssetDatabase.ImportAsset(path);
        }
    }

    //  Calidad normal
    [MenuItem("Assets/Seleccionar Mipmap Bias/Calidad Normal (0.0)", true)]
    static bool ValidateSetBias4()
    {
        selection = Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
        return (selection.Length > 0);
    }
    [MenuItem("Assets/Seleccionar Mipmap Bias/Calidad Normal (0.0)", false, 1011)]
    static void SetBias4()
    {
        foreach (Texture texture in selection)
        {
            string path = AssetDatabase.GetAssetPath(texture);
            (AssetImporter.GetAtPath(path) as TextureImporter).mipMapBias = 0;
            AssetDatabase.ImportAsset(path);
        }
    }

    //  Calidad semi baja
    [MenuItem("Assets/Seleccionar Mipmap Bias/Calidad semi Baja (0.25)", true)]
    static bool ValidateSetBias5()
    {
        selection = Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
        return (selection.Length > 0);
    }
    [MenuItem("Assets/Seleccionar Mipmap Bias/Calidad semi Baja (0.25)", false, 1011)]
    static void SetBias5()
    {
        foreach (Texture texture in selection)
        {
            string path = AssetDatabase.GetAssetPath(texture);
            (AssetImporter.GetAtPath(path) as TextureImporter).mipMapBias = 0.25f;
            AssetDatabase.ImportAsset(path);
        }
    }

    //  Calidad baja
    [MenuItem("Assets/Seleccionar Mipmap Bias/Calidad Baja (0.5)", true)]
    static bool ValidateSetBias6()
    {
        selection = Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
        return (selection.Length > 0);
    }
    [MenuItem("Assets/Seleccionar Mipmap Bias/Calidad Baja (0.5)", false, 1011)]
    static void SetBias6()
    {
        foreach (Texture texture in selection)
        {
            string path = AssetDatabase.GetAssetPath(texture);
            (AssetImporter.GetAtPath(path) as TextureImporter).mipMapBias = 0.5f;
            AssetDatabase.ImportAsset(path);
        }
    }

    //  Calidad bajisima
    [MenuItem("Assets/Seleccionar Mipmap Bias/Mala Calidad (1.0)", true)]
    static bool ValidateSetBias7()
    {
        selection = Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
        return (selection.Length > 0);
    }
    [MenuItem("Assets/Seleccionar Mipmap Bias/Mala Calidad (1.0)", false, 1011)]
    static void SetBias7()
    {
        foreach (Texture texture in selection)
        {
            string path = AssetDatabase.GetAssetPath(texture);
            (AssetImporter.GetAtPath(path) as TextureImporter).mipMapBias = 1;
            AssetDatabase.ImportAsset(path);
        }
    }

    //  Mostrar calidad
    [MenuItem("Assets/Seleccionar Mipmap Bias/Mostrar valor actuar Debug.Log", true)]
    static bool ValidateSetBias8()
    {
        selection = Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
        return (selection.Length > 0);
    }
    [MenuItem("Assets/Seleccionar Mipmap Bias/Mostrar valor actuar Debug.Log", false, 1011)]
    static void SetBias8()
    {
        foreach (Texture texture in selection)
        {
            string path = AssetDatabase.GetAssetPath(texture);
            Debug.Log((AssetImporter.GetAtPath(path) as TextureImporter).mipMapBias);
            //AssetDatabase.ImportAsset(path);
        }
    }

    //  Calidad por defecto
    [MenuItem("Assets/Seleccionar Mipmap Bias/Calidad por defecto Unity (-100 invalid)", true)]
    static bool ValidateSetBias9()
    {
        selection = Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
        return (selection.Length > 0);
    }
    [MenuItem("Assets/Seleccionar Mipmap Bias/Calidad por defecto Unity (-100 invalid)", false, 1011)]
    static void SetBias9()
    {
        foreach (Texture texture in selection)
        {
            string path = AssetDatabase.GetAssetPath(texture);
            (AssetImporter.GetAtPath(path) as TextureImporter).mipMapBias = -100;
            AssetDatabase.ImportAsset(path);
        }
    }
}