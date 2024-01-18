using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TranslateText : MonoBehaviour
{
    public CVSType cvsType;
    public string  cvsCode;

    private void OnEnable()
    {
        if (CVSReader.instance == null) { return; }

        TextMeshProUGUI textMeshProUGUIComponent = GetComponent<TextMeshProUGUI>();
        TextMeshPro textMeshProComponent = GetComponent<TextMeshPro>();

        if (textMeshProUGUIComponent != null)
        {
            // El objeto tiene un componente TextMeshProUGUI
            // Haz algo con textMeshProUGUIComponent
            textMeshProUGUIComponent.text = CVSReader.instance.TranslateOneDynamicText(cvsCode, cvsType);
        }
        else if (textMeshProComponent != null)
        {
            // El objeto tiene un componente TextMeshPro
            // Haz algo con textMeshProComponent
            textMeshProComponent.text = CVSReader.instance.TranslateOneDynamicText(cvsCode, cvsType);
        }
      
    }

    public void ChangeText( string translateText)
    {
        TextMeshProUGUI textMeshProUGUIComponent = GetComponent<TextMeshProUGUI>();
        TextMeshPro textMeshProComponent = GetComponent<TextMeshPro>();

        if (textMeshProUGUIComponent != null)
        {
            textMeshProUGUIComponent.text = translateText;
        }
        else if (textMeshProComponent != null)
        {
            textMeshProComponent.text = translateText;
        }
        
    }
}
