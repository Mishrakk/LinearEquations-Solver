using System;
using System.Collections.Generic;
using System.Text;

namespace LinearEquations.Infrastructure.Shared.Processes
{
    public class FormatEquationHandler : BaseHandler
    {
        public override ContextHandler Handle(ContextHandler request)
        {
            if (!request.Errors && string.IsNullOrWhiteSpace(request.Result))
            {
                for (int currentRow = 0; currentRow < request.AugmentedMatrix.NumberOfRows; currentRow++)
                {
                    for (int currentColumn = 0; currentColumn < request.AugmentedMatrix.NumberOfColums; currentColumn++)
                    {
                        if (currentColumn > 0)
                        {
                            request.Result += request.AugmentedMatrix.Array[currentRow, currentColumn] < 0 ?
                               " " + request.AugmentedMatrix.Array[currentRow, currentColumn].ToString() : " + " + request.AugmentedMatrix.Array[currentRow, currentColumn].ToString();
                            request.Result += "x" + (currentColumn + 1);
                        }
                        else
                        {
                            request.Result += request.AugmentedMatrix.Array[currentRow, currentColumn].ToString() + "x" + (currentColumn + 1);
                        }


                    }

                    request.Result += " = " + request.AugmentedMatrix.Array[currentRow, request.AugmentedMatrix.NumberOfColums].ToString() + Environment.NewLine;
                }
            }
            return base.Handle(request);
        }
    }
}
