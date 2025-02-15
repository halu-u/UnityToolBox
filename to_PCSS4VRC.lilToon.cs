using UnityEngine;
using UnityEditor;

public class ShaderChanger : MonoBehaviour
{
    [MenuItem("Tools/Change All Materials Shader")]
    public static void ChangeAllMaterialsShader()
    {
        Shader targetShader = Shader.Find("PCSS4VRC/PCSS4lilToon/lilToon");
        if (targetShader == null)
        {
            Debug.LogError("Cannot find the shader.");
            return;
        }

        string[] materialGuids = AssetDatabase.FindAssets("t:Material");
        foreach (string guid in materialGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);

            if (mat != null)
            {
                mat.shader = targetShader;
                Debug.Log($"Material '{mat.name}' change to '{targetShader.name}' .");
            }
        }

        AssetDatabase.SaveAssets();
        Debug.Log("Update completed!");
    }
}