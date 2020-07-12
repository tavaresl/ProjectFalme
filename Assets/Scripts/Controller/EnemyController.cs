using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Controller;
using Assets.Scripts.Domain;
using Assets.Scripts.Helpers;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public Suggestion SuggestionObj { get; private set; }
    public IList<GameObject> Monsters { get; private set; }
    public MonsterSpawner MonsterSpawner { get; private set; }
    public Player Enemy { get; private set; }

    public void Draft()
    {
        Monsters = new List<GameObject>();

        List<Vector3> positions = new List<Vector3>()
        {
            new Vector3(0f, -40f, 0f),
            new Vector3(30f, -30f, 0f),
            new Vector3(40f, 0f, 0f)
        };
        int counter = 0;


        for (int i = 0; i < 3; i++)
        {

            GameObject monster = MonsterSpawner.Spawn();
            monster.transform.SetParent(transform);
            Enemy.ChooseMonster(monster.GetComponent<MonsterController>().Monster);
            Monsters.Add(monster);

            monster.transform.localPosition = positions[counter];
            counter++;
        }

        Enemy.PickMonsters();
    }

    public void Init(MonsterSpawner monsterSpawner, Player enemy)
    {
        MonsterSpawner = monsterSpawner;
        Enemy = enemy;
    }
    
    public void PickSuggestion()
    {
        var values = new List<object>{Enum.GetValues(typeof(Suggestion))};
        int position = RNG.GetRandom().Next(0, values.Count);
        SuggestionObj =  (Suggestion)values[position];
        
        // Solicitar para a pessoa escolher a��o a sugerir para os monstros em batalha
    }

    public void SendSuggestion()
    {
        foreach (MonsterController monster in Monsters.Select(m => m.GetComponent<MonsterController>()))
        {
            monster.PickAction(SuggestionObj);
        }
    }

    public void RemoveDeadMonsters()
    {
        Enemy.RemoveDeadMonsters();
        Monsters = Monsters.Where(m => Enemy.MonstersInCombat.Contains(m.GetComponent<MonsterController>().Monster)).ToList();
        Debug.Log("Currently Alive Enemy: " + Monsters.Count);
    }
}
