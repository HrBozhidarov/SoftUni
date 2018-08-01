using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoShare.Client.Utilities
{
    public class ValidateInputParameters
    {
        public static void Validator(Type type,int dataLength,int size)
        {
            var commandClassFullName = type.Name.SkipLast(7).ToArray();

            var commandClass = new string(commandClassFullName);

            if (dataLength != size)
            {
                throw new InvalidOperationException($"Command {commandClass} not valid!");
            }
        }
    }
}
