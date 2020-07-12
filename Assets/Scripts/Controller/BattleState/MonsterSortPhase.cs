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
            throw new System.NotImplementedException();
        }

        public IBattlePhase GoToNext()
        {
            return new ActionPickPhase();
        }
    }
}