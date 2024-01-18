using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[CreateAssetMenu(menuName = "NewProyect", order = 2, fileName = "Proyect")]

public class Scr_Proyect : ScriptableObject
{
    public Sprite background;
    public Sprite minature;
    public VideoClip videoClip;
    public Sprite[] ScreenShoots;

    public string IDproyect;
    public string IDdescription;
    public string gameLink;
    public string passwordLink;
}