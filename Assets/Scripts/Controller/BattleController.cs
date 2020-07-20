using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Controller.BattleState;
using Assets.Scripts.Domain;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Controller
{
    public class BattleController : MonoBehaviour
    {
        public Battle Battle { get; set; }
        public bool ShouldReload { get; private set; }

        public IList<MonsterController> AttackOrder { get; private set; }

        [SerializeField]
        public PlayerController PlayerCharacter;

        [SerializeField]
        public EnemyController EnemyCharacter;

        [SerializeField]
        public MonsterSpawner MonsterSpawner;

        public IBattlePhase CurrentPhase { get; private set; }

        [SerializeField]
        public SuggestionMenuController SuggestionMenu;

        [SerializeField]
        public GameObject Winner, Loser;

        [SerializeField]
        public GameObject GameOverPanel;

        [SerializeField]
        private MonsterStatsPanelController StatsPanelController;

        private void Start()
        {
            ShouldReload = false;
            Battle = new Battle();
            Battle.Init();
            PlayerCharacter.Init(MonsterSpawner, Battle.Player, StatsPanelController);
            EnemyCharacter.Init(MonsterSpawner, Battle.Enemy, StatsPanelController);
            StatsPanelController.gameObject.SetActive(false);

            CurrentPhase = new DraftPhase();
            CurrentPhase.Execute(this);
        }

        void Update()
        {
            if (CurrentPhase != null && CurrentPhase.IsOver())
            {
                CurrentPhase.Finish();
                CurrentPhase = CurrentPhase.GoToNext();
                CurrentPhase.Execute(this);
            }
        }

        public void SortAttackers()
        {
            AttackOrder = new List<IList<MonsterController>>
            {
                PlayerCharacter.Monsters.Select(m => m.GetComponent<MonsterController>()).ToList(),
                EnemyCharacter.Monsters.Select(m => m.GetComponent<MonsterController>()).ToList()
            }
                .SelectMany(m => m)
                .OrderBy(m => m.Monster.Speed)
                .Reverse()
                .ToList();
        }

        public ICharacter GetWinner()
        {
            if (!PlayerCharacter.CanFight())
                return EnemyCharacter;

            if (!EnemyCharacter.CanFight())
                return PlayerCharacter;

            return null;
        }

        public void ShowGameOverPanel()
        {
            ICharacter winner = GetWinner();
            GameOverPanel.SetActive(true);

            if (winner is PlayerController)
            {
                Winner.SetActive(true);
                Loser.SetActive(false);
            }
            else
            {
                Winner.SetActive(false);
                Loser.SetActive(true);
            }
        }

        public void ReloadBattle()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ShouldReload = true;
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
