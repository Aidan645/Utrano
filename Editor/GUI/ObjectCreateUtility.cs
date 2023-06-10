using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public static class ObjectCreateUtility
{
    public static void CreatePrefab(string path)
    {
        GameObject newObject = PrefabUtility.InstantiatePrefab((GameObject)AssetDatabase.LoadAssetAtPath(path, typeof(GameObject))) as GameObject;
        PlaceInScene(newObject);
    }

    public static void CreateObject(string name, params Type[] types)
    {
        GameObject newObject = ObjectFactory.CreateGameObject(name, types);
        PlaceInScene(newObject);
    }
    public static void CreateScriptableObject<T>() where T : ScriptableObject
    {
        UnityEngine.Object newScriptableObject = ScriptableObject.CreateInstance<T>();
        PlaceInAssets<T>(newScriptableObject);
    }
    public static void PlaceInAssets<T>(UnityEngine.Object obj) where T : ScriptableObject
    {
        UnityEngine.Object selectedObject = Selection.activeObject;
        string assetPath = AssetDatabase.GetAssetPath(selectedObject);
        string fileName = $"New{typeof(T).Name}.asset";
        string path = GetUniqueAssetPath(assetPath,fileName);
        AssetDatabase.CreateAsset(obj, path);
        AssetDatabase.SaveAssets();

        // If you want to automatically select the created asset in the Project window:
        AssetDatabase.OpenAsset(obj);
    }
    public static void PlaceInScene(GameObject gameObject)
    {
        // Find location
        SceneView lastView = SceneView.lastActiveSceneView;
        gameObject.transform.position = lastView ? lastView.pivot : Vector3.zero;

        // Make sure we place the object in the proper scene, with a relevant name
        StageUtility.PlaceGameObjectInCurrentStage(gameObject);
        GameObjectUtility.EnsureUniqueNameForSibling(gameObject);

        // Record undo, and select
        Undo.RegisterCreatedObjectUndo(gameObject, $"Create Object: {gameObject.name}");
        Selection.activeGameObject = gameObject;

        // For prefabs, let's mark the scene as dirty for saving
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

    private static string GetUniqueAssetPath(string folderPath, string fileName)
    {
        string assetPath = Path.Combine(folderPath, fileName);

        int counter = 0;
        while (File.Exists(assetPath))
        {
            counter++;
            string modifiedFileName = $"{Path.GetFileNameWithoutExtension(fileName)} ({counter}){Path.GetExtension(fileName)}";
            assetPath = Path.Combine(folderPath, modifiedFileName);
        }

        return assetPath;
    }
}
