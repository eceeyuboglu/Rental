using FluentValidation;

namespace Core.CrossCuttingConcers.Validation
{
    public class ValidationTool
    {
        public static class ValidationToolMethod
        {
            public static void Validate(IValidator validator, object entity)
            {
                var context = new ValidationContext<object>(entity);
                var result = validator.Validate(context);
                if (!result.IsValid)
                {
                    throw new ValidationException(result.Errors);
                }
            }
        }
    }
}
