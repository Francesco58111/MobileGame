using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{

    public bool playerInTrigger;


    //Vérifie si le player est dans la zone de détection (box collider) du mob

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            playerInTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            playerInTrigger = false;
    }
}
