﻿using DomainValidation.Validation;
using System;

namespace WM.SisControleMvc.Domain.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            ValidationResult = new ValidationResult();
        }

        public Guid Id { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public void AdicionarErrroValidacao(string msgErro)
        {
            ValidationResult.Add(new ValidationError(msgErro));
        }

        public abstract bool EhValido();
    }
}
