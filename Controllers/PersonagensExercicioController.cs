using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using RpgApi.Models.Enuns;


namespace AULA04DS_API_master.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensExercicioController : ControllerBase
    {
        private static List<Personagem> personagens = new List<Personagem>()
        {
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            Personagem buscaPersonagem = personagens.Find(p => p.Nome == nome);
            if(buscaPersonagem != null)
            {
                return Ok(buscaPersonagem);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao(Personagem personagem)
        {
            if(personagem.Defesa < 10 || personagem.Inteligencia > 30 )
            {
                return BadRequest("Defesa não pode ser menor que 10 ou Inteligencia não pode ser maior que 30");
            }
            personagens.Add(personagem);
            return Ok(personagem);
        }

        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago(Personagem personagem)
        {
            if(personagem.Classe != ClasseEnum.Mago || personagem.Inteligencia < 35)
            {
                return BadRequest("Magos não podem ser inseridos com Inteligencia menor que 35");
            }
            personagens.Add(personagem);
            return Ok(personagem);
        }

        [HttpGet("GetClerigoMago")]
        public IActionResult GetClerigoMago()
        {
            List<Personagem> buscaPersonagem = personagens.FindAll(p => p.Classe != ClasseEnum.Cavaleiro);
            
            return Ok(buscaPersonagem.OrderByDescending(p => p.PontosVida));
        }

        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
            int qtd = personagens.Count();
            int inteligencia = personagens.Sum(p => p.Inteligencia);
            return Ok($"Existem {qtd} personagems e a inteligencia total é {inteligencia}");
        }

        [HttpGet("GetByClasse/{id}")]
        public IActionResult GetByClasse(int id)
        {
            ClasseEnum ClasseId = (ClasseEnum)id;

            List<Personagem> buscaPersonagem = personagens.FindAll(p => p.Classe == ClasseId);
            
            return Ok(buscaPersonagem);
        }


























    }
}