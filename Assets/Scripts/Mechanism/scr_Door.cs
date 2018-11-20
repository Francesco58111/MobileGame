using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Door : MonoBehaviour
{
	public Animator anim;
    public GameObject fallingGround;
	public bool open = false;

	private void Awake()
	{
		anim = GetComponentInChildren<Animator>();
 
	}

    private void Start()
    {
        anim.SetBool("Open", open);
    }

    public void Activate()
	{
		open = !open;

        if (fallingGround != null)
            fallingGround.SetActive(false);

        
        anim.SetBool("Open", open);
	}
}
