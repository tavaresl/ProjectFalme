using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller.BattleState
{
    internal class DraftPhase : IBattlePhase
    {
        public PlayerController Player { get; private set; }
        public EnemyController Enemy { get; private set; }

        public void Execute(BattleController battle)
        {
            Enemy = battle.EnemyCharacter;
            Player = battle.PlayerCharacter;

            Enemy.Draft();
            Player.Draft();
        }

        public void Finish()
        {
        }

        public bool IsOver()
        {
            return Player?.HasDrafted ?? false;
        }

        public IBattlePhase GoToNext()
        {
            return new ActionSuggestionPhase();
        }
    }
}