using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent( typeof (CapsuleCollider))]
public class scr_Lever : MonoBehaviour
{
	private Animator anim;
	public CapsuleCollider trigger;
	public Material mt_yellow;
	public Material mt_Red;

	public UnityEvent activate;
	public bool isActive = false;



	void Start()
	{
		trigger = GetComponent<CapsuleCollider>();
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		anim.SetBool("active", isActive);
	}

	void OnTriggerEnter(Collider other)
	{ 
		if (other.transform.parent.name != "Player")
			return;

		Foo();
	}

	void Foo()
	{
		activate.Invoke();
		isActive = !isActive;
	}
}
