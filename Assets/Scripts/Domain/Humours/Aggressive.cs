using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Domain.Humours
{
    public class Aggressive : Humour
    {
        public override string Name => "Aggressive";
        public override Action GetAction(Suggestion suggestion, float currentHP)
        {
            var AttackChance = 2;
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

            if (currentHP < 0.2)
            {
                AttackChance += 1;
            }

            var rand = new Random();
            var roll = rand.Next(0, AttackChance + DefendChance + BuffChance);
            if (roll > AttackChance)
                return Action.Attack;
            if (roll > AttackChance && roll < AttackChance + DefendChance)
                return Action.Defend;
            else
                return Action.Buff;
        }
    }
}
