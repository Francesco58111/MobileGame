using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobBehaviour : MonoBehaviour
{
    [Header("Déplacement du mob")]
    //Récupère le NavMeshAgent
    [Tooltip("Glissez le Nav Mesh Agent ici")]
    private NavMeshAgent nav;

    //Points de patrouille
    [Tooltip("Glissez les différents points de patrouille")]
    public List<GameObject>waypoints = new List<GameObject>();
    private int currentWaypoint;

    [Header("Detection System")]
    //Récupération de la position du joueur
    [Tooltip("Glisser le player ici")]
    public Transform playerTransform;
    public Detection detection;

    [Header("Récupération de l'animator")]
    public Animator anim;



    void Start()
    {
        //Récupère le Nav Mesh Agent du Gameobject
        nav = GetComponent<NavMeshAgent>();
        //Assign la première destination
        if (waypoints.Count != 0)
            SetNewDestination(waypoints[currentWaypoint % waypoints.Count].transform);
        else
            nav.SetDestination(transform.position);
    }


    void Update()
    {

        //Vérifie si le player est dans la zone de détection
        if (detection.playerInTrigger)
        {
            SetNewDestination(playerTransform);
            //Accélère le déplacement du mob
            nav.speed = 7;
        }

        //Lorsque le player n'est plus dans la zone, "il commence à le perdre de vue"
        if (detection.playerInTrigger == false && waypoints.Count != 0)
            StartCoroutine(WaitingAtWaypoint(5));


            if (Vector3.Distance(transform.position, nav.destination) <= nav.stoppingDistance)
        {
            currentWaypoint++;
            StartCoroutine(WaitingAtWaypoint(2));
        }
    }

    /// <summary>
    /// Temps avant de se rediriger vers un waypoint
    /// </summary>
    /// <param name="attente"></param>
    /// <returns></returns>
    private IEnumerator WaitingAtWaypoint(float attente)
    {
        yield return new WaitForSeconds(attente);
        SetNewDestination(waypoints[currentWaypoint % waypoints.Count].transform);
        nav.speed = 3.5f;
    }

    /// <summary>
    /// Set une destination
    /// </summary>
    /// <param name="target"></param>
    void SetNewDestination(Transform target)
    {
        nav.SetDestination(target.position);
        
    }

    /// <summary>
    /// Si le player rentre en collision, il détruit le gameobject
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.SetActive(false);
    }


    public void Falling()
    {
        anim.SetTrigger("Death");
        Debug.Log("Fall");
        nav.SetDestination(this.transform.position);
    }
}
