using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private int hp;

    [SerializeField]
    private int attack;
    
    public int initiative;

    public bool IsDead => hp <= 0;

    public void Attack(Character target)
    {
        target.hp -= attack;
    }

    public static int CompareCharactersByInitiative(Character a, Character b)
    {
        return a.initiative.CompareTo(b.initiative);
    }


    public abstract void TakeTurn(Combat combat);
}
