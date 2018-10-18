﻿namespace Sis.Framework.Attributes.Property
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class RegexAttribute : ValidationAttribute
    {
        private readonly string pattern;

        public RegexAttribute(string pattern)
        {
            this.pattern = "^" + pattern + "$";
        }

        public override bool IsValid(object value)
        {
            try
            {
                return Regex.IsMatch(value.ToString(), pattern);
            }
            catch
            {
                return false;
            }
        }
    }
}
