using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : Interactable
{
    private GameObject group;

    protected override void Start()
    {
        base.Start();
        group = transform.parent is object ? transform.parent.gameObject : gameObject;
    }

    public override void Interact(GameObject other)
    {
        base.Interact(other);

        StartCombat(other,group);
    }

    private void StartCombat(GameObject gameObject, GameObject group)
    {
        Debug.Log("Start Combat");
        List<Character> players = new List<Character>();
        players.Add(gameObject.GetComponent<Character>());
        Combat c = new Combat(players,new List<Character>(group.GetComponentsInChildren<Character>()));
        c.RunCombat();
    }
}
