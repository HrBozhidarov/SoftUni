namespace Sis.Framework.Views
{
    using ActionResults.Contracts;
    using Http.Common;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class View : IRenderable
    {
        private readonly string fullQualifiedTemplateName;
        private readonly IDictionary<string, object> viewData;

        public View(string fullQualifiedTemplateName, IDictionary<string, object> viewData)
        {
            this.fullQualifiedTemplateName = MvcContext.Get.RootDirectoryRelativePath + fullQualifiedTemplateName + GlobalConstants.HtmlFileExtension;

            this.viewData = viewData;
        }

        private string ReadFile(string fullQualifiedTemplateName)
        {
            var fileString = string.Empty;

            try
            {
                fileString = File.ReadAllText(fullQualifiedTemplateName);
            }
            catch
            {
                throw new FileNotFoundException();
            }

            return fileString;
        }

        public string Render()
        {
            var fullHtml = this.ReadFile(this.fullQualifiedTemplateName);
            var renderedHtml = this.RenderHtml(fullHtml);
            return fullHtml;
        }

        private string RenderHtml(string fullHtml)
        {
            var renderedHtm = fullHtml;

            if (this.viewData.Any())
            {
                foreach (var parameter in this.viewData)
                {
                    renderedHtm = renderedHtm.Replace($"{{{{{{{parameter.Key}}}}}}}", parameter.Value.ToString());
                }
            }

            return renderedHtm;
        }
    }
}
