﻿namespace Sis.Framework.ActionResults.Contracts
{
    public interface IViewable : IActionResult
    {
        IRenderable View { get; set; }
    }
}
