using UnityEngine;

namespace Assets.Scripts.Domain
{
    public class Monster : MonoBehaviour
    {
        public new string name;
    
        [Range(0, 100)]
        public int health;

        [Range(0,10)]
        public int strength;

        [Range(0,10)]
        public int defense;

        [Range(0,5)]
        public int speed;
        public MonsterType type;
        public Humour humour;

        public void PickAction(Suggestion suggestion)
        {
            // TODO: Implementar lógica de seleção de ação baseada no temperamento do monstro
        }
    }

    public enum MonsterType
    {
        Summer,
        Fall,
        Winter,
        Spring,
        Catlike,
    }
}