using AutoMappingObjectsExercice.Contracts;
using AutoMappingObjectsExercice.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappingObjectsExercice.App.Commands
{
    public class ExitCommand : ICommand
    {
        public void Execute(EmployeeContext context, params string[] args)
        {
            Environment.Exit(0);
        }
    }
}
