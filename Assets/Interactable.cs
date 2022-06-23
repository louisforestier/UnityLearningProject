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

    //TODO: https://www.youtube.com/watch?v=fUiNDDcU_I4

    private NavMeshAgent player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
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
        Debug.Log("on pointer down");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("interact");
    }
}
