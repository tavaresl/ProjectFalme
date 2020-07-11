using Assets.Scripts.Domain;

namespace Assets.Scripts.Controller.BattleState
{
    internal class ActionSuggestionPhase : IBattlePhase
    {
        public PlayerController Player { get; private set; }

        public void Execute(BattleController battle)
        {
            Player = battle.PlayerCharacter;

            Player.PickSuggestion();
        }

        public void Finish()
        {
        }

        public bool IsOver()
        {
            return Player.HasSuggested;
        }

        public IBattlePhase GoToNext()
        {
            return new MonsterSortPhase();
        }
    }
}