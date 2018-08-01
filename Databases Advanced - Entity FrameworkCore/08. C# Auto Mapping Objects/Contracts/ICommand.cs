using AutoMappingObjectsExercice.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappingObjectsExercice.Contracts
{
    public interface ICommand
    {
        void Execute(EmployeeContext context, params string[] args);
    }
}
