using System;
using System.Collections.Generic;
using System.Text;

namespace LinearEquations.Infrastructure.Shared.Interfaces
{
    public interface ILinaearEquationsSolverClient
    {
        public bool Execute(string coefficients, string constants);
    }
}