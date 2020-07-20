using Assets.Scripts.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Domain.Humours
{
    public class Rebel : Humour
    {
        public override string Name => "Rebel";

        public override Action GetAction(Suggestion suggestion, float currentHP)
        {
            var AttackChance = 3;
            var DefendChance = 3;
            var BuffChance = 3;
            var DoNothingChance = 1;
            var FleeChance = 1;

            switch (suggestion)
            {
                case Suggestion.Attack:
                    AttackChance += 1;
                    break;
                case Suggestion.Defend:
                    DefendChance += 1;
                    break;
                case Suggestion.Support:
                    BuffChance += 1;
                    break;
                case Suggestion.Whatever:
                    AttackChance += 2;
                    DefendChance += 2;
                    BuffChance += 2;
                    DoNothingChance += 2;
                    FleeChance += 2;
                    break;
                default:
                    break;
            }

            if (currentHP < 0.15)
            {
                FleeChance += 2;
                //TODO Atacar Treinadores
            }

            var rand = RNG.GetRandom();
            var roll = rand.Next(0, AttackChance + DefendChance + BuffChance + DoNothingChance + FleeChance);
            if (roll < AttackChance)
                return Action.Attack;
            if (roll > AttackChance && roll < AttackChance + DefendChance)
                return Action.Defend;
            if (roll > AttackChance + DefendChance && roll < AttackChance + DefendChance + BuffChance)
                return Action.Buff;
            if (roll > AttackChance + DefendChance + BuffChance && roll < AttackChance + DefendChance + BuffChance + DoNothingChance)
                return Action.DoNothing;
            else
                return Action.Flee;
        }

        public override Monster GetTarget(Action action, Monster self, IList<Monster> PlayerMonsters, IList<Monster> EnemyMonsters)
        {
            var rand = new Random();
            if (action == Action.Attack)
            {
                if (rand.NextDouble() > 0.8)
                    return EnemyMonsters[rand.Next(0, EnemyMonsters.Count)];
                else
                    return PlayerMonsters[rand.Next(0, PlayerMonsters.Count)];
            }
            if (action == Action.Buff)
            {
                if (rand.NextDouble() > 0.8)
                    return PlayerMonsters[rand.Next(0, PlayerMonsters.Count)];
                else
                    return EnemyMonsters[rand.Next(0, EnemyMonsters.Count)];
            }
            return self;
        }
    }
}
