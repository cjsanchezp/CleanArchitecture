﻿using FluentValidation.Results;

namespace CleanArchitecture.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException() : base($"Se presentaron uno o mas errores de validacion")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e=> e.ErrorMessage)
                .ToDictionary(failuregroup => failuregroup.Key, failuregroup => failuregroup.ToArray());
        }


        public IDictionary<string, string[]> Errors { get;}
    }
}
