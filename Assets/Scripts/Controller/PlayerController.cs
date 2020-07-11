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

        public void SendSuggestion()
        {
            //Player List Suggestions
            //Mandar aos monstros
        }
    }
}