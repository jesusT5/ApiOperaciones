using Microsoft.AspNetCore.Mvc;

namespace ApiOperaciones.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperacionesController : ControllerBase
    {
        // GET: OperacionesController
        public ActionResult Get()
        {
            return Ok("Api operaciones por parametro");
        }

        // POST: OperacionesController/calcular
        //es necesario realizar el encodeuricomponent desde el cliente ya que el signo de "+"...
        //es un caracter UNESCAPED
        //o la otra opcion es definir las operaciones por texto (suma,resta,multiplicacion,division)
        [HttpPost("calcular")]
        public ActionResult Calcular(string parametro1, string parametro2, char? operacion)
        {
            try
            {
                if (string.IsNullOrEmpty(parametro1)) return BadRequest("Ingresar parametro 1");

                if (string.IsNullOrEmpty(parametro2)) return BadRequest("Ingresar parametro 2");

                var valor1 = decimal.Parse(parametro1);
                var valor2 = decimal.Parse(parametro2);
                switch (operacion)
                {
                    case '+':
                        return Ok(valor1 + valor2);
                    case '-':
                        return Ok(valor1 - valor2);
                    case '*':
                        return Ok(valor1 * valor2);
                    case '/':
                        return Ok(valor1 / valor2);
                    default:
                        return BadRequest("Operador valido + - * /");
                }
            }
            catch (System.Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }


    }
}
