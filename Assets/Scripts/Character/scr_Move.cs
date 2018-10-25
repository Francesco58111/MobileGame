using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Move : MonoBehaviour
{
	public GameObject touchEffect;

	Touch touch;
	Ray ray;
	RaycastHit hit;

	private void Update()
	{
		GetInput();
		Move();
	}

	private void Move()
	{
		this.transform.position = Vector3.Lerp(this.transform.position, hit.point, Time.deltaTime);
	}

	void GetInput()
	{
		if (Input.touchCount > 0)
		{
			touch = Input.GetTouch(0);
			ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			if (Physics.Raycast(ray, out hit))
			{
				Instantiate(touchEffect, hit.point, new Quaternion(0, 0, 0, 0));
			}
		}
	}
}
