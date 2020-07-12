using System.Collections.Generic;
using Assets.Scripts.Domain;
using Assets.Scripts.Domain.Humours;
using Assets.Scripts.Domain.Monsters;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Controller
{
    public class MonsterSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _monsterPrefab;

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

            int health = new Random().Next(0, 101);
            int strength = new Random().Next(0, 11);
            int defense = new Random().Next(0, 11);
            int speed = new Random().Next(0, 5);
            string name = names[new Random().Next(0, names.Count)];
            Humour humour = humours[new Random().Next(0, humours.Count)];
            IMonsterType type = monsterTypes[new Random().Next(0, monsterTypes.Count)];

            Monster monster = new Monster
            {
                Strength = strength,
                Defense = defense,
                Health = health,
                Speed = speed,
                Type = type,
                Humour = humour,
                Name = name
            };

            var prefabInstance = Instantiate(_monsterPrefab);
            prefabInstance.GetComponent<MonsterController>().Init(monster);

            return prefabInstance;
        }
    }
}