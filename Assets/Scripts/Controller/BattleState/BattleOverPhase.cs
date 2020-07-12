using System;
using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller.BattleState
{
    internal class BattleOverPhase : IBattlePhase
    {
        public BattleController BattleController { get; private set; }

        public void Execute(BattleController battle)
        {
            BattleController = battle;
            BattleController.ShowGameOverPanel();
        }

        public void Finish()
        {
        }

        public bool IsOver()
        {
            return BattleController.ShouldReload;
        }

        public IBattlePhase GoToNext()
        {
            return null;
        }
    }
}