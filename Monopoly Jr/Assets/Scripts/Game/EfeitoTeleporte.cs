namespace Game
{
    public class EfeitoTeleporte : Efeito
    {
        private int destino;

        public EfeitoTeleporte(int destino)
        {
            this.destino = destino;
        }

        public async void RealizarEfeito()
        {
            await TeleportarJogador(destino);
        }
        private async Task TeleportarJogador(int destino)
        {
            await Tabuleiro.GetInstance().JogadorAtual().Teleportar(destino);
        }
    }
}