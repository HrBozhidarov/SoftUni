namespace Sis.Http.Sessions
{
    using Common;
    using Contracts;
    using System.Collections.Generic;

    public class HttpSession : IHttpSession
    {
        private readonly IDictionary<string, object> parameters;

        public HttpSession(string id)
        {
            this.Id = id;

            this.parameters = new Dictionary<string, object>();
        }

        public string Id { get; }

        public void AddParameter(string key, object parameter)
        {
            Validator.ValidationForNull(key, nameof(key));
            Validator.ValidationForNull(parameter, nameof(parameter));

            this.parameters[key] = parameter;
        }

        public void ClearParameters()
        {
            this.parameters.Clear();
        }

        public bool ContainsParameter(string key)
        {
            Validator.ValidationForNull(key, nameof(key));

            return this.parameters.ContainsKey(key);
        }

        public object GetParameter(string key)
        {
            Validator.ValidationForNull(key, nameof(key));

            if (!this.parameters.ContainsKey(key))
            {
                return null; 
            }

            return this.parameters[key];
        }
    }
}
