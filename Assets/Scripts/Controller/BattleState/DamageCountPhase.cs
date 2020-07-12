using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller.BattleState
{
    internal class DamageCountPhase : IBattlePhase
    {
        public void Execute(BattleController battle)
        {

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
            return new MonsterDeathCheckPhase();
        }
    }
}