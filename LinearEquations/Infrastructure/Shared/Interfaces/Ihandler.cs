using LinearEquations.Infrastructure.Shared.Processes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinearEquations.Infrastructure.Shared.Interfaces
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        ContextHandler Handle(ContextHandler request);
    }
}
