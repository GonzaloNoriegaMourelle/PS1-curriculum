using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;


public class IntroPs1 : MonoBehaviour
{
    [SerializeField] AudioSource Audio;

    [SerializeField] AudioClip introps1;

    [SerializeField] MMFeedbacks feedback1;
    [SerializeField] MMFeedbacks feedback2;
    [SerializeField] MMFeedbacks feedback3;

    // Declaración del delegado
    public delegate void _EndAnimDelegate();

    // Declaración de la variable delegada
    public _EndAnimDelegate _endAnim;


    public void EndAnim()
    {      
           if (_endAnim != null){ _endAnim(); }   
    }

    public void TextEffect()
    {
        feedback1?.PlayFeedbacks();
        feedback2?.PlayFeedbacks();
        feedback3?.PlayFeedbacks();
    }

    public void IntroPlay()
    {
        Audio.PlayOneShot(introps1);
    }

 

}
