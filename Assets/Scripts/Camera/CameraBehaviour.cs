using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


[ExecuteInEditMode]
public class CameraBehaviour : MonoBehaviour
{

    public CinemachineVirtualCamera cam;
    public CinemachineBrain brain;


    private void Awake()
    {
        cam.gameObject.SetActive(false);
    }

    void Update()
    {
        cam.gameObject.transform.position = brain.gameObject.transform.position;
    }
}
