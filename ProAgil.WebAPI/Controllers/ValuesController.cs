using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAgil.WebAPI.Model;

namespace ProAgil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public Evento[] eventos { get; set; }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Evento>> Get()
        {
            Carregar();
            return eventos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Evento> Get(int id)
        {
            Carregar();
            return eventos.FirstOrDefault(x => x.EventoId == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private void Carregar()
        {
            eventos =  eventos = new Evento[]{
                new Evento(){
                    EventoId = 1,
                    Tema = "Angular e .Net Core",
                    Local = "Presidente Prudente",
                    Lote = "1° Lote",
                    QtdPessoas = 150,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                },
                new Evento(){
                    EventoId = 2,
                    Tema = "Angular e suas novidades",
                    Local = "Presidente Prudente",
                    Lote = "2° Lote",
                    QtdPessoas = 350,
                    DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
                }
            };
        }
    }
}
