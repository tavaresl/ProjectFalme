using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Domain;
using Assets.Scripts.Domain.Monsters;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Action = Assets.Scripts.Domain.Action;

namespace Assets.Scripts.Controller
{
    public class MonsterController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Monster Monster { get; set; }
        //public new string name;

        //[Range(0, 100)]
        //public int health;

        //[Range(0, 10)]
        //public int strength;

        //[Range(0, 10)]
        //public int defense;

        //[Range(0, 5)]
        //public int speed;
        //public IMonsterType type;
        //public Humour humour;

        [SerializeField]
        public Text HealthBar;
        private MonsterStatsPanelController StatsPanelController;

        public void Init(Monster monster, MonsterStatsPanelController statsPanelController)
        {
            Monster = monster;
            StatsPanelController = statsPanelController;
        }

        public Action PickAction(Suggestion suggestion)
        {
            return Monster.PickAction(suggestion);
        }

        public void Do(Action action, IList<Monster> playerMonsters, IList<Monster> enemyMonsters)
        {
            if (Monster.CanFight())
            {
                Monster target = Monster.Humour.GetTarget(action, Monster, playerMonsters, enemyMonsters);
                if (action == Action.Attack)
                    target.TakeHitFrom(Monster);
                else if (action == Action.Defend)
                    target.Defend();
                else if (action == Action.Buff)
                    target.Buff(target);
                else if (action == Action.Flee)
                    target.Flee();
            }
        }

        public void SetHealth()
        {
            HealthBar.text = $"{Monster.Health}/{Monster.MaxHealth}";
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            StatsPanelController.Update(Monster);
            StatsPanelController.gameObject.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            StatsPanelController.gameObject.SetActive(false);
        }
    }
}