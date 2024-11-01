using System.Text;
using finSuite.InputClasses;

namespace finSuite.Helpers
{
    public class AbpPageHeaderHelper
    {
        public static string CreatePageHeaderTemplate(ClassDatas classDatas, string folderName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("@* ************************* PAGE HEADER ************************* *@");
            sb.AppendLine($"<PageHeader Title=\"@L[\"{folderName}\"]\" BreadcrumbItems=\"BreadcrumbItems\" Toolbar=\"Toolbar\">");
            sb.AppendLine("");
            sb.AppendLine("</PageHeader>");
            sb.AppendLine("");

            return sb.ToString();

        }

        public static string CreatePageHeaderTemplate(CreatedClassDatas classDatas, string folderName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("@* ************************* PAGE HEADER ************************* *@");
            sb.AppendLine($"<PageHeader Title=\"@L[\"{folderName}\"]\" BreadcrumbItems=\"BreadcrumbItems\" Toolbar=\"Toolbar\">");
            sb.AppendLine("");
            sb.AppendLine("</PageHeader>");
            sb.AppendLine("");

            return sb.ToString();

        }



    }
}
