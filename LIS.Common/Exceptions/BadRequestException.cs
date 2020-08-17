using System;
using LIS.Common.Models;

namespace LIS.Common.Exceptions
{
    public sealed class BadRequestException : Exception
    {
        public ValidationError Error { get; }

        public BadRequestException(ValidationError error)
        {
            this.Error = error;
        }
    }
}