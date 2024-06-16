

using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Models.Views
{
    public class FormViewModel
    {
        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [MinLength(5, ErrorMessage = "El nombre debe tener máximo 5 caracteres")]
        [MaxLength(15, ErrorMessage = "El nombre debe tener máximo 10 caracteres")]
        [CharacterCount(10, ErrorMessage = "El nombre debe tener máximo 10 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Por favor ingrese una contraseña.")]
        [RegularExpression(@"^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$", ErrorMessage = "La contrase�a debe tener entre 8 y 16 caracteres, al menos un d�gito, al menos una min�scula y al menos una may�scula.")]
        public string Clave { get; set; }


        [Required(ErrorMessage = "Por favor repetir contraseña.")]
        [RegularExpression(@"^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$", ErrorMessage = "La contrase�a debe tener entre 8 y 16 caracteres, al menos un d�gito, al menos una min�scula y al menos una may�scula.")]
        public string RepeatPassword { get; set; }


        [Required(ErrorMessage = "Por favor indique su email.")]
        [EmailAddress(ErrorMessage = "Formato incorrecto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo apellido es requerido.")]
        [MaxLength(10, ErrorMessage = "El apellido debe tener máximo 10 caracteres")]
        [MinLength(5, ErrorMessage = "El apellido debe tener m�nimo 5 caracteres")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Por favor seleccione una ciudad.")]
        public string? Country { get; set; }

        [Required(ErrorMessage = "Por favor indique su cp.")]
        public int CP { get; set; }
        public string __RequestVerificationToken { get; set; }//maneja el Token generado por el form 

        [Required(ErrorMessage = "Este campo es requerido d.")]
        public string Default { get; set; }
        /*

        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Default1 { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Default2 { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Default3 { get; set; }
        */
    }
}

