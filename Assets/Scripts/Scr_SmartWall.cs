#if (UNITY_EDITOR)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Scr_SmartWall : MonoBehaviour
{
	RaycastHit up;
	RaycastHit right;
	RaycastHit left;
	RaycastHit down;

	public bool upFilled;
	public bool rightFilled;
	public bool leftFilled;
	public bool downFilled;

	private void Update()
	{
		transform.localScale = Vector3.one;

		Physics.Raycast(transform.position + Vector3.up, Vector3.forward, out up, 1);
		if (up.collider != null)
			upFilled = true;
		else
			upFilled = false;

		Physics.Raycast(transform.position + Vector3.up, Vector3.right, out right, 1);
		if (right.collider != null)
			rightFilled = true;
		else
			rightFilled = false;

		Physics.Raycast(transform.position + Vector3.up, Vector3.left, out left, 1);
		if (left.collider != null)
			leftFilled = true;
		else
			leftFilled = false;

		Physics.Raycast(transform.position + Vector3.up, Vector3.back, out down, 1);
		if (down.collider != null)
			downFilled = true;
		else
			downFilled = false;



		if (upFilled && !rightFilled && !leftFilled || downFilled && !rightFilled && !leftFilled)
			transform.rotation = Quaternion.Euler(-90,0,-90);

		if (rightFilled && !upFilled && !downFilled || leftFilled && !upFilled && !downFilled)
			transform.rotation = Quaternion.Euler(-90, 0, 0);
	}


}

#endif