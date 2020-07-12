using Assets.Scripts.Domain;
using System.Linq;

namespace Assets.Scripts.Controller.BattleState
{
    internal class BattleOverCheckPhase : IBattlePhase
    {
        private bool _battleIsOver = false;
        private bool _phaseIsOver = false;
        
        public void Execute(BattleController battle)
        {
            if (!battle.PlayerCharacter.Player.CanKeepFighting() || !battle.EnemyCharacter.Enemy.CanKeepFighting())
            {
                _battleIsOver = true;
            }

            foreach (Monster monster in battle.PlayerCharacter.Player.MonstersInCombat)
            {
                monster.StartNewTurn();
            }

            foreach (Monster monster in battle.EnemyCharacter.Enemy.MonstersInCombat)
            {
                monster.StartNewTurn();
            }
            battle.PlayerCharacter.StartNewTurn();

            _phaseIsOver = true;

        }

        public void Finish()
        {
        }

        public bool IsOver()
        {
            return _phaseIsOver;
        }

        public IBattlePhase GoToNext()
        {
            if (_battleIsOver)
                return new BattleOverPhase();

            return new ActionSuggestionPhase();
        }
    }
}