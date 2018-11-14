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
	Vector3 direction;
	[Range(0,1000)]public float maxSpeed = 5;
	[Range(0,1000)]public float acceleration = 5;
	public float gravity = 10;


	private void Start()
	{
		rb = GetComponentInChildren<Rigidbody>();
		destination = new Vector3(0, transform.position.y, 0);
	}

	private void Update()
	{ 	
		GetInput();
		Move();
	}



	private void Move()
	{
		direction = destination - transform.position;
		direction = new Vector3(direction.x, 0, direction.z);
		//transform.LookAt(direction); 
		//rb.MovePosition(Vector3.Lerp(rb.position, destination, speed * Time.deltaTime));
		if(rb.velocity.magnitude < maxSpeed && Input.GetMouseButton(0))
		{
			rb.AddForce(direction * acceleration);
		}
	}

	void GetInput()
	{
		if (Input.GetMouseButton(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(ray, out hit);
			if (hit.collider == null) return;

			destination = new Vector3(hit.point.x, hit.point.y, hit.point.z);
		}

	}

}
