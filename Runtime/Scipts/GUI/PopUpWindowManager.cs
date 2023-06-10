using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpWindowManager : MonoBehaviour
{
    public Vector2 MinimumSize;
    public PopUpWindowContent Content;
    private TextMeshProUGUI titleText;

    public void ImplementContent(){
        if (!titleText){
            titleText = gameObject.transform.Find("BackGround/Outer/Title/BackGround/Text").GetComponent<TextMeshProUGUI>();
        }
        titleText.text = Content.Title;
    }
}