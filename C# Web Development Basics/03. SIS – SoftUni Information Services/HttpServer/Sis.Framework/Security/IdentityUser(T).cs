namespace Sis.Framework.Security
{
    using System;
    using System.Collections.Generic;

    public class IdentityUserT<TKey> : IIdentity 
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }

        public  virtual string Username {get; set; }
     
        public  virtual string Password {get; set; }
      
        public  virtual string Email {get; set; }
              
        public  virtual bool IsValid {get; set; }

        public virtual IEnumerable<string> Roles { get; set; } = new HashSet<string>();
    }
}
