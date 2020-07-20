using Assets.Scripts.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controller
{
    public class MonsterStatsPanelController : MonoBehaviour
    {
        [SerializeField]
        private Text Name;
        [SerializeField]
        private Text Type;
        [SerializeField]
        private Text Humour;
        [SerializeField]
        private Text Health;
        [SerializeField]
        private Text Strength;
        [SerializeField]
        private Text Defense;
        [SerializeField]
        private Text Speed;


        public void Update(Monster monster)
        {
            Name.text = monster.Name;
            Type.text = monster.Type.GetMonsterType().ToString();
            Type.color = monster.Type.GetColor();
            Humour.text = monster.Humour.Name;
            Health.text = $"{monster.Health}/{monster.MaxHealth}";
            Strength.text = monster.Strength.ToString();
            Defense.text = monster.Defense.ToString();
            Speed.text = monster.Speed.ToString();
        }
    }
}

