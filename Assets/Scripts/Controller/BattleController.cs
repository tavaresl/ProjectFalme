using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Controller.BattleState;
using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class BattleController : MonoBehaviour
    {
        public Battle Battle { get; set; }

        public IList<MonsterController> AttackOrder { get; private set; }

        [SerializeField]
        public PlayerController PlayerCharacter;

        [SerializeField]
        public EnemyController EnemyCharacter;

        [SerializeField]
        public MonsterSpawner MonsterSpawner;

        public IBattlePhase CurrentPhase { get; private set; }

        public SuggestionMenuController SuggestionMenu { get; private set; }

        private void Start()
        {
            Battle = new Battle();
            Battle.Init();
            PlayerCharacter.Init(MonsterSpawner, Battle.Player);
            EnemyCharacter.Init(MonsterSpawner, Battle.Enemy);

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
            AttackOrder = new List<IList<MonsterController>> { PlayerCharacter.Monsters, EnemyCharacter.Monsters}
                .SelectMany(m => m)
                .OrderBy(m => m.Monster.Speed)
                .Reverse()
                .ToList();
        }
    }
}
