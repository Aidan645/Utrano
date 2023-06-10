using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PopUpWindowManager))]
public class PopUpWindowManagerEditor : Editor
{
    public override void OnInspectorGUI(){
        DrawDefaultInspector();

        PopUpWindowManager puwm = (PopUpWindowManager)target;
        if(GUILayout.Button("Apply Content")) {
            puwm.ImplementContent();
            EditorApplication.QueuePlayerLoopUpdate();
        }
    }
}
