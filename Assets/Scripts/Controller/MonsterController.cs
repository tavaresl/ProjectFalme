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
        public MonsterType type;
        public Humour humour;

        public void Init(Monster monster)
        {
            Monster = monster;
            //Monster = new Monster
            //{
            //    Name = name,
            //    Health = health,
            //    Strength = strength,
            //    Defense = defense,
            //    Speed = speed,
            //    Humour = humour,
            //    Type = type
            //};
        }

        public void DoAction(Suggestion suggestion)
        {
            var action = Monster.PickAction(suggestion);
            //DO STUFF
        }
    }
}