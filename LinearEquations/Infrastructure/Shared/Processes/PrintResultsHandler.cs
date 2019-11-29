using System;
using System.Collections.Generic;
using System.Text;

namespace LinearEquations.Infrastructure.Shared.Processes
{
    public class PrintResultsHandler : BaseHandler
    {
        public override ContextHandler Handle(ContextHandler request)
        {
            if (!request.Errors)
            {
           
                request.Result += Environment.NewLine;
                request.Result += Environment.NewLine;
                request.Result += "RESULT";
                for (int currentRow = 0; currentRow < request.AugmentedMatrix.NumberOfRows; currentRow++)
                {
                    request.Result += Environment.NewLine + "x" + (currentRow+1) + " = " +
                        request.AugmentedMatrix.Array[currentRow, request.AugmentedMatrix.NumberOfColums + 1].ToString();
                }
            }

            Console.WriteLine(request.Result);
            return base.Handle(request);
        }
    }
}
