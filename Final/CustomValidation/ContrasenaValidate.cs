using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.CustomValidation
{
    public class ContrasenaValidate : Attribute, IModelValidator//Acceder a la interfaz IModelValidator

    {

        public string ErrorMessage { get; set; }

        /// <summary>

        /// Función para la retornar validación - función con inyección de dependencia

        /// </summary>

        /// <param name="context"></param>

        /// <returns></returns>

        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)

        {

            return new List<ModelValidationResult>

                {

                    new ModelValidationResult("", ErrorMessage)

                };

        }

    }
}
