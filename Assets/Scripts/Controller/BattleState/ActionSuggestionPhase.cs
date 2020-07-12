using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller.BattleState
{
    internal class ActionSuggestionPhase : IBattlePhase
    {
        public PlayerController Player { get; private set; }

        public SuggestionMenuController SuggestionMenu { get; private set; }

        public void Execute(BattleController battle)
        {
            Player = battle.PlayerCharacter;
            SuggestionMenu = battle.SuggestionMenu;
            SuggestionMenu.Show();
            SuggestionMenu.Enable();
        }

        public void Finish()
        {
            SuggestionMenu.Hide();
        }

        public bool IsOver()
        {
            if (Player.HasSuggested)
                Debug.Log("Player Has Suggested: " + Player.Suggestion.ToString());
            return Player.HasSuggested;
        }

        public IBattlePhase GoToNext()
        {
            return new MonsterSortPhase();
        }
    }
}