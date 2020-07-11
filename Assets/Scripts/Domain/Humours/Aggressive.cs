using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Domain.Humours
{
    public class Aggressive : IHumour
    {
        public Action GetAction(Suggestion suggestion, float currentHP)
        {
            var AttackChance = 3;
            var DefendChance = 1;
            var BuffChance = 1;

            switch(suggestion)
            {
                case Suggestion.Attack:
                    AttackChance += 2;
                    break;
                case Suggestion.Defend:
                    DefendChance += 1;
                    break;
                case Suggestion.Support:
                    BuffChance += 1;
                    break;
                case Suggestion.Whatever:
                    break;
            }

            var rand = new Random();
            var roll = rand.Next(0, AttackChance + DefendChance + BuffChance);
            if (roll > AttackChance)
                return Action.Attack;
            if (roll < AttackChance && roll > AttackChance + DefendChance)
                return Action.Defend;
            else
                return Action.Buff;
        }

        public Monster GetTarget(Action action, Monster self ,IList<Monster> PlayerMonsters, IList<Monster> EnemyMonsters)
        {
            var rand = new Random();
            if (action == Action.Attack)
            {
                return EnemyMonsters[rand.Next(0, EnemyMonsters.Count)];
            }
            if (action == Action.Defend)
            {
                return self;
            }

            return PlayerMonsters[rand.Next(0, PlayerMonsters.Count)];
        }
    }
}
