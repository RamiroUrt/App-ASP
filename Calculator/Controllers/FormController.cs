using Calculator.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Create() //define una acción que recibe un objeto FormViewModel como parámetro. Este modelo se rellena automáticamente con los datos enviados desde el formulario.
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();//recopila todos los mensajes de error de validación en una lista.
                return Json(new { success = false, errors = errors });// devuelve una respuesta JSON indicando que la solicitud no fue exitosa y proporciona los mensajes de error.
            }
            return Json(new { success = true, data = model });//si el modelo es válido, se devuelve una respuesta JSON indicando que la solicitud fue exitosa y se incluyen los datos del modelo en la respuesta.
        }
    }
}
