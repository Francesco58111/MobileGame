using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent( typeof (CapsuleCollider))]
public class scr_Lever : MonoBehaviour
{

	public CapsuleCollider trigger;
	public Material mt_yellow;
	public Material mt_Red;

	public UnityEvent activate;



	// Use this for initialization
	void Start()
	{
		trigger = GetComponent<CapsuleCollider>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter(Collider other)
	{

		if (other.transform.parent.name != "Player")
			return;


		if(GetComponent<Renderer>().sharedMaterial == mt_yellow)
		{
			GetComponent<Renderer>().sharedMaterial = mt_Red;
			Foo();
			return;
		}
		if (GetComponent<Renderer>().sharedMaterial == mt_Red)
		{
			gameObject.GetComponent<Renderer>().sharedMaterial = mt_yellow;
			Foo();
			return;
		}
	}

	void Foo()
	{
		activate.Invoke();
	}
}
