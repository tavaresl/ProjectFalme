using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Domain.Humours
{
    public class NewBehaviourScript : IHumour
    {
        public Action GetAction(Suggestion suggestion, float currentHP)
        {
            var AttackChance = 1;
            var DefendChance = 2;
            var BuffChance = 2;
            var DoNothingChance = 1;
            var FleeChance = 0;

            switch (suggestion)
            {
                case Suggestion.Attack:
                    AttackChance += 1;
                    break;
                case Suggestion.Defend:
                    DefendChance += 2;
                    break;
                case Suggestion.Support:
                    BuffChance += 2;
                    break;
                case Suggestion.Whatever:
                    DefendChance += 1;
                    BuffChance += 1;
                    DoNothingChance += 2;
                    break;
            }

            if (currentHP < 0.15)
            {
                AttackChance -= 1;
                DefendChance += 2;
                FleeChance += 1;

            }

            var rand = new Random();
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

        public Monster GetTarget(Action action, Monster self, IList<Monster> PlayerMonsters, IList<Monster> EnemyMonsters)
        {
            var rand = new Random();
            if (action == Action.Attack)
            {
                return EnemyMonsters[rand.Next(0, EnemyMonsters.Count)];
            }
            if (action == Action.Buff)
            {
                return PlayerMonsters[rand.Next(0, PlayerMonsters.Count)];
            }
            return self;

        }
    }
}
