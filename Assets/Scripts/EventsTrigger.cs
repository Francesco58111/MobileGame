using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsTrigger : MonoBehaviour {

    #region Fields
    [Header("Events configuration")]

    [Tooltip("le délai en seconde avant que les events ne soit trigger")]
    [SerializeField] float delay = 0.0f;

    [Tooltip("Permet de déclencher les events à l'infini si true OU une seule fois des qu'un type d'event est trigger si false")]
    [SerializeField] bool isInfinite = false;

    [Tooltip("le tag de l'objet qui peut trigger les events. Par default, c'est le Player")]
    [SerializeField] string triggerTag = "Player";

    [Header("Events")]
    public EventEnter[] enter;
    public EventStay[] stay;
    public EventExit[] exit;



    private enum eventToCall { Enter, Exit, Stay } //pour détecter le type d'event à appeler
    bool isCallingEvent = false;

    #endregion

    #region Class

    [System.Serializable]
    public class EventEnter
    {
        [SerializeField] string groupName;
        public UnityEvent eventEnter;
    }

    [System.Serializable]
    public class EventStay
    {
        [SerializeField] string groupName;
        public UnityEvent eventStay;
    }

    [System.Serializable]
    public class EventExit
    {
        [SerializeField] string groupName;
        public UnityEvent eventExit;
    }

    #endregion


    private void Awake()
    {
        Collider colliderExist = GetComponent<Collider>();
        if (colliderExist == null) Debug.LogError("Il n'y a pas de collider sur le gameObject " + gameObject.name + " pour le script EventTrigger"); //PAS DE COLLIDER
        else if (!colliderExist.isTrigger) Debug.LogError("Le Collider sur le gameObject " + gameObject.name + " n'a pas son collider en isTrigger pour le script EventTrigger"); //PAS EN isTrigger
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == triggerTag)
        {
            int nbrEvent = enter.Length;
            if (nbrEvent == 0) return;

            eventToCall callEvent = eventToCall.Enter; //le type d'event à appeler
            StartCoroutine(PlayEvent(callEvent)); //lance l'event
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == triggerTag && !isCallingEvent)
        {
            int nbrEvent = stay.Length;
            if (nbrEvent == 0) return;

            eventToCall callEvent = eventToCall.Stay; //le type d'event à appeler
            StartCoroutine(PlayEvent(callEvent)); //lance l'event
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == triggerTag)
        {
            int nbrEvent = exit.Length;
            if (nbrEvent == 0) return;

            eventToCall callEvent = eventToCall.Exit; //le type d'event à appeler
            StartCoroutine(PlayEvent(callEvent)); //lance l'event
        }
    }

    /// <summary>
    /// To play an event
    /// </summary>
    /// <param name="eventToApply"></param>
    /// <returns></returns>
    IEnumerator PlayEvent(eventToCall eventToApply)
    {
        isCallingEvent = true;
        yield return new WaitForSeconds(delay); //délai avant event

        //APPLICATION DE EVENT
        switch (eventToApply)
        {
            case eventToCall.Enter:
                for (int i = 0; i < enter.Length; i++)
                {
                    enter[i].eventEnter.Invoke();
                }
                break;

            case eventToCall.Exit:
                for (int i = 0; i < exit.Length; i++)
                {
                    exit[i].eventExit.Invoke();
                }
                break;

            case eventToCall.Stay:
                for (int i = 0; i < stay.Length; i++)
                {
                    stay[i].eventStay.Invoke();
                }
                break;
        }

        //check s'il doit desactiver le script
        if (!isInfinite) StopEventTrigger();

        isCallingEvent = false;
    }

    /// <summary>
    /// Use this function to disable the script
    /// </summary>
    void StopEventTrigger()
    {
        StopAllCoroutines();
        this.enabled = false;
    }
}
