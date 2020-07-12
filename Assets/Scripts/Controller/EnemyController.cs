using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Controller;
using Assets.Scripts.Domain;
using UnityEngine;
using Random = System.Random;

public class EnemyController : MonoBehaviour
{
    
    public Suggestion SuggestionObj { get; private set; }
    public IList<MonsterController> Monsters { get; private set; }
    public MonsterSpawner MonsterSpawner { get; private set; }
    public Player Enemy { get; private set; }

    public void Draft()
    {
        IList<MonsterController> monsters = new List<MonsterController>();

        for (int i = 0; i < 3; i++)
        {
            monsters.Add(MonsterSpawner.Spawn().GetComponent<MonsterController>());
        }

        Monsters = monsters;
    }

    public void Init(MonsterSpawner monsterSpawner, Player enemy)
    {
        MonsterSpawner = monsterSpawner;
        Enemy = enemy;
    }
    
    public void PickSuggestion()
    {
        var values = new List<object>{Enum.GetValues(typeof(Suggestion))};
        int position = new Random().Next(0, values.Count);
        SuggestionObj =  (Suggestion)values[position];
        
        // Solicitar para a pessoa escolher a��o a sugerir para os monstros em batalha
    }

    public void SendSuggestion()
    {
        foreach (MonsterController monster in Monsters)
        {
            monster.PickAction(SuggestionObj);
        }
  
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveDeadMonsters()
    {
        Enemy.RemoveDeadMonsters();
        Monsters = Monsters.Where(m => Enemy.MonstersInCombat.Contains(m.Monster)).ToList();
    }
}
