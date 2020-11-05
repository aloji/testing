using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aloji.AspNetCore.Testing.Extensions
{
    public static class ValidationResultExtensions
    {
        public static IList<ValidationResult> Validate(this object source)
        {
            var result = new List<ValidationResult>();
            var ctx = new ValidationContext(source, null, null);
            Validator.TryValidateObject(source, ctx, result, true);

            return result;
        }
    }
}
