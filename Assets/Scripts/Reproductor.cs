using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class Reproductor : MonoBehaviour
{
    public RenderTexture texture;
    public RawImage rawImage;

    public AudioSource videoPlayerAudioSource;
    public VideoPlayer videoPlayer;
    public Slider slider;

    public Image playButton;

    public Sprite pause;
    public Sprite play;

    public Slider volumeSlider;
    public float actualVolume = 0.3f;

    public Image volumeImage;
    public Sprite maxVol;
    public Sprite midVol;
    public Sprite nullVol;

    public bool isPlaying;
    bool isUserInteracting = false;

  

    public void ResetReproductorValues()
    {
        if (slider != null)
        {
            slider.minValue = 0;
            slider.maxValue = (float)videoPlayer.length;
        }

        if (volumeSlider != null)
        {
            volumeSlider.minValue = 0f;
            volumeSlider.maxValue = 1f;
            volumeSlider.value = actualVolume;
            ActualizeImageVolume();
        }
    }

    public void Play()
    {
        if (videoPlayer != null && !videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
    }

    public void Stop()
    {
        if (videoPlayer != null && videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
            playButton.sprite = pause;
            videoPlayer.frame = 0; // Asegurar que el video vuelva al fotograma inicial
        }
    }

    public void TogglePlayPause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            playButton.sprite = play;
        }
        else
        {
            videoPlayer.Play();
            playButton.sprite = pause;
        }
    }
    public void OnVolumeSliderValueChanged()
    {
        if (volumeSlider != null && videoPlayer != null && videoPlayerAudioSource != null)
        {
            videoPlayerAudioSource.volume = volumeSlider.value;

            actualVolume = volumeSlider.value;

            ActualizeImageVolume();

        }
    }

    void ActualizeImageVolume()
    {
        if (actualVolume >= 0.5f)
        {

            volumeImage.sprite = maxVol;
        }
        else if (actualVolume <= 0.5f && actualVolume > 0)
        {
            volumeImage.sprite = midVol;
        }
        else
        {
            volumeImage.sprite = nullVol;
        }
    }

    #region VIDEO TIME

    public void ChangeVideoTime(float newTime)
    {
        if (videoPlayer != null)
        {
            videoPlayer.time = newTime;
        }
    }

    public void OnSliderValueChanged()
    {              
        // Aquí puedes poner cualquier código adicional que necesites
        ChangeVideoTime(slider.value);
       
    }


    public void OnSliderBeginDrag()
    {
        isUserInteracting = true;
    }

    public void OnSliderEndDrag()
    {
        if (!videoPlayer.isPlaying)
        {
            ChangeVideoTime(slider.value);
        }
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
        isUserInteracting = false;
    }
    #endregion 

    private void FixedUpdate()
    {
        if (!isUserInteracting)
        {
            slider.value = (float)videoPlayer.time;
        }

        if (videoPlayer.isPlaying)
        {
            isPlaying = true;
            playButton.sprite = play;
        }
        else
        {
            playButton.sprite = pause;
            isPlaying = false;
        }
    }
  

}
