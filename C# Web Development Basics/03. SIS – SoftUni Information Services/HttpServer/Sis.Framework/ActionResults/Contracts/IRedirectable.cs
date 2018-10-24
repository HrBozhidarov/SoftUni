namespace Sis.Framework.ActionResults.Contracts
{
    public interface IRedirectable : IActionResult
    {
        string RedirectUrl { get;  }
    }
}
