using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller.BattleState
{
    internal class BattleOverPhase : IBattlePhase
    {
        public void Execute(BattleController battle)
        {
            //TO DO definir acoes pos batalha
        }

        public void Finish()
        {
        }

        public bool IsOver()
        {
            return true;
        }

        public IBattlePhase GoToNext()
        {
            return null;
        }
    }
}