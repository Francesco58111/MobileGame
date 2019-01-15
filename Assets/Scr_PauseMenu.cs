using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_PauseMenu : MonoBehaviour
{
	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ExitToMainMenu()
	{
		SceneManager.LoadScene(0);
	}

}
