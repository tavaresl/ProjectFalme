using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class PlayerController : MonoBehaviour
    {
        public Player Player { get; private set; }
        public bool HasDrafted { get; private set; }
        public bool HasSuggested { get; private set; }

        public void Init(Player player)
        {
            Player = player;
        }

        public void Update()
        {
            //GET SUGGESTION
        }

        public void Draft()
        {
            // Solicitar para a pessoa escolher os pokemons que irá usar na batalha
        }

        public void PickSuggestion()
        {
            // Solicitar para a pessoa escolher ação a sugerir para os monstros em batalha
        }

        public void SendSuggestion()
        {
            //Player List Suggestions
            //Mandar aos monstros
        }
    }
}