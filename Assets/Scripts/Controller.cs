using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Controller : MonoBehaviour
{
    public IntroPs1 introPs1;
    public GameObject intro;
    public GameObject uiSelector;
    public GameObject uiProyects;
    public GameObject uiCurriculum;

    ProjectsController proyectsController;


    public GameObject uiQuit;
    private void Awake()
    {
        proyectsController = GetComponent<ProjectsController>();
    }

    private void OnEnable()
    {

        introPs1._endAnim += StartMenu;
    }

    private void OnDisable()
    {
        introPs1._endAnim -= StartMenu;
    }

    public void StartMenu()
    {
        intro.gameObject.SetActive(false);
        uiSelector.gameObject.SetActive(true);

    }
    public void ProjectUI(bool value)
    {
        uiProyects.gameObject.SetActive(value);

        if (value)
        {
            proyectsController.OpenProjectsUI();
        }

    }

    public void OpenCurriculumUI(bool value)
    {
        uiCurriculum.gameObject.SetActive(value);
    }


    public void CloseApp()
    {
        Application.Quit();
    }

    public void CanvasQuit(bool value)
    {
        uiQuit.gameObject.SetActive(value);
    }

}
