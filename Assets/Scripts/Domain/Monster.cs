using System;
using Assets.Scripts.Domain.Monsters;
using UnityEngine;

namespace Assets.Scripts.Domain
{
    public class Monster
    {
        public string Name { get; set; }

        public int MaxHealth { get; set; }
        public int Health { get; set; }

        public int Strength { get; set; }

        public int Defense { get; set; }

        public int Speed { get; set; }
        public IMonsterType Type { get; set; }
        public Humour Humour { get; set; }

        public Action PickAction(Suggestion suggestion)
        {
            return Humour.GetAction(suggestion, (float)Health/(float)MaxHealth);
        }

        public void TakeHitFrom(Monster attacker)
        {
            var damage = (attacker.Strength - Defense) * GetDamageModifier(attacker.Type);
            Health -= (int)Math.Floor(damage > 0 ? damage : 1);
        }

        public float GetDamageModifier(IMonsterType attacker) => this.Type.AddVulnerability(attacker.GetMonsterType());
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