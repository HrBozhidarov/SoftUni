﻿namespace StoreAlbum.App.Models
{
    public class User : BaseModel<string>
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
