using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Calculator.Models.Views;
using System;

namespace Calculator.Controllers
{ 
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new CalculatorViewModel());
        }

        [HttpPost]
        public IActionResult Calculate(CalculatorViewModel objCalculator)
        {
            try
            {
                if (objCalculator.Operator1 > int.MaxValue / 2 || objCalculator.Operator2 > int.MaxValue / 2)
                {
                    throw new OverflowException();
                }

                checked
                {
                    switch (objCalculator.Action)
                    {
                        case "+":
                            objCalculator.Response = objCalculator.Operator1 + objCalculator.Operator2;
                            break;
                        case "-":
                            objCalculator.Response = objCalculator.Operator1 - objCalculator.Operator2;
                            break;
                        case "/":
                            if (objCalculator.Operator2 == 0)
                            {
                                ModelState.AddModelError("Operator2", "No se puede dividir por cero.");
                            }
                            else
                            {
                                objCalculator.Response = objCalculator.Operator1 / objCalculator.Operator2;
                            }
                            break;
                        case "*":
                            objCalculator.Response = objCalculator.Operator1 * objCalculator.Operator2;
                            break;
                    }
                }
            }
            catch (OverflowException)
            {
                ModelState.AddModelError(string.Empty, "Los números introducidos son demasiado grandes.");
            }

            return View("Index", objCalculator);
        }
    }
}
