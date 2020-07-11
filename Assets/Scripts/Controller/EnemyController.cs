using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Controller;
using Assets.Scripts.Domain;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public IList<MonsterController> Monsters { get; private set; }
    public Player Enemy { get; private set; }

    public void Draft()
    {
        // Fazer com que o Enemy faça o draft dos monstros que irá usar em batalha
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
