using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class scr_PressurePlate : MonoBehaviour
{
	[SerializeField] private bool triggered = false;
	public UnityEvent activate;
    public Animator anim;


    private void Awake()
    {
        if (anim == null)
            anim = GetComponentInParent<Animator>();
    }


    void OnTriggerEnter(Collider other)
	{
		if (triggered)
			return;

        if (other.transform.parent.gameObject.tag == "Player")
        {
            triggered = true;
            anim.SetTrigger("Activate");
            Foo();
			other.transform.parent.GetComponent<scr_Move>().LaunchClicAnim();
		}
		
	}


	void Foo()
	{
		activate.Invoke();
	}


}
