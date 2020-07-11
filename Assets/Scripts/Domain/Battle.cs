namespace Assets.Scripts.Domain
{
    public class Battle
    {
        public Player Player { get; set; }
        public Player Enemy { get; set; }
        public Phase CurrentPhase { get; set; }
        private int TurnCounter { get; set; }

        public void Init()
        {
            CurrentPhase = Phase.Draft;
            Player.Init();
            Enemy.Init();
            TurnCounter = 0;
        }

        public Player IsBattleOver()
        {
#warning TODO: implementar, retornar vencedor, ou null
            return null;
        }
        
    }

    // Devaneio do kevyn: monstro rebelde pode atacar diretamente o jogador inimigo, ação não disponível para o jogador sugerir
    // To think about: jogadores terão pontos de vida?
    public enum Phase
    {
        Draft,              // Jogador escolhe os monstros para colocar em batalha
        //--------- Loop Start --------//
        ActionSuggestion,   // Jogador sugere uma ação para o monstro em batalha
        ActionPick,         // Monstro decide qual ação tomar baseado no seu temperamento e na sugestão recebida
        MonsterSort,        // Ordenar os monstros em batalha para definir ordem de ataque 
        DamageCount,        // Contabilizar o dano causado por cada monstro no adversário e subtrair da vida de cada um deles
        MonsterDeathCheck,  // Verifica se um dos monstros em batalha pereceu
        BattleOverCheck,    // Verifica se um dos jogadores não possui mais monstros disponíveis
        //--------- Loop End --------//
        BattleOver,         // Todos os monstros de um jogador pereceram
    }
}

