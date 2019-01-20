using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class scr_MainMenu : MonoBehaviour
{
	public bool optionMenuShown = false;
	public float optionMenuShownHeight;
	public float optionMenuHidedHeight;

	public RectTransform mainCanvasTransform;
	public RectTransform optionMenuTransform;
	float delay = 0;
	float mainDelay = 0;
	Vector3 destination;
	Vector3 mainCanvasDestination;

    public Animator fadeAnim;

    public AudioMixer mixer;



	private void Start()
	{
		destination = optionMenuTransform.anchoredPosition3D;
		mainCanvasDestination = mainCanvasTransform.anchoredPosition3D; 
	}

	private void Update()
	{
		MoveOptionMenu();
		MoveCanvas();
	}

	private void MoveCanvas()
	{
		mainCanvasTransform.anchoredPosition3D = Vector3.Lerp(mainCanvasTransform.anchoredPosition3D, mainCanvasDestination, mainDelay);
		mainDelay += Time.deltaTime;
	}

	private void MoveOptionMenu()
	{
		optionMenuTransform.anchoredPosition3D = Vector3.Lerp(optionMenuTransform.anchoredPosition3D, destination, delay);
		delay += Time.deltaTime;
	}

	public void LaunchGame(int i)
	{
        StartCoroutine(LaunchingDelay(i));
	}


    /// <summary>
    /// Modifie le Volume de la Music
    /// </summary>
    /// <param name="volume"></param>
    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", volume);
    }

    /// <summary>
    /// Modifie le Volume des SFX
    /// </summary>
    /// <param name="volume"></param>
    public void SetSfxVolume(float volume)
    {
        mixer.SetFloat("SfxVolume", volume);
    }

    /// <summary>
    /// Charge la scene suivante en lancant un fade
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    IEnumerator LaunchingDelay(int i)
    {
        fadeAnim.Play("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(i);
    }

	public void DisplayMainMenu()
	{
		mainCanvasDestination = new Vector3(0,0,100);
		mainDelay = 0;
	}

	public void DisplayLevelselection()
	{
		mainCanvasDestination = new Vector3(-26.5f, 0,100);
		mainDelay = 0;
	}

	public void OptionMenu()
	{
		optionMenuShown = !optionMenuShown;

		if (optionMenuShown)
		{
			destination = new Vector3(optionMenuTransform.anchoredPosition3D.x, optionMenuShownHeight, optionMenuTransform.anchoredPosition3D.z);
			delay = 0;
		}

		if(!optionMenuShown)
		{
			destination = new Vector3(optionMenuTransform.anchoredPosition3D.x, optionMenuHidedHeight, optionMenuTransform.anchoredPosition3D.z);
			delay = 0;
		}	
	}

	public void ExitGame()
	{
		Application.Quit();
	}

}
