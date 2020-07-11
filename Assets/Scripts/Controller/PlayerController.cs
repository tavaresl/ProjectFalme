using Assets.Scripts.Domain;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class PlayerController : MonoBehaviour
    {
        public Player Player { get; set; }

        public void Init(Player player)
        {
            Player = player;
        }

        public void Update()
        {
            //GET SUGGESTION
        }

        public bool HasPickedSuggestion()
        {
            // Retorna se a pessoa já selecionou uma sugestão
            return true;
        }

        public void SendSuggestion()
        {
            //Player List Suggestions
            //Mandar aos monstros
        }
    }
}