using System;
using UnityEngine;
using UnityEditor;
using static ObjectCreateUtility;

public static class HierarchyMenuEditor
{
    private const int prio = -50;
    [MenuItem("GameObject/Utrano/GUI/Popup", priority = prio)]
    public static void SpawnPopupPrefab(MenuCommand menuCommand){
        CreatePrefab("Packages/com.acinc.utrano/Runtime/Assets/GUI/PopupWindow.prefab");
    }
    [MenuItem("Assets/Create/Utrano/GUI/PopupContent", priority = prio)]
    public static void CreatePopupContent(MenuCommand menuCommand){
        CreateScriptableObject<PopUpWindowContent>();
    }
}
