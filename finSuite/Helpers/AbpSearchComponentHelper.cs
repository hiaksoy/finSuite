using System.Text;
using finSuite.InputClasses;

namespace finSuite.Helpers
{
    public class AbpSearchComponentHelper
    {
        public static string CreateSearchTemplate(ClassDatas classDatas, string folderName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("@* ************************* SEARCH ************************* *@");
            sb.AppendLine("<Card>");
            sb.AppendLine("    <CardBody>");
            sb.AppendLine("        @*//<suite-custom-code-block-1>*@");
            sb.AppendLine("        @*//</suite-custom-code-block-1>*@");
            sb.AppendLine($"        <Form id=\"{classDatas.ClassName}SearchForm\" class=\"mb-3\">");
            sb.AppendLine("            <Addons>");
            sb.AppendLine("                <Addon AddonType=\"AddonType.Body\">");
            sb.AppendLine("                    <TextEdit @bind-Text=\"@Filter.FilterText\"");
            sb.AppendLine("                              Autofocus=\"true\"");
            sb.AppendLine("                              Placeholder=\"@L[\"Search\"]\">");
            sb.AppendLine("                    </TextEdit>");
            sb.AppendLine("                </Addon>");
            sb.AppendLine("                <Addon AddonType=\"AddonType.End\">");
            sb.AppendLine($"                    <SubmitButton Form=\"{classDatas.ClassName}SearchForm\" Clicked=\"Get{folderName}Async\">");
            sb.AppendLine("                        <Icon Name=\"IconName.Search\" Class=\"me-1\"></Icon>@L[\"Search\"]");
            sb.AppendLine("                    </SubmitButton>");
            sb.AppendLine("                </Addon>");
            sb.AppendLine("            </Addons>");
            sb.AppendLine("        </Form>");
            sb.AppendLine("");
            sb.AppendLine("        <Row Class=\"mt-3 mb-3\">");
            sb.AppendLine("            <div class=\"col-md-12\">");
            sb.AppendLine("                <a href=\"javascript:;\" class=\"text-decoration-none\" @onclick=\"() => ShowAdvancedFilters = !ShowAdvancedFilters\">@L[\"SeeAdvancedFilters\"]</a>");
            sb.AppendLine("            </div>");
            sb.AppendLine("        </Row>");
            sb.AppendLine("");
            sb.AppendLine("        <div style=\"display: @(!ShowAdvancedFilters ? \"none\" : \"block\")\">");
            sb.AppendLine("            <Row>");

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
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"{name}\"]</FieldLabel>");
                    sb.AppendLine("                        <Select TValue=\"bool?\"");
                    sb.AppendLine($"                                SelectedValue=\"@Filter.{name}\"");
                    sb.AppendLine($"                                SelectedValueChanged=\"@On{name}ChangedAsync\">");
                    sb.AppendLine("");
                    sb.AppendLine("                            <SelectItem></SelectItem>");
                    sb.AppendLine("                            <SelectItem Value=\"true\">@L[\"Yes\"]</SelectItem>");
                    sb.AppendLine("                            <SelectItem Value=\"false\">@L[\"No\"]</SelectItem>");
                    sb.AppendLine("");
                    sb.AppendLine("                        </Select>");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");

                }

                else if (type == "DateTime" || type == "DateTime?")
                {
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Min{name}\"]</FieldLabel>");
                    sb.AppendLine("                        <DatePicker TValue=\"DateTime?\"");
                    sb.AppendLine("                                    InputMode=\"DateInputMode.Date\"");
                    sb.AppendLine($"                                    Date=\"@Filter.{name}Min\"");
                    sb.AppendLine($"                                    DateChanged=\"@On{name}MinChangedAsync\"");
                    sb.AppendLine("                                    Placeholder=\"@string.Empty\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Max{name}\"]</FieldLabel>");
                    sb.AppendLine("                        <DatePicker TValue=\"DateTime?\"");
                    sb.AppendLine("                                    InputMode=\"DateInputMode.Date\"");
                    sb.AppendLine($"                                    Date=\"@Filter.{name}Max\"");
                    sb.AppendLine($"                                    DateChanged=\"@On{name}MaxChangedAsync\"");
                    sb.AppendLine("                                    Placeholder=\"@string.Empty\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                }

                else if (type == "DateOnly" || type == "DateOnly?")
                {
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Min{name}\"]</FieldLabel>");
                    sb.AppendLine("                        <DateEdit TValue=\"DateOnly?\"");
                    sb.AppendLine($"                                  Date=\"@Filter.{name}Min\"");
                    sb.AppendLine($"                                  DateChanged=\"@On{name}MinChangedAsync\"");
                    sb.AppendLine("                                  Placeholder=\"@string.Empty\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Max{name}\"]</FieldLabel>");
                    sb.AppendLine("                        <DateEdit TValue=\"DateOnly?\"");
                    sb.AppendLine($"                                  Date=\"@Filter.{name}Max\"");
                    sb.AppendLine($"                                  DateChanged=\"@On{name}MaxChangedAsync\"");
                    sb.AppendLine("                                  Placeholder=\"@string.Empty\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                }


                else if (type == "byte?" ||
                         type == "decimal?" ||
                         type == "double?" ||
                         type == "float?" ||
                         type == "int?" ||
                         type == "long?" ||
                         type == "sbyte?" ||
                         type == "uint?" ||
                         type == "ulong?" ||
                         type == "ushort?")
                {
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Min{name}\"]</FieldLabel>");
                    sb.AppendLine($"                        <NumericEdit TValue=\"{type}\"");
                    sb.AppendLine($"                                     Value=\"@Filter.{name}Min\"");
                    sb.AppendLine($"                                     ValueChanged=\"@On{name}MinChangedAsync\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Max{name}\"]</FieldLabel>");
                    sb.AppendLine($"                        <NumericEdit TValue=\"{type}\"");
                    sb.AppendLine($"                                     Value=\"@Filter.{name}Max\"");
                    sb.AppendLine($"                                     ValueChanged=\"@On{name}MaxChangedAsync\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");

                }

                else if (type == "byte" ||
                         type == "decimal" ||
                         type == "double" ||
                         type == "float" ||
                         type == "int" ||
                         type == "long" ||
                         type == "sbyte" ||
                         type == "uint" ||
                         type == "ulong" ||
                         type == "ushort")
                {
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Min{name}\"]</FieldLabel>");
                    sb.AppendLine($"                        <NumericEdit TValue=\"{type}?\"");
                    sb.AppendLine($"                                     Value=\"@Filter.{name}Min\"");
                    sb.AppendLine($"                                     ValueChanged=\"@On{name}MinChangedAsync\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Max{name}\"]</FieldLabel>");
                    sb.AppendLine($"                        <NumericEdit TValue=\"{type}?\"");
                    sb.AppendLine($"                                     Value=\"@Filter.{name}Max\"");
                    sb.AppendLine($"                                     ValueChanged=\"@On{name}MaxChangedAsync\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");

                }


                else if (type == "string" || type == "string?")
                {


                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"{name}\"]</FieldLabel>");
                    sb.AppendLine($"                        <TextEdit Text=\"@Filter.{name}\" TextChanged=\"@On{name}ChangedAsync\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                }


                else if (type == "TimeOnly" || type == "TimeOnly?")
                {
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Min{name}\"]</FieldLabel>");
                    sb.AppendLine("                        <TimeEdit TValue=\"TimeOnly?\"");
                    sb.AppendLine($"                                  Time=\"@Filter.{name}Min\"");
                    sb.AppendLine($"                                  TimeChanged=\"@On{name}MinChangedAsync\"");
                    sb.AppendLine("                                  Placeholder=\"@string.Empty\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Max{name}\"]</FieldLabel>");
                    sb.AppendLine("                        <TimeEdit TValue=\"TimeOnly?\"");
                    sb.AppendLine($"                                  Time=\"@Filter.{name}Max\"");
                    sb.AppendLine($"                                  TimeChanged=\"@On{name}MaxChangedAsync\"");
                    sb.AppendLine("                                  Placeholder=\"@string.Empty\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                }
            }

            sb.AppendLine("            </Row>");
            sb.AppendLine("            @*//<suite-custom-code-block-2>*@");
            sb.AppendLine("            @*//</suite-custom-code-block-2>*@");
            sb.AppendLine("        </div>");
            sb.AppendLine("");
            sb.AppendLine("        @*//<suite-custom-code-block-3>*@");
            sb.AppendLine("        @*//</suite-custom-code-block-3>*@");
            sb.AppendLine("    </CardBody>");
            sb.AppendLine("</Card>");
            sb.AppendLine("");

            return sb.ToString();
        }


        public static string CreateSearchTemplate(CreatedClassDatas classDatas, string folderName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("@* ************************* SEARCH ************************* *@");
            sb.AppendLine("<Card>");
            sb.AppendLine("    <CardBody>");
            sb.AppendLine("        @*//<suite-custom-code-block-1>*@");
            sb.AppendLine("        @*//</suite-custom-code-block-1>*@");
            sb.AppendLine($"        <Form id=\"{classDatas.ClassName}SearchForm\" class=\"mb-3\">");
            sb.AppendLine("            <Addons>");
            sb.AppendLine("                <Addon AddonType=\"AddonType.Body\">");
            sb.AppendLine("                    <TextEdit @bind-Text=\"@Filter.FilterText\"");
            sb.AppendLine("                              Autofocus=\"true\"");
            sb.AppendLine("                              Placeholder=\"@L[\"Search\"]\">");
            sb.AppendLine("                    </TextEdit>");
            sb.AppendLine("                </Addon>");
            sb.AppendLine("                <Addon AddonType=\"AddonType.End\">");
            sb.AppendLine($"                    <SubmitButton Form=\"{classDatas.ClassName}SearchForm\" Clicked=\"Get{folderName}Async\">");
            sb.AppendLine("                        <Icon Name=\"IconName.Search\" Class=\"me-1\"></Icon>@L[\"Search\"]");
            sb.AppendLine("                    </SubmitButton>");
            sb.AppendLine("                </Addon>");
            sb.AppendLine("            </Addons>");
            sb.AppendLine("        </Form>");
            sb.AppendLine("");
            sb.AppendLine("        <Row Class=\"mt-3 mb-3\">");
            sb.AppendLine("            <div class=\"col-md-12\">");
            sb.AppendLine("                <a href=\"javascript:;\" class=\"text-decoration-none\" @onclick=\"() => ShowAdvancedFilters = !ShowAdvancedFilters\">@L[\"SeeAdvancedFilters\"]</a>");
            sb.AppendLine("            </div>");
            sb.AppendLine("        </Row>");
            sb.AppendLine("");
            sb.AppendLine("        <div style=\"display: @(!ShowAdvancedFilters ? \"none\" : \"block\")\">");
            sb.AppendLine("            <Row>");

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
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"{name}\"]</FieldLabel>");
                    sb.AppendLine("                        <Select TValue=\"bool?\"");
                    sb.AppendLine($"                                SelectedValue=\"@Filter.{name}\"");
                    sb.AppendLine($"                                SelectedValueChanged=\"@On{name}ChangedAsync\">");
                    sb.AppendLine("");
                    sb.AppendLine("                            <SelectItem></SelectItem>");
                    sb.AppendLine("                            <SelectItem Value=\"true\">@L[\"Yes\"]</SelectItem>");
                    sb.AppendLine("                            <SelectItem Value=\"false\">@L[\"No\"]</SelectItem>");
                    sb.AppendLine("");
                    sb.AppendLine("                        </Select>");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");

                }

                else if (type == "DateTime" || type == "DateTime?")
                {
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Min{name}\"]</FieldLabel>");
                    sb.AppendLine("                        <DatePicker TValue=\"DateTime?\"");
                    sb.AppendLine("                                    InputMode=\"DateInputMode.Date\"");
                    sb.AppendLine($"                                    Date=\"@Filter.{name}Min\"");
                    sb.AppendLine($"                                    DateChanged=\"@On{name}MinChangedAsync\"");
                    sb.AppendLine("                                    Placeholder=\"@string.Empty\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Max{name}\"]</FieldLabel>");
                    sb.AppendLine("                        <DatePicker TValue=\"DateTime?\"");
                    sb.AppendLine("                                    InputMode=\"DateInputMode.Date\"");
                    sb.AppendLine($"                                    Date=\"@Filter.{name}Max\"");
                    sb.AppendLine($"                                    DateChanged=\"@On{name}MaxChangedAsync\"");
                    sb.AppendLine("                                    Placeholder=\"@string.Empty\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                }

                else if (type == "DateOnly" || type == "DateOnly?")
                {
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Min{name}\"]</FieldLabel>");
                    sb.AppendLine("                        <DateEdit TValue=\"DateOnly?\"");
                    sb.AppendLine($"                                  Date=\"@Filter.{name}Min\"");
                    sb.AppendLine($"                                  DateChanged=\"@On{name}MinChangedAsync\"");
                    sb.AppendLine("                                  Placeholder=\"@string.Empty\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Max{name}\"]</FieldLabel>");
                    sb.AppendLine("                        <DateEdit TValue=\"DateOnly?\"");
                    sb.AppendLine($"                                  Date=\"@Filter.{name}Max\"");
                    sb.AppendLine($"                                  DateChanged=\"@On{name}MaxChangedAsync\"");
                    sb.AppendLine("                                  Placeholder=\"@string.Empty\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                }


                else if (type == "byte?" ||
                         type == "decimal?" ||
                         type == "double?" ||
                         type == "float?" ||
                         type == "int?" ||
                         type == "long?" ||
                         type == "sbyte?" ||
                         type == "uint?" ||
                         type == "ulong?" ||
                         type == "ushort?")
                {
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Min{name}\"]</FieldLabel>");
                    sb.AppendLine($"                        <NumericEdit TValue=\"{type}\"");
                    sb.AppendLine($"                                     Value=\"@Filter.{name}Min\"");
                    sb.AppendLine($"                                     ValueChanged=\"@On{name}MinChangedAsync\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Max{name}\"]</FieldLabel>");
                    sb.AppendLine($"                        <NumericEdit TValue=\"{type}\"");
                    sb.AppendLine($"                                     Value=\"@Filter.{name}Max\"");
                    sb.AppendLine($"                                     ValueChanged=\"@On{name}MaxChangedAsync\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");

                }

                else if (type == "byte" ||
                         type == "decimal" ||
                         type == "double" ||
                         type == "float" ||
                         type == "int" ||
                         type == "long" ||
                         type == "sbyte" ||
                         type == "uint" ||
                         type == "ulong" ||
                         type == "ushort")
                {
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Min{name}\"]</FieldLabel>");
                    sb.AppendLine($"                        <NumericEdit TValue=\"{type}?\"");
                    sb.AppendLine($"                                     Value=\"@Filter.{name}Min\"");
                    sb.AppendLine($"                                     ValueChanged=\"@On{name}MinChangedAsync\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Max{name}\"]</FieldLabel>");
                    sb.AppendLine($"                        <NumericEdit TValue=\"{type}?\"");
                    sb.AppendLine($"                                     Value=\"@Filter.{name}Max\"");
                    sb.AppendLine($"                                     ValueChanged=\"@On{name}MaxChangedAsync\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");

                }


                else if (type == "string" || type == "string?")
                {


                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"{name}\"]</FieldLabel>");
                    sb.AppendLine($"                        <TextEdit Text=\"@Filter.{name}\" TextChanged=\"@On{name}ChangedAsync\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                }


                else if (type == "TimeOnly" || type == "TimeOnly?")
                {
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Min{name}\"]</FieldLabel>");
                    sb.AppendLine("                        <TimeEdit TValue=\"TimeOnly?\"");
                    sb.AppendLine($"                                  Time=\"@Filter.{name}Min\"");
                    sb.AppendLine($"                                  TimeChanged=\"@On{name}MinChangedAsync\"");
                    sb.AppendLine("                                  Placeholder=\"@string.Empty\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                    sb.AppendLine("                <Column ColumnSize=\"ColumnSize.Is3\">");
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <FieldLabel>@L[\"Max{name}\"]</FieldLabel>");
                    sb.AppendLine("                        <TimeEdit TValue=\"TimeOnly?\"");
                    sb.AppendLine($"                                  Time=\"@Filter.{name}Max\"");
                    sb.AppendLine($"                                  TimeChanged=\"@On{name}MaxChangedAsync\"");
                    sb.AppendLine("                                  Placeholder=\"@string.Empty\" />");
                    sb.AppendLine("                    </Field>");
                    sb.AppendLine("                </Column>");
                }
            }

            sb.AppendLine("            </Row>");
            sb.AppendLine("            @*//<suite-custom-code-block-2>*@");
            sb.AppendLine("            @*//</suite-custom-code-block-2>*@");
            sb.AppendLine("        </div>");
            sb.AppendLine("");
            sb.AppendLine("        @*//<suite-custom-code-block-3>*@");
            sb.AppendLine("        @*//</suite-custom-code-block-3>*@");
            sb.AppendLine("    </CardBody>");
            sb.AppendLine("</Card>");
            sb.AppendLine("");

            return sb.ToString();
        }


    }
}
