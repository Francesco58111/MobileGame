using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    //Transition music avec les Fades entre chaque scene
    public AnimationCurve fadeInCurve;
    public AnimationCurve fadeOutCurve;

    public AudioMixer mixer;

    public AnimationClip fadeIN;
    public AnimationClip fadeOUT;

    public float masterVolume;
    public float timing;
    public float currentTime = 0f;

    public bool isFaded = false;
    public bool canCountTime = true;

    //Transition des musiques
    public AudioSource musicCool;
    public AnimationCurve coolCurve;
    public AudioSource musicBad;
    public AnimationCurve badCurve;
    private float coolVolume = 1;
    private float badVolume = 0;

    public bool inTransition = false;



    private void Update()
    {
        mixer.SetFloat("MasterVolume", masterVolume);
        //musicCool.volume = coolVolume;
        //musicBad.volume = badVolume;
        
        if (isFaded && canCountTime)
        {
            FadeOut();
        }

        if (!isFaded && canCountTime)
        {
            FadeIn();
        }

        /*
        if (inTransition)
        {
            TransitionTo();
        }
        */
        
    }

    public void LaunchFade()
    {
        canCountTime = true;
    }


    void FadeIn()
    {
        currentTime += Time.deltaTime;

        float timepercent = currentTime / fadeIN.length;

        if (currentTime >= fadeIN.length)
        {
            currentTime = 0;
            canCountTime = false;
            isFaded = true;
        }

        masterVolume = fadeInCurve.Evaluate(timepercent);
    }


    void FadeOut()
    {
        currentTime += Time.deltaTime;
        

        float timepercent = currentTime / fadeOUT.length;

        if (currentTime >= fadeOUT.length)
        {
            currentTime = 0;
            canCountTime = false;
            isFaded = false;
        }

        masterVolume = fadeOutCurve.Evaluate(timepercent);
    }

/*
    public void MusicTransition()
    {
        musicBad.Play();
        inTransition = true;
    }


    void TransitionTo()
    {
        currentTime += Time.deltaTime;

        float timepercent = currentTime / timing;

        if (currentTime >= timing)
        {
            currentTime = 0;
            inTransition = false;
        }

        badVolume = badCurve.Evaluate(timepercent);
        coolVolume = coolCurve.Evaluate(timepercent);
    }
    */
}
