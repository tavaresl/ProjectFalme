using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Domain
{
    public class Player : MonoBehaviour
    {
        public Monster PickedMonster { get; set; }
        public IList<Suggestion> Suggestions { get; set; }
        public IList<Monster> Monsters { get; set; }

        // public void SortMonsters()
        // {
        //     Monsters.OrderBy(m => m.Speed);
        // }

        // public void PickMonster()
        // {
        //     PickedMonster = Monsters.LastOrDefault();

        //     if (PickedMonster != null)
        //     {
        //         Monsters.Remove(PickedMonster);
        //     }
        // }

        public bool HasMonsterAvailable()
        {
            return Monsters.Any() || PickedMonster != null; // Verificar necessidade de checar o monstro pickado
        }
    }
}