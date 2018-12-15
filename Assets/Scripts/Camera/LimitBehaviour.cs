using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitBehaviour : MonoBehaviour
{
    [Header("Camera Box Collisions")]
    public BoxCollider boxCollider;
    public MeshRenderer mesh;

    public bool canKill;





    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (canKill == true)
        {
            mesh.enabled = true;
        }
        else
        {
            mesh.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canKill == true)
        {
            collision.gameObject.SetActive(false);
        }
            
    }

}
