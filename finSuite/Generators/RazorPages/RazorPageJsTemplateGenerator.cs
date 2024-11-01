using System.Text;

namespace finSuite.Generators.RazorPages
{
    public class RazorPageJsTemplateGenerator
    {
        public string GenerateRazorPageJsTemplate()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("export class FileCleanup");
            sb.AppendLine("{");
            sb.AppendLine("    static clearInputFiles()");
            sb.AppendLine("    {");
            sb.AppendLine("        var fileInputs = document.querySelectorAll(\"input[type='file'].file-input\");");
            sb.AppendLine("        for (var i = 0; i < fileInputs.length; i++)");
            sb.AppendLine("        {");
            sb.AppendLine("            fileInputs[i].value = null;");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            sb.AppendLine("");
            sb.AppendLine("window.FileCleanup = FileCleanup;");

            return sb.ToString();
        }

    }
}
