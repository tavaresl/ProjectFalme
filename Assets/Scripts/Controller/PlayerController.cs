using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class PlayerController : MonoBehaviour
    {
        public Suggestion Suggestion { get; private set; }
        public Player Player { get; private set; }
        public IList<MonsterController> Monsters { get; private set; }
        public MonsterSpawner MonsterSpawner { get; private set; }
        public bool HasDrafted => Player.FinishedDraft();
        public bool HasSuggested { get; private set; }

        public void Init(MonsterSpawner monsterSpawner, Player player)
        {
            Player = player;
            Monsters = new List<MonsterController>();
            MonsterSpawner = monsterSpawner;

            for (int i = 0; i < 6; i++)
            {
                MonsterController monsterController = MonsterSpawner.Spawn().GetComponent<MonsterController>();
                Player.ChooseMonster(monsterController.Monster);
                Monsters.Add(monsterController);
            }
        }

       public void Update()
        {
            //GET SUGGESTION
        }

        public void Draft()
        {
            Player.PickMonsters();
        }

        public void PickSuggestion()
        {
            
            HasSuggested = true;
            // Solicitar para a pessoa escolher a��o a sugerir para os monstros em batalha
        }

        public void SendSuggestion()
        {
            foreach (MonsterController monster in Monsters)
           {
               monster.PickAction(Suggestion);
           } 
            HasSuggested = false;

        }
    }
}