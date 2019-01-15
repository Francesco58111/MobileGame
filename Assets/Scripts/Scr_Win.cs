using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_Win : MonoBehaviour
{
	public int nextLevelIndex;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag != "Player")
			return;

		SceneManager.LoadScene(nextLevelIndex);
	}

}
