using System.Collections.Generic;

namespace Sis.Demo.ViewModels
{
    public class SampleViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public IEnumerable<NestedViewModel> NestedViewModels { get; set; }
    }
}
