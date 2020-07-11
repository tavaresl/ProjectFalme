using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Domain.Humours
{

    public class Contrarian : Humour
    {
        Suggestion PreviousSuggestion { get; set; }
        public override Action GetAction(Suggestion suggestion, float currentHP)
        {
            var AttackChance = 3;
            var DefendChance = 3;
            var BuffChance = 3;
            var DoNothingChance = 3;
            var FleeChance = 0;

            switch (suggestion)
            {
                case Suggestion.Attack:
                    DefendChance += 2;
                    AttackChance -= 2;
                    break;
                case Suggestion.Defend:
                    AttackChance += 2;
                    DefendChance -= 2;
                    break;
                case Suggestion.Support:
                    BuffChance -= 2;
                    AttackChance += 1;
                    DefendChance += 1;
                    break;
                case Suggestion.Whatever:
                    switch (PreviousSuggestion)
                    {
                        case Suggestion.Defend:
                            DefendChance += 2;
                            AttackChance -= 2;
                            break;
                        case Suggestion.Attack:
                            AttackChance += 2;
                            DefendChance -= 2;
                            break;
                        case Suggestion.Support:
                            BuffChance += 2;
                            AttackChance -= 1;
                            DefendChance -= 1;
                            break;
                        case Suggestion.Whatever:
                            BuffChance -= 3;
                            AttackChance -= 3;
                            DefendChance -= 3;
                            break;
                        default:
                            break;
                    }
                    break;
            }

            PreviousSuggestion = suggestion;

            var rand = new Random();
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
