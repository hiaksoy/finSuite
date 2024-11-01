using System.Text;
using finSuite.InputClasses;

namespace finSuite.Helpers
{
    public class DataGridHelper
    {
        public static string CreateDataGridTemplate(ClassDatas classDatas)
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("@* ************************* DATA GRID ************************* *@");
            sb.AppendLine("<Card>");
            sb.AppendLine("    <CardBody>");
            sb.AppendLine($"        <DataGrid TItem=\"{classDatas.ClassName}Dto\"");
            sb.AppendLine($"                  Data=\"{classDatas.ClassName}List\"");
            sb.AppendLine("                  ReadData=\"OnDataGridReadAsync\"");
            sb.AppendLine("                  TotalItems=\"TotalCount\"");
            sb.AppendLine("                  ShowPager=\"true\"");
            sb.AppendLine("                  Responsive=\"true\"");
            sb.AppendLine("                  PageSize=\"PageSize\"");
            sb.AppendLine("                  Class=\"datagrid-detail\">");
            sb.AppendLine("            <LoadingTemplate>");
            sb.AppendLine("                <Row Class=\"w-100 align-items-center\" Style=\"height: 150px;\">");
            sb.AppendLine("                    <Column>");
            sb.AppendLine("                        <RadarSpinner />");
            sb.AppendLine("                    </Column>");
            sb.AppendLine("                </Row>");
            sb.AppendLine("            </LoadingTemplate>");
            sb.AppendLine("            <EmptyTemplate>");
            sb.AppendLine("                <Row Class=\"w-100 align-items-center\" Style=\"height: 150px;\">");
            sb.AppendLine("                    <Column>");
            sb.AppendLine("                        <Heading Size=\"HeadingSize.Is4\" TextAlignment=\"TextAlignment.Center\">@L[\"NoDataAvailable\"]</Heading>");
            sb.AppendLine("                    </Column>");
            sb.AppendLine("                </Row>");
            sb.AppendLine("            </EmptyTemplate>");
            sb.AppendLine("            <DataGridColumns>");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine($"                <DataGridEntityActionsColumn TItem=\"{classDatas.ClassName}Dto\" @ref=\"@EntityActionsColumn\">");
            sb.AppendLine("                    <DisplayTemplate>");
            sb.AppendLine($"                        <EntityActions TItem=\"{classDatas.ClassName}Dto\" EntityActionsColumn=\"@EntityActionsColumn\">");
            sb.AppendLine($"                            <EntityAction TItem=\"{classDatas.ClassName}Dto\"");
            sb.AppendLine($"                                          Visible=\"@CanEdit{classDatas.ClassName}\"");
            sb.AppendLine($"                                          Clicked=\"async () => await OpenEdit{classDatas.ClassName}ModalAsync(context)\"");
            sb.AppendLine("                                          Text=\"@L[\"Edit\"]\"></EntityAction>");
            sb.AppendLine($"                            <EntityAction TItem=\"{classDatas.ClassName}Dto\"");
            sb.AppendLine($"                                          Visible=\"@CanDelete{classDatas.ClassName}\"");
            sb.AppendLine($"                                          Clicked=\"() => Delete{classDatas.ClassName}Async(context)\"");
            sb.AppendLine("                                          ConfirmationMessage=\"@(()=> L[\"DeleteConfirmationMessage\"])\"");
            sb.AppendLine("                                          Text=\"@L[\"Delete\"]\"></EntityAction>");
            sb.AppendLine("                            @*//<suite-custom-code-block-4>*@");
            sb.AppendLine("                            @*//</suite-custom-code-block-4>*@");
            sb.AppendLine("                        </EntityActions>");
            sb.AppendLine("                    </DisplayTemplate>");
            sb.AppendLine("                </DataGridEntityActionsColumn>");
            sb.AppendLine("");
            //propeties
            for (int i = 0; i< classDatas.Properties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.Properties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Key; // Property'nin türünü al
                var type = prop.Value; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                if (type == "bool" || type == "bool?")
                {
                    sb.AppendLine($"                <DataGridColumn TItem=\"{classDatas.ClassName}Dto\"");
                    sb.AppendLine($"                                Field=\"{name}\"");
                    sb.AppendLine($"                                Caption=\"@L[\"{name}\"]\">");
                    sb.AppendLine("                    <DisplayTemplate>");
                    sb.AppendLine($"                        @if (context.{name})");
                    sb.AppendLine("                        {");
                    sb.AppendLine("                            <Icon TextColor=\"TextColor.Success\" Name=\"@IconName.Check\" />");
                    sb.AppendLine("                        }");
                    sb.AppendLine("                        else");
                    sb.AppendLine("                        {");
                    sb.AppendLine("                            <Icon TextColor=\"TextColor.Danger\" Name=\"@IconName.Times\" />");
                    sb.AppendLine("                        }");
                    sb.AppendLine("                    </DisplayTemplate>");
                    sb.AppendLine("                </DataGridColumn>");
                    sb.AppendLine("");
                    sb.AppendLine("");
                }

                else if (type == "DateTime" || type == "DateTime?")
                {
                    sb.AppendLine($"                <DataGridColumn TItem=\"{classDatas.ClassName}Dto\"");
                    sb.AppendLine($"                                Field=\"{name}\"");
                    sb.AppendLine($"                                Caption=\"@L[\"{name}\"]\">");
                    sb.AppendLine("                    <DisplayTemplate>");
                    sb.AppendLine($"                        @context.{name}.ToShortDateString()");
                    sb.AppendLine("                    </DisplayTemplate>");
                    sb.AppendLine("                </DataGridColumn>");
                    sb.AppendLine("");
                }

                else
                {
                    sb.AppendLine($"                <DataGridColumn TItem=\"{classDatas.ClassName}Dto\"");
                    sb.AppendLine($"                                Field=\"{name}\"");
                    sb.AppendLine($"                                Caption=\"@L[\"{name}\"]\">");
                    sb.AppendLine("                </DataGridColumn>");
                    sb.AppendLine("");
                }
            }


            sb.AppendLine("            </DataGridColumns>");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("        </DataGrid>");
            sb.AppendLine("    </CardBody>");
            sb.AppendLine("</Card>");
            sb.AppendLine("");


            return sb.ToString();
        }



        public static string CreateDataGridTemplate(CreatedClassDatas classDatas)
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("@* ************************* DATA GRID ************************* *@");
            sb.AppendLine("<Card>");
            sb.AppendLine("    <CardBody>");
            sb.AppendLine($"        <DataGrid TItem=\"{classDatas.ClassName}Dto\"");
            sb.AppendLine($"                  Data=\"{classDatas.ClassName}List\"");
            sb.AppendLine("                  ReadData=\"OnDataGridReadAsync\"");
            sb.AppendLine("                  TotalItems=\"TotalCount\"");
            sb.AppendLine("                  ShowPager=\"true\"");
            sb.AppendLine("                  Responsive=\"true\"");
            sb.AppendLine("                  PageSize=\"PageSize\"");
            sb.AppendLine("                  Class=\"datagrid-detail\">");
            sb.AppendLine("            <LoadingTemplate>");
            sb.AppendLine("                <Row Class=\"w-100 align-items-center\" Style=\"height: 150px;\">");
            sb.AppendLine("                    <Column>");
            sb.AppendLine("                        <RadarSpinner />");
            sb.AppendLine("                    </Column>");
            sb.AppendLine("                </Row>");
            sb.AppendLine("            </LoadingTemplate>");
            sb.AppendLine("            <EmptyTemplate>");
            sb.AppendLine("                <Row Class=\"w-100 align-items-center\" Style=\"height: 150px;\">");
            sb.AppendLine("                    <Column>");
            sb.AppendLine("                        <Heading Size=\"HeadingSize.Is4\" TextAlignment=\"TextAlignment.Center\">@L[\"NoDataAvailable\"]</Heading>");
            sb.AppendLine("                    </Column>");
            sb.AppendLine("                </Row>");
            sb.AppendLine("            </EmptyTemplate>");
            sb.AppendLine("            <DataGridColumns>");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine($"                <DataGridEntityActionsColumn TItem=\"{classDatas.ClassName}Dto\" @ref=\"@EntityActionsColumn\">");
            sb.AppendLine("                    <DisplayTemplate>");
            sb.AppendLine($"                        <EntityActions TItem=\"{classDatas.ClassName}Dto\" EntityActionsColumn=\"@EntityActionsColumn\">");
            sb.AppendLine($"                            <EntityAction TItem=\"{classDatas.ClassName}Dto\"");
            sb.AppendLine($"                                          Visible=\"@CanEdit{classDatas.ClassName}\"");
            sb.AppendLine($"                                          Clicked=\"async () => await OpenEdit{classDatas.ClassName}ModalAsync(context)\"");
            sb.AppendLine("                                          Text=\"@L[\"Edit\"]\"></EntityAction>");
            sb.AppendLine($"                            <EntityAction TItem=\"{classDatas.ClassName}Dto\"");
            sb.AppendLine($"                                          Visible=\"@CanDelete{classDatas.ClassName}\"");
            sb.AppendLine($"                                          Clicked=\"() => Delete{classDatas.ClassName}Async(context)\"");
            sb.AppendLine("                                          ConfirmationMessage=\"@(()=> L[\"DeleteConfirmationMessage\"])\"");
            sb.AppendLine("                                          Text=\"@L[\"Delete\"]\"></EntityAction>");
            sb.AppendLine("                            @*//<suite-custom-code-block-4>*@");
            sb.AppendLine("                            @*//</suite-custom-code-block-4>*@");
            sb.AppendLine("                        </EntityActions>");
            sb.AppendLine("                    </DisplayTemplate>");
            sb.AppendLine("                </DataGridEntityActionsColumn>");
            sb.AppendLine("");
            //propeties
            for (int i = 0; i< classDatas.CreatedProperties.Count; i++)
            {
                // 'properties' Dictionary olduğundan 'ElementAt' ile ilgili elemanlara erişiyoruz
                var prop = classDatas.CreatedProperties.ElementAt(i);

                // prop.Value property adı, prop.Key ise türdür
                var name = prop.Name; // Property'nin türünü al
                var type = prop.Type; // Property'nin adını al

                // Property ismini Camel Case yapısında oluşturma
                var nameWithCamelCase = char.ToLower(name[0], System.Globalization.CultureInfo.InvariantCulture) + name.Substring(1);

                if (type == "bool" || type == "bool?")
                {
                    sb.AppendLine($"                <DataGridColumn TItem=\"{classDatas.ClassName}Dto\"");
                    sb.AppendLine($"                                Field=\"{name}\"");
                    sb.AppendLine($"                                Caption=\"@L[\"{name}\"]\">");
                    sb.AppendLine("                    <DisplayTemplate>");
                    sb.AppendLine($"                        @if (context.{name})");
                    sb.AppendLine("                        {");
                    sb.AppendLine("                            <Icon TextColor=\"TextColor.Success\" Name=\"@IconName.Check\" />");
                    sb.AppendLine("                        }");
                    sb.AppendLine("                        else");
                    sb.AppendLine("                        {");
                    sb.AppendLine("                            <Icon TextColor=\"TextColor.Danger\" Name=\"@IconName.Times\" />");
                    sb.AppendLine("                        }");
                    sb.AppendLine("                    </DisplayTemplate>");
                    sb.AppendLine("                </DataGridColumn>");
                    sb.AppendLine("");
                    sb.AppendLine("");
                }

                else if (type == "DateTime" || type == "DateTime?")
                {
                    sb.AppendLine($"                <DataGridColumn TItem=\"{classDatas.ClassName}Dto\"");
                    sb.AppendLine($"                                Field=\"{name}\"");
                    sb.AppendLine($"                                Caption=\"@L[\"{name}\"]\">");
                    sb.AppendLine("                    <DisplayTemplate>");
                    sb.AppendLine($"                        @context.{name}.ToShortDateString()");
                    sb.AppendLine("                    </DisplayTemplate>");
                    sb.AppendLine("                </DataGridColumn>");
                    sb.AppendLine("");
                }

                else
                {
                    sb.AppendLine($"                <DataGridColumn TItem=\"{classDatas.ClassName}Dto\"");
                    sb.AppendLine($"                                Field=\"{name}\"");
                    sb.AppendLine($"                                Caption=\"@L[\"{name}\"]\">");
                    sb.AppendLine("                </DataGridColumn>");
                    sb.AppendLine("");
                }
            }


            sb.AppendLine("            </DataGridColumns>");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("        </DataGrid>");
            sb.AppendLine("    </CardBody>");
            sb.AppendLine("</Card>");
            sb.AppendLine("");


            return sb.ToString();
        }

    }
}
