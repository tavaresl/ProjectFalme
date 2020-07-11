using System;
using System.Collections.Generic;
using Assets.Scripts.Domain.Humours;

namespace Assets.Scripts.Domain
{
    public class MonsterFactory
    {
        public Monster CreateRandom()
        {
            int health = new Random().Next(0, 101);
            int strength = new Random().Next(0, 11);
            int defense = new Random().Next(0, 11);
            int speed = new Random().Next(0, 5);

            List<IHumour> humours = new List<IHumour>
            {
                new Aggressive(),
                new Contrarian(),
                new Pacifist()
            };



            throw new NotImplementedException();
        }
    }
}