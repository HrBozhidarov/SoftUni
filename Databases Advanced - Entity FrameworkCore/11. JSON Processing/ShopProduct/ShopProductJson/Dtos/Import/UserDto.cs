using System.ComponentModel.DataAnnotations;

namespace ShopProduct.Dtos
{
    public class UserDto
    {
        public string FirstName { get; set; }

        [MinLength(3)]
        public string LastName { get; set; }

        public string Age { get; set; }

        public bool AgeSpecified
        {
            get
            {
                return Age != null;
            }
        }
    }
}
