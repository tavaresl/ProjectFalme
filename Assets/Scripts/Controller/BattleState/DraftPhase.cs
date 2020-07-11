using Assets.Scripts.Domain;

namespace Assets.Scripts.Controller.BattleState
{
    internal class DraftPhase : IBattlePhase
    {
        public PlayerController Player { get; private set; }
        public EnemyController Enemy { get; private set; }

        public void Execute(BattleController battle)
        {
            // Esperar player selecionar os monstros
            throw new System.NotImplementedException();
        }

        public bool IsOver()
        {
            return Player.HasPickedSuggestion();
        }

        public IBattlePhase GoToNext()
        {
            return new ActionSuggestionPhase();
        }
    }
}