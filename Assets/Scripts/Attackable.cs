using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : Interactable
{
    public GameObject group;

    protected override void Interact(GameObject other)
    {
        base.Interact(other);

        StartCombat(other.gameObject,group);
    }

    private void StartCombat(GameObject gameObject, GameObject group)
    {
        Debug.Log("Start Combat");
    }
}
