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
        public PlayerController PlayerCharacter { get; private set; }

        [SerializeField]
        public EnemyController EnemyCharacter { get; private set; }

        [SerializeField]
        public MonsterSpawner MonsterSpawner { get; private set; }

        public IBattlePhase CurrentPhase { get; private set; }

        private void Start()
        {
            Battle.Init();
            PlayerCharacter.Init(MonsterSpawner, Battle.Player);
            EnemyCharacter.Init(MonsterSpawner, Battle.Enemy);

            CurrentPhase = new DraftPhase();
            CurrentPhase.Execute(this);
        }

        void Update()
        {
            if (CurrentPhase.IsOver())
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
