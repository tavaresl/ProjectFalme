using Assets.Scripts.Domain;

namespace Assets.Scripts.Controller.BattleState
{
    internal class BattleOverCheckPhase : IBattlePhase
    {
        private bool _battleIsOver = false;
        
        public void Execute(BattleController battle)
        {
            throw new System.NotImplementedException();
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
            if (_battleIsOver)
                return new BattleOverPhase();

            return new ActionSuggestionPhase();
        }
    }
}