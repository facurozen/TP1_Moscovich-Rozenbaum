using Pizzas.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Pizzas.API.Controllers
{

    [ApiController]

    [Route("api/[controller]")]

    public class PizzasController : ControllerBase
    {

        [HttpGet]

        public IActionResult GetAll()
        {

            IActionResult respuesta;

            List<Pizza> listaPizzas;

            listaPizzas = BD.GetAll();

            respuesta = Ok(listaPizzas);

            return respuesta;

        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            IActionResult respuesta = null;

            Pizza objPizza;

            objPizza = BD.GetById(id);

            if (objPizza == null)
            {

                respuesta = NotFound();

            }
            else
            {

                respuesta = Ok(objPizza);

            }

            return respuesta;

        }

        [HttpPost]

        public IActionResult Create(Pizza pizza)
        {
            int cambiosAfectados;
            cambiosAfectados = BD.Craete(pizza);

            return CreatedAtAction(nameof(Create), new { id = pizza.id }, pizza);

        }

        [HttpPut("{id}")]

        public IActionResult Update(int id, Pizza pizza)
        {
            IActionResult respuesta = null;

            Pizza objPizza;

            int cambiosAfectados;

            if (id != pizza.id)
            {
                respuesta = BadRequest();
            }
            else
            {
                objPizza = BD.GetById(id);

                if (objPizza == null)
                {
                    respuesta = NotFound();
                }
                else
                {
                    cambiosAfectados = BD.Update(id, pizza);

                    if (cambiosAfectados > 0)
                    {
                        respuesta = Ok(pizza);
                    }
                    else
                    {
                        respuesta = NotFound();
                    }
                }
            }
            return respuesta;
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteById(int id)
        {
            IActionResult respuesta = null;

            Pizza objPizza;

            int cambiosAfectados;

            objPizza = BD.GetById(id);

            if (objPizza == null)
            {
                respuesta = NotFound();
            }
            else
            {
                cambiosAfectados = BD.DeleteById(id);

                if (cambiosAfectados > 0)
                {
                    respuesta = Ok(objPizza);
                }
                else
                {
                    respuesta = NotFound();
                }
            }
            return respuesta;
        }
    }
}