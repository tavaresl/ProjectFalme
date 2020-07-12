using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Controller;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.Helpers;

public class GameOverPanelController : MonoBehaviour
{
    [SerializeField]
    public BattleController BattleController;

    public void OnPlayAgainClick()
    {
        if (RNG.GetRandom().Next(0, 10) > 2)
            BattleController.ReloadBattle();
        else
            BattleController.Quit();
    }
}
