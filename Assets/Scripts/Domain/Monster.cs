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
        public float DamageReductionRate { get; set; }
        public float BuffRate { get; set; }
        public bool HasFled { get; set; }

        public void StartNewTurn()
        {
            DamageReductionRate = 1f;
            BuffRate = 1f;
        }

        public Action PickAction(Suggestion suggestion)
        {
            return Humour.GetAction(suggestion, (float)Health/(float)MaxHealth);
        }

        public void TakeHitFrom(Monster attacker)
        {
            var damage = (attacker.Strength * attacker.BuffRate - Defense * DamageReductionRate) * GetDamageModifier(attacker.Type);
            Health -= (int)Math.Floor(damage > 0 ? damage : 1);
        }

        public bool CanFight()
        {
            return !HasFled && Health > 0;
        }

        public float GetDamageModifier(IMonsterType attacker) => this.Type.AddVulnerability(attacker.GetMonsterType());

        internal void Buff(Monster target)
        {
            target.BuffRate += 0.25f;
            target.DamageReductionRate += 0.25f;
        }

        internal void Flee()
        {
            HasFled = true;
        }

        public void Defend()
        {
            DamageReductionRate += 0.25f;
        }
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