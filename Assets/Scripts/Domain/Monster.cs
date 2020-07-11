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

        public IMonsterType Type { get; set; }

        public IHumour Humour { get; set; }

        public Action PickAction(Suggestion suggestion)
        {
            return Humour.GetAction(suggestion);
        }

        public void TakeHit(int attackValue, IMonsterType attackerType)
        {
            var damage = (attackValue - Defense) * GetDamageModifier(attackerType);
            Health -= (int)Math.Floor(damage > 0 ? damage : 1);
        }

        public float GetDamageModifier(IMonsterType attackerType) => this.Type.addVulnerability(attackerType);
    }

   /* public enum MonsterType
    {
        Summer,
        Fall,
        Winter,
        Spring,
        Catlike,
    }*/
}