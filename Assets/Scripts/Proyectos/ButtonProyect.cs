using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class ButtonProyect : MonoBehaviour
{
    private Scr_Proyect proyect;
    [SerializeField] Image minature;

    GameObject objetoConTag;
    TextMeshProUGUI actualizeText;
    public void GetProyect(Scr_Proyect proyect)
    {
        this.proyect = proyect;
        minature.sprite = proyect.minature;

    }

    public void OpenCanvasSeeProyect()
    {
        ProjectsController.instance.SeeProyect(proyect);
    }

    public void ShowMiniature()
    {
        minature.gameObject.SetActive(true);
        minature.transform.DOScale(new Vector3(1, 1, 1), 1.2f);
    }
    public void HideMiniature()
    {
        minature.transform.localScale = new Vector3(0, 0, 0);
        minature.gameObject.SetActive(false);
    }


    public void ShowActualizeText()
    {
        if (actualizeText == null)
        {
            objetoConTag = GameObject.FindGameObjectWithTag("ActualizeText");
            actualizeText = objetoConTag.GetComponent<TextMeshProUGUI>();
        }
        actualizeText.text = proyect.IDproyect;
    }
    public void HideActualizeText()
    {
        if (actualizeText == null)
        {
            objetoConTag = GameObject.FindGameObjectWithTag("ActualizeText");
            actualizeText = objetoConTag.GetComponent<TextMeshProUGUI>();
        }
        actualizeText.text = "";
    }


}
