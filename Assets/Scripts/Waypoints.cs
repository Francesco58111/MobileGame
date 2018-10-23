using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {

    public List<Waypoints> wayPoints;
    public float speed = 3f;
    public bool isCircular;

    // Toujours true au début car l'objet à bouger doit toujours avancer vers le 1er wayPoint
    public bool inReverse = true;

    private Waypoints currentWaypoint;
    private int currentIndex = 0;
    private bool isWaiting = false;
    private float speedStorage = 0;
    public float waitSeconds = 0;
    public float speedOut = 0;

    public float rotationSpeed = 5.0f;



    void Start()
    {
        //Set le premier waypoint
        if (wayPoints.Count > 0)
        {
            currentWaypoint = wayPoints[0];
        }
    }

    void Update()
    {

        if (currentWaypoint != null && !isWaiting)
        {
            MoveTowardsWaypoint();

        }
    }

    /// <summary>
    /// Pause l'objet 
    /// </summary>
    void Pause()
    {
        isWaiting = !isWaiting;
    }

    /// <summary>
    /// Bouge l'objet vers le wayPoint suivant défini
    /// </summary>
    private void MoveTowardsWaypoint()
    {
        //  Récupère la position actuelle de l'objet à bouger
        Vector3 currentPosition = this.transform.position;

        // Prend la position du waypoint suivant
        Vector3 targetPosition = currentWaypoint.transform.position;


        // Récupère la distance entre les deux waypoints
        if (Vector3.Distance(currentPosition, targetPosition) > .1f)
        {

            // Prend la direction
            Vector3 directionOfTravel = targetPosition - currentPosition;
            directionOfTravel.Normalize();


            // Scale le mouvement sur chaque axis by directionOfTravel
            this.transform.Translate(
                directionOfTravel.x * speed * Time.deltaTime,
                directionOfTravel.y * speed * Time.deltaTime,
                directionOfTravel.z * speed * Time.deltaTime,
                Space.World
            );
        }
        else
        {

            // Si le waypoint a une pause, alors attend
            if (currentWaypoint.waitSeconds > 0)
            {
                Pause();
                Invoke("Pause", currentWaypoint.waitSeconds);
            }

            // Si le waypoint a un changement de vitesse, l'applique
            if (currentWaypoint.speedOut > 0)
            {
                speedStorage = speed;
                speed = currentWaypoint.speedOut;
            }
            else if (speedStorage != 0)
            {
                speed = speedStorage;
                speedStorage = 0;
            }

            NextWaypoint();
        }
    }

    /// <summary>
    /// Fait passer au prochain wayPoint
    /// </summary>
    private void NextWaypoint()
    {
        if (isCircular)
        {

            if (!inReverse)
            {
                currentIndex = (currentIndex + 1 >= wayPoints.Count) ? 0 : currentIndex + 1;
            }
            else
            {
                currentIndex = (currentIndex == 0) ? wayPoints.Count - 1 : currentIndex - 1;
            }

        }
        else
        {

            // Si rendu au début ou a la fin, reverse
            if ((!inReverse && currentIndex + 1 >= wayPoints.Count) || (inReverse && currentIndex == 0))
            {
                inReverse = !inReverse;
            }
            currentIndex = (!inReverse) ? currentIndex + 1 : currentIndex - 1;

        }

        currentWaypoint = wayPoints[currentIndex];
    }
}
