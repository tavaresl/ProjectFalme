using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller.BattleState
{
    internal class ActionSuggestionPhase : MonoBehaviour, IBattlePhase
    {
        public PlayerController Player { get; private set; }

        public SuggestionMenuController SuggestionMenu { get; private set; }

        public void Execute(BattleController battle)
        {
            Player = battle.PlayerCharacter;
            SuggestionMenu = battle.SuggestionMenu;
            SuggestionMenu.Show();
        }

        public void Finish()
        {
            SuggestionMenu.Hide();
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