using CLINICA.Application.UseCase.Commons.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.Application.UseCase.Commons.Exceptions
{
    public class ValidationExceptions : Exception
    {
        public IEnumerable<BaseError>Errors { get; set; }

        public ValidationExceptions() 
        {
           Errors = new List<BaseError>();
        }

        public ValidationExceptions(IEnumerable<BaseError> errors): this()
        {
            Errors = errors;
        }
    }
}
