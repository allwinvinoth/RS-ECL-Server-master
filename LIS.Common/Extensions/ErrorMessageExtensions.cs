using System;
using System.Collections.Generic;
using System.Linq;
using LIS.Common.Models;
using FluentValidation.Results;

namespace LIS.Common.Extensions
{
    public static class ErrorMessageExtensions
    {
        public static IEnumerable<ValidationError> ToValidationErrors(this IEnumerable<ValidationFailure> validationFailures)
        {
            if (validationFailures == null) throw new ArgumentNullException(nameof(validationFailures));

            return validationFailures.Select(validationFailure => new ValidationError
            { ErrorMessage = validationFailure.ErrorMessage, PropertyName = validationFailure.PropertyName });
        }
    }
}