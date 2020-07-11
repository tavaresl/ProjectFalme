using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Domain
{
    public class Player
    {
        public IList<Suggestion> Suggestions { get; set; }
        public IList<Monster> MonstersInCombat { get; set; }
        public IList<Monster> AllMonsters { get; set; }

        public IList<Monster> GetRandomMonsters()
        {
            //Monster.GetRandomMonster
            return new List<Monster>();
        }

        public void PickMonster()
        {
            //DRAFT
        }

        public void Init()
        {

        }

        public bool CanKeepFighting()
        {
            return MonstersInCombat.Any(m => m.Health > 0 && !m.Fled); // Verificar necessidade de checar o monstro pickado
        }
    }
}