using UnityEngine;

namespace Assets.Scripts.Domain
{
    public class Monster
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public int Strength { get; set; }

        public int Defense { get; set; }
        public int Speed { get; set; }
        public MonsterType Type { get; set; }
        public Humour Humour { get; set; }

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