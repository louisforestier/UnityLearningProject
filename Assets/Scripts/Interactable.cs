using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private Outline outline;

    //TODO:
    // grid movement: https://www.youtube.com/watch?v=fUiNDDcU_I4
    // https://forum.unity.com/threads/question-about-rpg-movement.710078/ https://gingkoapp.com/how-to-navmesh-movement-range.html
    // group movement: https://www.gamedev.net/articles/programming/general-and-gameplay-programming/pathfinding-and-local-avoidance-for-rpgrts-games-using-unity-r3703/

    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("interactable start");
        outline = GetComponent<Outline>();
    }

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        outline.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        outline.enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(AddInteraction(player));
    }

    private IEnumerator AddInteraction(GameObject other)
    {
        Debug.Log("OnTriggerEnter interactable");
        if (other.GetComponent<Player>() is Player p)
        {
            yield return new WaitUntil(() => p.ReachedDest());
            Interact(other.gameObject);
        }
    }


    protected virtual void Interact(GameObject other)
    {
        Debug.Log("interact");
    }


}
