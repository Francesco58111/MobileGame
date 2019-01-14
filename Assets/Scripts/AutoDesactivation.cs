using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDesactivation : MonoBehaviour {

	public void Desactivate()
	{
		gameObject.SetActive(false);
	}
}
