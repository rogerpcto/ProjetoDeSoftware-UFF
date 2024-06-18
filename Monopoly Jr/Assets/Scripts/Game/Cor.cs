namespace Game
{
    public enum Cor
    {
        AMARELO,
        AZUL_CLARO,
        AZUL_ESCURO,
        LARANJA,
        MARROM,
        VERDE,
        VERMELHO,
        ROSA
    }
    public static class CorExtensions
    {
        public static string GerarHex(this Cor cor)
        {
            return cor switch
            {
                Cor.AMARELO => "#FFDC00",
                Cor.AZUL_CLARO => "#75C2FA",
                Cor.AZUL_ESCURO => "#0025FF",
                Cor.LARANJA => "#FF8100",
                Cor.MARROM => "#904C3A",
                Cor.VERDE => "#00FF27",
                Cor.VERMELHO => "#FF1E00",
                Cor.ROSA => "#FF4C87",
                _ => "#FFFFFF",
            };
        }
    }
}