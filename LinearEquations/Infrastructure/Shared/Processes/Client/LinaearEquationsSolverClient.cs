using LinearEquations.Infrastructure.Shared.Interfaces;
using LinearEquations.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinearEquations.Infrastructure.Shared.Processes.Client
{
    public class LinaearEquationsSolverClient : ILinaearEquationsSolverClient
    {
        public bool Execute(string coefficients, string constants)
        {
            try
            {
                var contextHandler = new ContextHandler();
                contextHandler.AugmentedMatrix = Matrix.CreateAugmentedMAtrix(coefficients, constants);
                var backwardElimininationHandler = new BackwardEliminationHandler();
                var checkIfThereIsSolutionHandler = new CheckIfSolutionHandler();
                var forwardEliminationHandler = new FowardEliminationHandler();
                var printResultsHandler = new PrintResultsHandler();
                var formatEquationHandler = new FormatEquationHandler();
                formatEquationHandler
                    .SetNext(forwardEliminationHandler)
                    .SetNext(checkIfThereIsSolutionHandler)
                    .SetNext(backwardElimininationHandler)
                    .SetNext(printResultsHandler);
                formatEquationHandler.Handle(contextHandler);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().Message);
                return false;
            }

        }
    }
}
