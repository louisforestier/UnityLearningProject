using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Combat
{
    public List<Character> players = new List<Character>();
    public List<Character> ennemies = new List<Character>();
    public Queue<Character> turns;


    public Combat(List<Character> players, List<Character> ennemies)
    {
        Debug.Log("Init combat");
        this.players.AddRange(players);
        this.ennemies.AddRange(ennemies);
    }

    public void RunCombat()
    {
        Debug.Log("Run combat");
        InitTurn();
    }

    private void InitTurn()
    {
        Debug.Log("Init turn");
        List<Character> participants = new List<Character>();
        for (int i = 0; i < players.Count; i++)
        {
            Character c = players[i];
            if (!c.IsDead)
                participants.Add(c);
            else players.RemoveAt(i);
        }
        for (int i = 0; i < ennemies.Count; i++)
        {
            Character c = ennemies[i];
            if (!c.IsDead)
                participants.Add(c);
            else ennemies.RemoveAt(i);
        }
        participants.AddRange(players);
        participants.AddRange(ennemies);
        participants.Sort(Character.CompareCharactersByInitiative);
        turns = new Queue<Character>(participants);
    }
}
