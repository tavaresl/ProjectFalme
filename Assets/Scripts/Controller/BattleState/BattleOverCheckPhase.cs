using Assets.Scripts.Domain;

namespace Assets.Scripts.Controller.BattleState
{
    internal class BattleOverCheckPhase : IBattlePhase
    {
        private bool _battleIsOver = false;
        private bool _phaseIsOver = false;
        
        public void Execute(BattleController battle)
        {
            if (battle.PlayerCharacter.Player.CanKeepFighting() || battle.EnemyCharacter.Enemy.CanKeepFighting())
            {
                _battleIsOver = true;
            }

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