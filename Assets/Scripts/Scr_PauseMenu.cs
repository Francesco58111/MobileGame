using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_PauseMenu : MonoBehaviour
{
    public Animator fadeAnim;



    public void Retry()
	{
        StartCoroutine(RetryDelay());
	}

    IEnumerator RetryDelay()
    {
        fadeAnim.Play("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	public void ExitToMainMenu()
	{
        StartCoroutine(ExitDelay());
    }

    IEnumerator ExitDelay()
    {
        fadeAnim.Play("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
