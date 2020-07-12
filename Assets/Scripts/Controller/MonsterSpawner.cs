using System.Collections.Generic;
using Assets.Scripts.Domain;
using Assets.Scripts.Domain.Humours;
using Assets.Scripts.Domain.Monsters;
using Assets.Scripts.Helpers;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Assets.Scripts.Controller
{
    public class MonsterSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _monsterPrefab;
        [SerializeField]
        private List<Sprite> MonsterSprites;
        //Random é baseado no relógio, isso é necessário para evitar resultados repetidos.
        private static Random rand = RNG.GetRandom();

        public GameObject Spawn()
        {
            List<Humour> humours = new List<Humour>
            {
                new Aggressive(),
                new Contrarian(),
                new Pacifist(),
                new Lazy(),
                new Rebel(),
                new Obedient()
            };

            List<IMonsterType> monsterTypes = new List<IMonsterType>
            {
                new FallType(),
                new SpringType(),
                new SummerType(),
                new WinterType()
            };
            List<string> names = new List<string>
            {
                "Seu Bezerro",
                "Milkshake",
                "Zé",
                "Fubanga",
                "Fuleco",
                "Enel"
            };

            int health = rand.Next(5, 11);
            int strength = rand.Next(0, 11);
            int defense = rand.Next(0, 11);
            int speed = rand.Next(0, 5);
            string name = names[rand.Next(0, names.Count)];
            Humour humour = humours[rand.Next(0, humours.Count)];
            IMonsterType type = monsterTypes[rand.Next(0, monsterTypes.Count)];

            Monster monster = new Monster
            {
                Strength = strength,
                Defense = defense,
                Health = health,
                Speed = speed,
                Type = type,
                Humour = humour,
                Name = name,
                HasFled = false
            };

            var prefabInstance = Instantiate(_monsterPrefab);
            prefabInstance.GetComponent<Image>().sprite = MonsterSprites[rand.Next(0, MonsterSprites.Count)];
            prefabInstance.GetComponent<MonsterController>().Init(monster);

            return prefabInstance;
        }
    }
}