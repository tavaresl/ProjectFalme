using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Assets.Scripts.Domain
{
    public class Player
    {
        public IList<Suggestion> Suggestions { get; private set; }
        public IList<Monster> MonstersInCombat { get; private set; }
        public IList<Monster> AllMonsters { get; private set; }

        public void ChooseMonster(Monster monster)
        {
            AllMonsters.Add(monster);
        }

        public void PickMonsters()
        {
            for (int i = 0; i < 3; i++)
                MonstersInCombat.Add(AllMonsters[i]);
        }

        public bool FinishedDraft()
        {
            return MonstersInCombat.Count == 3;
        }

        public void Init()
        {
            AllMonsters = new List<Monster>();
            MonstersInCombat = new List<Monster>();
        }

        public bool CanKeepFighting()
        {
            return MonstersInCombat.Any(m => m.CanFight()); // Verificar necessidade de checar o monstro pickado
        }

        public void RemoveDeadMonsters()
        {
            MonstersInCombat = MonstersInCombat.Where(m => m.CanFight()).ToList();
        }
    }
}