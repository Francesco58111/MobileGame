using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_MainMenu : MonoBehaviour
{
	public void LaunchGame()
	{
		SceneManager.LoadScene("Stan_SceneTest");
	}

}
