using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ButtonsEffects : MonoBehaviour
{

    public AudioClip onEnterClip;
    public AudioClip onExitClip;
    public AudioClip onClickClip;

    public Transform text; // El objeto que quieres escalar

    public float scaleFactor = 1.2f; // Factor de escala al pasar el ratón
    public float duration = 0.2f; // Duración de la animación de escala

    public void OnEnter()
    {
        if (onEnterClip != null) { AudioSounds.instance.AudioPlayOneShot(onEnterClip, 0.45f); }

        // Escalar el objeto al pasar el ratón sobre él
        text.DOScale(Vector3.one * scaleFactor, duration);
    }

    public void OnExit()
    {
        if (onExitClip != null) { AudioSounds.instance.AudioPlayOneShot(onExitClip, 1); }
        // Desescalar el objeto al retirar el ratón
        text.DOScale(Vector3.one, duration);
    }


    public void OnClick()
    {
        if (onClickClip != null) { AudioSounds.instance.AudioPlayOneShot(onClickClip, 0.45f); }
    }
    private void OnDisable()
    {
        text.transform.localScale = new Vector3(1, 1, 1);
    }

}
