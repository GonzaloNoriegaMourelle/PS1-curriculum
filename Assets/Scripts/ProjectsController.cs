using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
public class ProjectsController : MonoBehaviour
{
    [Header("Projects")]
    public static ProjectsController instance;
    public bool canSeeDescription = false;
    public List<Scr_Proyect> projects;
    public GameObject gridProjectsFather;


    [Space(10)]
    [Header("See project")]
    public GameObject UIproject;  
    [SerializeField] TextMeshProUGUI descriptionProyectText;
    public ProjectUI projectUI = new ProjectUI();

    [Space(10)]
    [Header("ScreeShot")]
    public GameObject uiScreeShots;
    public int currentScreenShot;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (canSeeDescription)
        {
            //tag "ProyectButton"
            // descriptionProyectText.text
            //logica para un raycast que detecte los botones de los proyectos y muestre suy nonbre
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenProjectsUI();
        }
    }


    public void OpenProjectsUI()
    {
        CloseButtonsProjects();
        StartCoroutine(AnimProjectsUI());
    }

    IEnumerator AnimProjectsUI()
    {
        for (int i = 0; i < projects.Count; i++)
        {
            GameObject button = gridProjectsFather.transform.GetChild(i).transform.GetChild(0).gameObject;
            ButtonProyect buttonsProject = button.GetComponent<ButtonProyect>();
            buttonsProject.GetProyect(projects[i]);
            buttonsProject.ShowMiniature();
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void CloseProjectsUI()
    {
        CloseButtonsProjects();
    }

    #region PROJECTS

    void CloseButtonsProjects()
    {
        for (int i = 0; i < gridProjectsFather.transform.childCount; i++)
        {
            ButtonProyect buttonsProject = gridProjectsFather.transform.GetChild(i).transform.GetChild(0).GetComponent<ButtonProyect>();
            buttonsProject.HideMiniature();

        }
    }

    #endregion


    #region SEEPROJECTS
    public void SeeProyect(Scr_Proyect proyect)
    {


        projectUI.description.text = CVSReader.instance.TranslateOneDynamicText(proyect.IDdescription, CVSType.ShortTraduction);
        projectUI.description.GetComponent<TranslateDynamic>().saveTranslateDynamic("", proyect.IDdescription, ConcatentionPos.After);

        projectUI.leftName.text     = proyect.IDproyect;
        projectUI.rightName.text    = proyect.IDproyect;
        projectUI.background.sprite = proyect.background;
        projectUI.videoPlayer.clip  = proyect.videoClip;

        projectUI.url = proyect.gameLink;

        for (int i = 0; i < projectUI.ScreenShots.Length; i++)
        {
            if (proyect.ScreenShoots.Length > i)
            {
                projectUI.ScreenShots[i].gameObject.SetActive(true);
                projectUI.ScreenShots[i].sprite = proyect.ScreenShoots[i];

            }
            else
            {
                projectUI.ScreenShots[i].gameObject.SetActive(false);
            }
        }
        UIproject.gameObject.SetActive(true);
        Reproductor reproductor = GetComponent<Reproductor>();
        reproductor.ResetReproductorValues();

    }

    public void CloseProyect()
    {
        UIproject.gameObject.SetActive(false);

    }

    public void OpenURL()
    {
        Application.OpenURL(projectUI.url);
    }
    #endregion


    #region SCREENSHOTS


    public void OpenUIScreeShots(int currenScreeShots)
    {
        this.currentScreenShot = currenScreeShots;
        uiScreeShots.gameObject.SetActive(true);
        projectUI.screeShot.sprite = projectUI.ScreenShots[currenScreeShots].sprite;
    }
    public void CloseUIScreeShots()
    {
        uiScreeShots.gameObject.SetActive(false);
        
    }
    public void ChangeScreenShots(int value)
    {
        int nextScreenShot = currentScreenShot + value;

        // Verificar si el siguiente índice está dentro de los límites del array
        if (nextScreenShot >= projectUI.ScreenShots.Length)
        {
            nextScreenShot = 0; // Volver al inicio si se supera el tamaño del array
        }
        else if (nextScreenShot < 0)
        {
            nextScreenShot = projectUI.ScreenShots.Length - 1; // Ir al final si se pasa por debajo del inicio
        }

        // Iterar hasta encontrar la siguiente imagen activa
        while (!projectUI.ScreenShots[nextScreenShot].gameObject.activeSelf)
        {
            nextScreenShot++;

            // Volver al inicio si se supera el tamaño del array
            if (nextScreenShot >= projectUI.ScreenShots.Length)
            {
                nextScreenShot = 0;
            }

            // Salir del bucle si llegamos al índice actual, lo que significa que no hay imágenes activas
            if (nextScreenShot == currentScreenShot)
            {
                break;
            }
        }

        currentScreenShot = nextScreenShot;

        // Mostrar la imagen correspondiente al índice actual
        Debug.Log(currentScreenShot);
        projectUI.screeShot.sprite = projectUI.ScreenShots[currentScreenShot].sprite;

        // Hacer algo con la imagen actual
    }

    #endregion

}
[System.Serializable]
public struct ProjectUI
{
    public TextMeshProUGUI description;
    public TextMeshProUGUI leftName;
    public TextMeshProUGUI rightName;

    public VideoPlayer videoPlayer;
    public string url;
    public Image[] ScreenShots;
    public Image screeShot;

    public Image background;

  
}