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

	MeshFilter mesh;
	MeshRenderer meshRenderer;

	public Mesh pillarMesh;

	private int sideFilled = 0;

    [SerializeField] private bool upFilled;
	[SerializeField] private bool rightFilled;
	[SerializeField] private bool leftFilled;
	[SerializeField] private bool downFilled;

#if UNITY_EDITOR

    private void Update()
    {
        transform.localScale = Vector3.one;

        Physics.Raycast(transform.position + Vector3.up, Vector3.forward, out up, 1);
		if (up.collider != null)
		{
			upFilled = true;
			sideFilled++;
		}
		else
			upFilled = false;

        Physics.Raycast(transform.position + Vector3.up, Vector3.right, out right, 1);
		if (right.collider != null)
		{
			rightFilled = true;
			sideFilled++;
		}
		else
			rightFilled = false;

        Physics.Raycast(transform.position + Vector3.up, Vector3.left, out left, 1);
		if (left.collider != null)
		{
			leftFilled = true;
			sideFilled++;
		}
		else
			leftFilled = false;

        Physics.Raycast(transform.position + Vector3.up, Vector3.back, out down, 1);
		if (down.collider != null)
		{
			downFilled = true;
			sideFilled++;
		}
		else
			downFilled = false;



        if (upFilled && !rightFilled && !leftFilled || downFilled && !rightFilled && !leftFilled)
            transform.rotation = Quaternion.Euler(-90, 0, -90);

        if (rightFilled && !upFilled && !downFilled || leftFilled && !upFilled && !downFilled)
            transform.rotation = Quaternion.Euler(-90, 0, 0);

		if(sideFilled <= 3)
		{

		}
    }
#endif
}
#endif