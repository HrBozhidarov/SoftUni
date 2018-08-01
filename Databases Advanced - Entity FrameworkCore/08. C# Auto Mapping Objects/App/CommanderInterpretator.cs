using AutoMappingObjectsExercice.App.Commands;
using AutoMappingObjectsExercice.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappingObjectsExercice.App
{
    public class CommanderInterpretator
    {
        public ICommand ReturnCommand(string command)
        {
            var type = Type.GetType("AutoMappingObjectsExercice.App.Commands." + command + "Command");

            var instance = (ICommand)Activator.CreateInstance(type, new object[] { });

            return instance;
        }
    }
}
