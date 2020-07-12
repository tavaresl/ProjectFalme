using Assets.Scripts.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Domain.Humours
{

    public class Obedient : Humour
    {
        public override Action GetAction(Suggestion suggestion, float currentHP)
        {
            var AttackChance = 1;
            var DefendChance = 1;
            var BuffChance = 1;
            var DoNothingChance = 1;
            var FleeChance = 0;

            switch (suggestion)
            {
                case Suggestion.Attack:
                    AttackChance += 4;
                    break;
                case Suggestion.Defend:
                    DefendChance += 4;
                    break;
                case Suggestion.Support:
                    BuffChance += 4;
                    break;
                case Suggestion.Whatever:
                    DoNothingChance += 4;
                    break;
            }

            var rand = RNG.GetRandom();
            var roll = rand.Next(0, AttackChance + DefendChance + BuffChance + DoNothingChance + FleeChance);
            if (roll < AttackChance)
                return Action.Attack;
            if (roll > AttackChance && roll < AttackChance + DefendChance)
                return Action.Defend;
            if (roll > AttackChance + DefendChance && roll < AttackChance + DefendChance + BuffChance)
                return Action.Buff;
            else
                return Action.DoNothing;
        }
    }
}
