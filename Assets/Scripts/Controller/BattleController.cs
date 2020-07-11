using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class BattleController : MonoBehaviour
    {
        public Battle Battle { get; set; }
        [SerializeField]
        private PlayerController PlayerCharacter;
        [SerializeField]
        private EnemyController EnemyCharacter;

        private void Start()
        {
            Battle.Init();
            PlayerCharacter.Init(Battle.Player);
        }
    }
}
