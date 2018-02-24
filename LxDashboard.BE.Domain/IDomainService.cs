using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.BE.Domain
{
    public class ValidationResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
    }

    public interface IDomainService<T>
    {
        ValidationResult Validate(T validationObject); 
    }


}
