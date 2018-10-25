using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Move : MonoBehaviour
{

	Ray ray;
	RaycastHit hit;
	Rigidbody rb;
	public float speed = 5;
	Vector3 destination;


	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		destination = new Vector3(0, transform.position.y, 0);
	}

	private void Update()
	{
		GetInput();
		Move();
	}

	private void Move()
	{
		transform.rotation = Quaternion.LookRotation(destination - transform.position, Vector3.up);
		rb.MovePosition(Vector3.Lerp(rb.position, destination, speed * Time.deltaTime));
	}

	void GetInput()
	{
		if (Input.GetMouseButton(0))
		{

			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(ray, out hit);
			if (hit.collider == null) return;

			destination = new Vector3(hit.point.x, transform.position.y, hit.point.z);
		}
	}
}
