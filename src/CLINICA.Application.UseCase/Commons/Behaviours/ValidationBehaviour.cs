using CLINICA.Application.UseCase.Commons.Base;
using FluentValidation;
using MediatR;

using ValidateException = CLINICA.Application.UseCase.Commons.Exceptions.ValidationExceptions;

namespace CLINICA.Application.UseCase.Commons.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validatorResult = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));

                var failures = validatorResult
                    .Where(x => x.Errors.Any())
                    .SelectMany(x => x.Errors)
                    .Select(x => new BaseError()
                    {
                        PropertyName = x.PropertyName,
                        ErrorMessage = x.ErrorMessage
                    }) .ToList();
                if (failures.Any())
                {
                    throw new ValidateException(failures);
                }
            }
            return await next();
        }
    }
}
