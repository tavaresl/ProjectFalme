using Assets.Scripts.Controller.BattleState;

namespace Assets.Scripts.Domain
{
    public class Battle
    {
        public Player Player { get; set; }
        public Player Enemy { get; set; }
        private int TurnCounter { get; set; }

        public void Init()
        {
            Player = new Player();
            Player.Init();
            Enemy = new Player();
            Enemy.Init();
            TurnCounter = 0;
        }

        public Player IsOver()
        {
            if (!Player.CanKeepFighting())
                return Enemy;

            if (!Enemy.CanKeepFighting())
                return Player;

            return null;
        }
    }


    // Devaneio do kevyn: monstro rebelde pode atacar diretamente o jogador inimigo, ação não disponível para o jogador sugerir
    // To think about: jogadores terão pontos de vida?
}

