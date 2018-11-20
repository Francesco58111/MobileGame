using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class scr_PressurePlate : MonoBehaviour
{
	[SerializeField] private bool triggered = false;
	public UnityEvent activate;
	public Material mt_Red;


	void OnTriggerEnter(Collider other)
	{
		if (triggered)
			return;

		triggered = true;
		GetComponent<Renderer>().sharedMaterial = mt_Red;
		Foo();
	}


	void Foo()
	{
		activate.Invoke();
	}


}
