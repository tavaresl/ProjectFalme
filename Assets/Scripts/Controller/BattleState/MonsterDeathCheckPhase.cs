using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller.BattleState
{
    internal class MonsterDeathCheckPhase : MonoBehaviour, IBattlePhase
    {
        private bool _isOver;

        public void Execute(BattleController battle)
        {
            battle.PlayerCharacter.RemoveDeadMonsters();
            battle.EnemyCharacter.RemoveDeadMonsters();
            _isOver = true;
        }

        public void Finish()
        {
        }

        public bool IsOver()
        {
            return _isOver;
        }

        public IBattlePhase GoToNext()
        {
            return new BattleOverCheckPhase();
        }
    }
}