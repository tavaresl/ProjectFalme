using Assets.Scripts.Helpers;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Domain
{
    public abstract class Humour
    {
        public abstract string Name { get; }
        public abstract Action GetAction(Suggestion suggestion, float currentHP);
        public virtual Monster GetTarget(Action action, Monster self, IList<Monster> PlayerMonsters, IList<Monster> EnemyMonsters)
        {
            var rand = RNG.GetRandom();
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
        // Aggressive, // Tende a atacar DONE
        // Pacific, // Tende a defender DONE
        // Contrarian, // Tende a fazer a ação contrária da sugestão DONE
        // Rebel, // Sugestão tem pouca influência, e pode fugir
        // Lazy, // Tende a não fazer nada DONE
        // Obedient // Tende a seguir a sugestão DONE
    }
}