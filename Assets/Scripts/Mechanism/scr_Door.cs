using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Door : MonoBehaviour
{
	public Animator anim;
	public bool open = false;

	private void Awake()
	{
        if (anim == null)
            anim = GetComponentInChildren<Animator>();
	}

    private void Start()
    {
        anim.SetBool("Open", open);
    }

    public void Activate()
	{
		open = !open;
        anim.SetBool("Open", open);
	}
}
