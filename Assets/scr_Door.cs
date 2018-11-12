using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Animator))]
public class scr_Door : MonoBehaviour
{
	public Animator anim;
	public bool open = false;

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	public void Activate()
	{
		open = !open;
		anim.SetBool("Open", open);
	}
}
