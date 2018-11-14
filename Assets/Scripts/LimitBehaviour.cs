using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitBehaviour : MonoBehaviour
{
    [Header("Camera Box Collisions")]
    public BoxCollider boxCollider;

    public bool canKill;


    

    private void OnCollisionEnter(Collision collision)
    {
        if (canKill)
            collision.gameObject.SetActive(false);
    }

}
