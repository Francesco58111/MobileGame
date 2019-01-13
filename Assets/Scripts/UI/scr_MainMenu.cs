using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
		SceneManager.LoadScene(i);
	}

	public void DisplayMainMenu()
	{
		mainCanvasDestination = new Vector3(0,0,100);
		mainDelay = 0;
	}

	public void DisplayLevelselection()
	{
		mainCanvasDestination = new Vector3(-45, 0,100);
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
