using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller.BattleState
{
    internal class MonsterSortPhase : MonoBehaviour, IBattlePhase
    {
        public void Execute(BattleController battle)
        {
            battle.SortAttackers();
        }

        public void Finish()
        {
        }

        public bool IsOver()
        {
            // Resolves as soon as it starts
            return true;
        }

        public IBattlePhase GoToNext()
        {
            return new ActionPickPhase();
        }
    }
}