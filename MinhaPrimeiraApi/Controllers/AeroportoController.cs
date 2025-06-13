using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Contracts.Services;
using MinhaPrimeiraApi.Response;
using MinhaPrimeiraApi.Response.Aeroporto;

namespace MinhaPrimeiraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AeroportoController : ControllerBase
    {

        private IAeroportoService _service;

        public AeroportoController(IAeroportoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<AeroportoGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AeroportoEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(AeroportoInsertDTO aeroporto)
        {
            return Ok(await _service.Post(aeroporto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(AeroportoEntity aeroporto)
        {
            return Ok(await _service.Update(aeroporto));
        }
    }
}