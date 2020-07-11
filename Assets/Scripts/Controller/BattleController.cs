using Assets.Scripts.Controller.BattleState;
using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class BattleController : MonoBehaviour
    {
        public Battle Battle { get; set; }

        [SerializeField]
        public PlayerController PlayerCharacter { get; private set; }

        [SerializeField]
        public EnemyController EnemyCharacter { get; private set; }
        public IBattlePhase CurrentPhase { get; private set; }

        private void Start()
        {
            CurrentPhase = new DraftPhase();
            Battle.Init();
            PlayerCharacter.Init(Battle.Player);

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
    }
}
