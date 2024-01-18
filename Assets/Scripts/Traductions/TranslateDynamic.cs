using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum ConcatentionPos { After,Before}
public class TranslateDynamic : MonoBehaviour
{
    [HideInInspector]
    public  string id;
    private string concatenation = "";

    public CVSType cvsType;
    [HideInInspector]
    public bool translate = false;

    private ConcatentionPos concateniationPos;

    private void OnDisable()
    {
        translate = false;
    }

    public void saveTranslateDynamic(string concatenation, string id, ConcatentionPos concateniationPos)
    {
        translate = true;
        this.concatenation = concatenation;
        this.concateniationPos = concateniationPos;
        this.id = id;

    }

    public void ChangeText(string translateText)
    {
        if (!translate) return;

        TextMeshProUGUI textMeshProUGUIComponent = GetComponent<TextMeshProUGUI>();
        TextMeshPro textMeshProComponent = GetComponent<TextMeshPro>();

        if (textMeshProUGUIComponent != null)
        {
            if (this.concateniationPos == ConcatentionPos.Before)
            {
                textMeshProUGUIComponent.text = concatenation + translateText ;
            }
            else {
                textMeshProUGUIComponent.text =  translateText + concatenation;
            }
           
        }
        else if (textMeshProComponent != null)
        {

            if (this.concateniationPos == ConcatentionPos.Before)
            {
                textMeshProComponent.text = concatenation + translateText;
            }
            else
            {
                textMeshProComponent.text = translateText + concatenation;
            }
        }

    }


}
