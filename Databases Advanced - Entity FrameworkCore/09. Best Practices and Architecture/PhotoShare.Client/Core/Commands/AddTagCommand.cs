using PhotoShare.Client.Core.Contracts;
using PhotoShare.Services.Contracts;
using PhotoShare.Client.Utilities;
using System;
using System.Linq;

namespace PhotoShare.Client.Core.Commands
{
    public class AddTagCommand : ICommand
    {
        private ITagService tagService;
        private readonly IUserSessionService userSessionService;

        public AddTagCommand(ITagService tagService, IUserSessionService userSessionService)
        {
            this.tagService = tagService;
            this.userSessionService = userSessionService;
        }

        public string Execute(string[] data)
        {
            ValidateInputParameters.Validator(typeof(AddTagCommand), data.Length, 1);

            if (!userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var tagName = data[0].ValidateOrTransform();

            if (this.tagService.Exists(tagName))
            {
                throw new ArgumentException($"Tag {tagName} exists!");
            }

            var tag = this.tagService.AddTag(tagName);

            return $"Tag {tag.Name} was added successfully!";
        }
    }
}
