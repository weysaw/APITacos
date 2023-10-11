using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APITacos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacosController : ControllerBase
    {
        private readonly List<string> _tacos = new() { "taco de asada", "taco de pastor" };

        private class RespuestaEndpoint 
        {
            public string Mensaje { get; set; }
            public RespuestaEndpoint(string mensaje)
            {
                Mensaje = mensaje;
            }
        }

        // GET: api/<TacosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _tacos;
        }

        // GET api/<TacosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                return _tacos[id];
            }
            catch 
            {
                return "";
            }
        }

        // POST api/<TacosController>
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            _tacos.Add(value);
            return Ok(new RespuestaEndpoint("Taco agregado con exito"));
        }

        // PUT api/<TacosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            try
            {
                _tacos[id] = value;
                return Ok(new RespuestaEndpoint("Modificacion de taco con exito"));
            }
            catch
            {
                return NotFound(new RespuestaEndpoint("Taco no encontrado"));
            }
        }

        // DELETE api/<TacosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _tacos.RemoveAt(id);
                return Ok(new RespuestaEndpoint("Eliminacion de taco con exito"));
            }
            catch
            {
                return NotFound(new RespuestaEndpoint("Taco no encontrado"));
            }
        }
    }
}
