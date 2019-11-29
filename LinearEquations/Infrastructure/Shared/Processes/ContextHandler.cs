using LinearEquations.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinearEquations.Infrastructure.Shared.Processes
{
    public class ContextHandler
    {
        public Matrix AugmentedMatrix { get; set; }
        public bool Errors { get; set; }
        public string Result { get; set; }
    }
}
