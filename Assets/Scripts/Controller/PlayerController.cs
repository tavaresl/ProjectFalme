using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class PlayerController : MonoBehaviour, ICharacter
    {
        public Suggestion Suggestion { get; private set; }
        public Player Player { get; private set; }
        public IList<GameObject> Monsters { get; private set; }
        public MonsterSpawner MonsterSpawner { get; private set; }
        public bool HasDrafted => Player.FinishedDraft();
        public bool HasSuggested { get; private set; }

        public void Init(MonsterSpawner monsterSpawner, Player player)
        {
            Player = player;
            Monsters = new List<GameObject>();
            MonsterSpawner = monsterSpawner;

            for (int i = 0; i < 6; i++)
            {
                GameObject monster = MonsterSpawner.Spawn();
                monster.transform.SetParent(transform);
                Player.ChooseMonster(monster.GetComponent<MonsterController>().Monster);
                Monsters.Add(monster);
            }
        }

        public void StartNewTurn()
        {
            HasSuggested = false;
        }

        public void Draft()
        {
            Player.PickMonsters();
            int counter = 0;
            List<Vector3> positions = new List<Vector3>()
            {
                new Vector3(0f, 40f, 0f),
                new Vector3(-30f, 30f, 0f),
                new Vector3(-40f, 0f, 0f)
            };

            var selectedMonsters = new List<GameObject>();

            foreach(GameObject monster in Monsters)
            {
                MonsterController monsterController = monster.GetComponent<MonsterController>();
                if (!Player.MonstersInCombat.Contains(monsterController.Monster))
                {

                    monsterController.Monster.Flee();
                    Destroy(monster);
                }
                else
                {
                    selectedMonsters.Add(monster);
                    monster.transform.localPosition = positions[counter];
                    monster.transform.localScale = new Vector3(.8f, .8f);
                    counter++;
                }
                Monsters = selectedMonsters;
            }
        }

        public void PickSuggestion(Suggestion suggestion)
        {
            Debug.Log("Suggestion Get: " + suggestion.ToString());
            Suggestion = suggestion;
            HasSuggested = true;
        }

        //public void SendSuggestion()
        //{
        //   foreach (MonsterController monster in Monsters.Select(m => m.GetComponent<MonsterController>()))
        //   {
        //       monster.PickAction(Suggestion);
        //   } 
        //    HasSuggested = false;

        //}

        public void RemoveDeadMonsters()
        {
            Player.RemoveDeadMonsters();
            Monsters = Monsters.Where(m => Player.MonstersInCombat.Contains(m.GetComponent<MonsterController>().Monster)).ToList();
            Debug.Log("Currently Alive Player: " + Monsters.Count);
        }

        public bool CanFight()
        {
            return Player.CanKeepFighting();
        }
    }
}