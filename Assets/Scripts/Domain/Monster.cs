using System;
using UnityEngine;

namespace Assets.Scripts.Domain
{
    public class Monster
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public int Strength { get; set; }

        public int Defense { get; set; }
        public int Speed { get; set; }
        public MonsterType Type { get; set; }
        public IHumour Humour { get; set; }

        public Action PickAction(Suggestion suggestion)
        {
            return Humour.GetAction(suggestion);
        }

        public void TakeHit(int attackValue, MonsterType attackerType)
        {
            var damage = (attackValue - Defense) * GetDamageModifier(attackerType);
            Health -= (int)Math.Floor(damage > 0 ? damage : 1);
        }

        public float GetDamageModifier(MonsterType attackerType)
        {
#warning TODO: Implentar buffs e calculo de vantagem
            //Calcular beseado em tipo e buffs;
            return 0f;
        }
    }

    public enum MonsterType
    {
        Summer,
        Fall,
        Winter,
        Spring,
        Catlike,
    }
}