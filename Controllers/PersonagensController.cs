using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoDBZ.Data;
using ProjetoDBZ.Models;

namespace ProjetoDBZ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    // Cria a classe PersonagensController que herda de ControllerBase, que é a classe base para controladores de API no ASP.NET Core.
    public class PersonagensController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PersonagensController(AppDbContext appDbContext)
        {
            // O construtor da classe PersonagensController recebe uma instância de AppDbContext como parâmetro.
            // Permite que o controlador acesse o contexto do banco de dados para realizar operações de CRUD (Create, Read, Update, Delete) na tabela DBZ.
            _appDbContext = appDbContext;

        }


        [HttpPost]
            public async Task<IActionResult> AddPersonagem([FromBody] Personagem personagem)
            {
                
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                // Puxa a Funçao Add do DbSet DBZ, que adiciona o objeto personagem ao contexto do banco de dados.
                // Em seguida, chama o método SaveChangesAsync para salvar as alterações no banco de dados de forma assíncrona.
                // Assíncrono significa que a operação pode ser executada em segundo plano, 
                // permitindo que o aplicativo continue respondendo a outras solicitações enquanto aguarda a conclusão da operação de salvamento.
                // DBZ é o nome da tabela no banco de dados que foi definida no AppDbContext.cs.
                // Db context é a classe que representa o contexto do banco de dados e é responsável por gerenciar as entidades e suas operações no banco de dados.
                // _appDbContext é uma instância do AppDbContext que foi injetada no controlador por meio do construtor.
                _appDbContext.DBZ.Add(personagem);
                await _appDbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetPersonagemById), new { id = personagem.Id }, personagem);
            }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Personagem>>> GetPesonagem()
        {
            // Puxa a Funçao ToListAsync do DbSet DBZ, que retorna uma lista de todos os objetos Personagem presentes na tabela DBZ do banco de dados.
            // Em seguida, chama o método ToListAsync para converter o resultado em uma lista de forma assíncrona.
            var personagens = await _appDbContext.DBZ.ToListAsync();
            return Ok(personagens);
        }

        [HttpGet("{id}")]
        // O método GetPersonagemById é um endpoint de API que recebe um parâmetro id na URL e retorna o personagem correspondente do banco de dados.
        public async Task<IActionResult> GetPersonagemById(int id)
        {
            var personagem = await _appDbContext.DBZ.FindAsync(id);
            if (personagem == null)
            {
                return NotFound("Personagem não encontrado");
            }
            return Ok(personagem);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdatePersonagem(int id, [FromBody] Personagem personagemAtualizado)
        {
            var personagemExistente = await _appDbContext.DBZ.FindAsync(id);
            if (personagemExistente == null)
            {
                return NotFound("Personagem não encontrado");
            }
            _appDbContext.Entry(personagemExistente).CurrentValues.SetValues(personagemAtualizado);
            await _appDbContext.SaveChangesAsync();
            return StatusCode(201, personagemExistente);


        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonagem(int id)
        {
            var personagem = await _appDbContext.DBZ.FindAsync(id);
            if (personagem == null)
            {
                return NotFound("Personagem não encontrado");
            }
            _appDbContext.DBZ.Remove(personagem);
            await _appDbContext.SaveChangesAsync();
            return Ok("Personagem deletado com sucesso");
        }

    }
}