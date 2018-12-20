using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	public bool walled = false;




	private void Start()
	{
		rb = GetComponentInChildren<Rigidbody>();
		destination = new Vector3(0, transform.position.y, 0);
	}

	private void Update()
	{
		GetInput();
		Move();
		ApplyGravity();
		Checkdeath();
	}

	private void Checkdeath()
	{
		if(transform.position.y < -2)
		{
			Death();
		}
	}


	private void ApplyGravity()
	{
		//Debug.DrawRay(transform.position, direction.normalized * .85f, Color.green);
		//if (Physics.Raycast(transform.position, direction.normalized, 0.85f))
		//{
		//	walled = true;
		//	//rb.velocity = new Vector3(0, rb.velocity.y, 0);
		//}
		//else
		//	walled = false;

		Debug.DrawRay(transform.position, Vector3.down * 1.15f, Color.red);
		if(!Physics.Raycast(transform.position, Vector3.down, 1.15f) )
		{

			rb.AddForce(Vector3.down * gravity);
		}
	}

	private void GetInput()
	{
		if (Input.GetMouseButton(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(ray, out hit);
			if (hit.collider == null) return;

			destination = new Vector3(hit.point.x, hit.point.y, hit.point.z);
		}

	}

	private void Move()
	{
		direction = destination - transform.position;
		direction = new Vector3(direction.x, 0, direction.z);
		//transform.LookAt(direction); 
		//rb.MovePosition(Vector3.Lerp(rb.position, destination, speed * Time.deltaTime));
		if(rb.velocity.magnitude < maxSpeed && Input.GetMouseButton(0) && !walled)
		{
			rb.AddForce(direction * acceleration);
		}
		transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
	}

	public void Death()
	{
		//stopper la camera
		//jouer l'anim de mort
		//afficher la mort (et le score ?)
		StartCoroutine(Respawn());
	}

	IEnumerator Respawn()
	{
		//écran de chargement
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	
}
