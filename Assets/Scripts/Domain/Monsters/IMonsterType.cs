using System;
using UnityEngine;

namespace Assets.Scripts.Domain.Monsters
{
    public interface IMonsterType
    {
        int AddVulnerability(MonsterType attackerType);

        MonsterType GetMonsterType();

        Color GetColor();
    }
}