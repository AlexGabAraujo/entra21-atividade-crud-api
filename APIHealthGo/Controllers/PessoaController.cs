using APIHealthGo.Contracts.Service;
using APIHealthGo.Response;
using APIHealthGo.Services;
using atividade_bd_csharp.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFirstCRUD.DTO;
using MyFirstCRUD.Repository;

namespace APIHealthGo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PessoaController : ControllerBase
    {
        private IPessoaService _service;

        public PessoaController(IPessoaService pessoaService)
        {
            _service = pessoaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllPessoa());
        }


        [HttpGet("(id)")]
        public async Task<IActionResult> GetPessoaById(int id)
        {
            return Ok(await _service.GetPessoaById(id));
        }

        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(PessoaInsertDTO pessoa)
        {
            return Ok(await _service.Post(pessoa));
        }

        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(PessoaEntity pessoa)
        {
            return Ok(await _service.Update(pessoa));
        }

        [HttpDelete("(id)")]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

    }
}
