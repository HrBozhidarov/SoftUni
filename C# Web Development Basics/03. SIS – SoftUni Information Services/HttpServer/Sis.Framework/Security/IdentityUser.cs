namespace Sis.Framework.Security
{
    using System;

    public class IdentityUser : IdentityUserT<string>
    {
        public IdentityUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
