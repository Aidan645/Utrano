using System;
using UnityEngine;
using UnityEditor;
using static ObjectCreateUtility;

public static class VROriginMenu
{
    private const int prio = -50;
    [MenuItem("GameObject/Utrano/VR/VROrigin(Meta)", priority = prio)]
    public static void SpawnPopupPrefab(MenuCommand menuCommand)
    {
        CreatePrefab("Packages/com.acinc.utrano/Runtime/Assets/VR/XR Origin (Meta).Prefab");
    }
}