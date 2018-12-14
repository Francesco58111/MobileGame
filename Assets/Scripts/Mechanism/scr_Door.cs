using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Door : MonoBehaviour
{
	public Animator anim;
    public BoxCollider fallingGround;
	public bool open = false;

	private void Awake()
	{
		anim = GetComponentInChildren<Animator>();

        if (fallingGround != null)
            fallingGround.enabled = false;
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
