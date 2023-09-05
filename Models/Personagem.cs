using RpgApi.Models.Enuns;

namespace RpgApi.Models
{
    public class Personagem
    {
        public int Id { get; set; } // o int já começa valendo zero
        public string Nome { get; set; } = string.Empty; //quando eu declaro uma string ela é NULA, então preciso inicializar a variável
        public int PontosVida { get; set; }
        public int Forca { get; set; }
        public int Defesa { get; set; }
        public int Inteligencia { get; set; }
        public ClasseEnum Classe { get; set; } // tem que referenciar lá em cima no "using"
    }
}