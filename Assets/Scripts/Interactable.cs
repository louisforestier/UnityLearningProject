using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Outline outline;
    private bool clicked;

    //TODO:
    // grid movement: https://www.youtube.com/watch?v=fUiNDDcU_I4
    // https://forum.unity.com/threads/question-about-rpg-movement.710078/ https://gingkoapp.com/how-to-navmesh-movement-range.html
    // group movement: https://www.gamedev.net/articles/programming/general-and-gameplay-programming/pathfinding-and-local-avoidance-for-rpgrts-games-using-unity-r3703/

    public bool Select
    {
        get => clicked;
        set
        {
            clicked = value;
            outline.enabled=value;
        }
    }
    
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    protected virtual void Start()
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
        if (!clicked)
            outline.enabled = false;
    }


    public virtual void Interact(GameObject other)
    {
        outline.enabled = false;
        Debug.Log("interact");
    }


}
