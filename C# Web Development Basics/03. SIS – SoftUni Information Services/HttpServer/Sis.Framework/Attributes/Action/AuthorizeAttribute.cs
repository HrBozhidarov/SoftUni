using Sis.Framework.Security;
using System;
using System.Linq;

namespace Sis.Framework.Attributes.Action
{
    public class AuthorizeAttribute : Attribute
    {
        private readonly string[] roles;

        public AuthorizeAttribute()
        {
        }

        public AuthorizeAttribute(params string[] role)
        {
            this.roles = role;
        }

        public bool IsAuthorized(IIdentity identity)
        {
            return IsIdentityRole(identity);
        }

        private bool IsIdentityPresent(IIdentity identity)
        {
            return identity != null;
        }

        private bool IsIdentityRole(IIdentity user)
        {
            if (!IsIdentityPresent(user))
            {
                return false;
            }

            foreach (var role in user.Roles)
            {
                if (user.Roles.Contains(role))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
