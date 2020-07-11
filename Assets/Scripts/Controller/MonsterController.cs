using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class MonsterController : MonoBehaviour
    {
        public Monster Monster { get; set; }
        public new string name;

        [Range(0, 100)]
        public int health;

        [Range(0, 10)]
        public int strength;

        [Range(0, 10)]
        public int defense;

        [Range(0, 5)]
        public int speed;
        public IMonsterType type;
        public IHumour humour;

        public void Init(Monster monster)
        {
            Monster = monster;
        }

        public Action PickAction(Suggestion suggestion)
        {
            return Monster.PickAction(suggestion);
        }

        public void Do(Action action, IList<Monster> playerMonsters, IList<Monster> enemyMonsters)
        {
            Monster target = humour.GetTarget(action, Monster, playerMonsters, enemyMonsters);
            target.TakeHitFrom(Monster);
        }
    }
}