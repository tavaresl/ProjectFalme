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
            Action action = Monster.PickAction(suggestion);
            //DO STUFF

            switch(action)
            {
                case Action.Attack:
                {
                    //do stuff
                    break;
                } 
                case Action.Defend:
                {
                    //do stuff
                    break;
                }
                case Action.Buff: 
                {
                    //do stuff
                    break;
                }
                case Action.DoNothing:
                { 
                    //do stuff
                    break;
                }
                case Action.Flee:
                {
                     //do stuff
                    break;
                }
                default: 
                {
                    break;
                }
            }
        }
    }
}