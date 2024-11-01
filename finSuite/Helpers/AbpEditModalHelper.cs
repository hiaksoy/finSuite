using System.Text;
using finSuite.InputClasses;

namespace finSuite.Helpers
{
    public class AbpEditModalHelper
    {
        public static string CreateEditModalTemplate(ClassDatas classDatas)
        {
            StringBuilder sb = new StringBuilder();
            #region edit modal
            sb.AppendLine("@* ************************* EDIT MODAL ************************* *@");
            sb.AppendLine($"<Modal @ref=\"Edit{classDatas.ClassName}Modal\" Closing=\"@Edit{classDatas.ClassName}Modal.CancelClosingModalWhenFocusLost\">");
            sb.AppendLine("    <ModalContent Centered=\"true\">");
            sb.AppendLine("        @*//<suite-custom-code-block-8>*@");
            sb.AppendLine("        @*//</suite-custom-code-block-8>*@");
            sb.AppendLine($"        <Form id=\"Edit{classDatas.ClassName}Form\">");
            sb.AppendLine("            <ModalHeader>");
            sb.AppendLine("                <ModalTitle>@L[\"Update\"]</ModalTitle>");
            sb.AppendLine($"                <CloseButton Clicked=\"CloseEdit{classDatas.ClassName}ModalAsync\" />");
            sb.AppendLine("            </ModalHeader>");
            sb.AppendLine("            <ModalBody>");
            sb.AppendLine($"                <Validations @ref=\"@Editing{classDatas.ClassName}Validations\"");
            sb.AppendLine("                             Mode=\"ValidationMode.Auto\"");
            sb.AppendLine($"                             Model=\"@Editing{classDatas.ClassName}\"");
            sb.AppendLine("                             ValidateOnLoad=\"false\">");
            sb.AppendLine("");
            sb.AppendLine("");

            //properties
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
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <Check TValue=\"bool\" @bind-Checked=\"@Editing{classDatas.ClassName}.{name}\">@L[\"{name}\"]</Check>");
                    sb.AppendLine("                    </Field>");

                }

                else if (type == "DateTime" || type == "DateTime?" || type == "DateOnly" || type == "DateOnly?")
                {

                    sb.AppendLine("");
                    sb.AppendLine("                    <Validation MessageLocalizer=\"@LH.Localize\">");
                    sb.AppendLine("                        <Field>");
                    sb.AppendLine($"                            <FieldLabel>@L[\"{name}\"]</FieldLabel>");
                    sb.AppendLine($"                            <DateEdit TValue=\"{type}\" InputMode=\"DateInputMode.Date\" @bind-Date=\"@Editing{classDatas.ClassName}.{name}\">");
                    sb.AppendLine("                                <Feedback>");
                    sb.AppendLine("                                    <ValidationError />");
                    sb.AppendLine("                                </Feedback>");
                    sb.AppendLine("                            </DateEdit>");
                    sb.AppendLine("                        </Field>");
                    sb.AppendLine("                    </Validation>");
                    sb.AppendLine("");

                }

                else if (type == "byte" ||
                         type == "int" ||
                         type == "long" ||
                         type == "sbyte" ||
                         type == "uint" ||
                         type == "ulong" ||
                         type == "ushort")
                {

                    sb.AppendLine("");
                    sb.AppendLine("                    <Validation MessageLocalizer=\"@LH.Localize\">");
                    sb.AppendLine("                        <Field>");
                    sb.AppendLine($"                            <FieldLabel>@L[\"{name}\"] *</FieldLabel>");
                    sb.AppendLine($"                            <NumericPicker TValue=\"{type}\" @bind-Value=\"@Editing{classDatas.ClassName}.{name}\" Min=\"{classDatas.ClassName}Consts.{name}MinLength\" Max=\"{classDatas.ClassName}Consts.{name}MaxLength\" Decimals=\"0\">");
                    sb.AppendLine("                                <Feedback>");
                    sb.AppendLine("                                    <ValidationError />");
                    sb.AppendLine("                                </Feedback>");
                    sb.AppendLine("                            </NumericPicker>");
                    sb.AppendLine("                        </Field>");
                    sb.AppendLine("                    </Validation>");
                    sb.AppendLine("");
                }

                else if (type == "decimal" ||
                         type == "double" ||
                         type == "float")
                {
                    sb.AppendLine("");
                    sb.AppendLine("                    <Validation MessageLocalizer=\"@LH.Localize\">");
                    sb.AppendLine("                        <Field>");
                    sb.AppendLine($"                            <FieldLabel>@L[\"{name}\"] *</FieldLabel>");
                    sb.AppendLine($"                            <NumericPicker TValue=\"{type}\" @bind-Value=\"@Editing{classDatas.ClassName}.{name}\" Min=\"{classDatas.ClassName}Consts.{name}MinLength\" Max=\"{classDatas.ClassName}Consts.{name}MaxLength\">");
                    sb.AppendLine("                                <Feedback>");
                    sb.AppendLine("                                    <ValidationError />");
                    sb.AppendLine("                                </Feedback>");
                    sb.AppendLine("                            </NumericPicker>");
                    sb.AppendLine("                        </Field>");
                    sb.AppendLine("                    </Validation>");
                    sb.AppendLine("");
                }


                else if (type == "byte?" ||
                         type == "int?" ||
                         type == "long?" ||
                         type == "sbyte?" ||
                         type == "uint?" ||
                         type == "ulong?" ||
                         type == "ushort?")
                {

                    sb.AppendLine("");
                    sb.AppendLine("                    <Validation MessageLocalizer=\"@LH.Localize\">");
                    sb.AppendLine("                        <Field>");
                    sb.AppendLine($"                            <FieldLabel>@L[\"{name}\"]</FieldLabel>");
                    sb.AppendLine($"                            <NumericPicker TValue=\"{type}\" @bind-Value=\"@Editing{classDatas.ClassName}.{name}\" Decimals=\"0\">");
                    sb.AppendLine("                                <Feedback>");
                    sb.AppendLine("                                    <ValidationError />");
                    sb.AppendLine("                                </Feedback>");
                    sb.AppendLine("                            </NumericPicker>");
                    sb.AppendLine("                        </Field>");
                    sb.AppendLine("                    </Validation>");
                    sb.AppendLine("");
                }

                else if (type == "decimal?" ||
                         type == "double?" ||
                         type == "float?")
                {
                    sb.AppendLine("");
                    sb.AppendLine("                    <Validation MessageLocalizer=\"@LH.Localize\">");
                    sb.AppendLine("                        <Field>");
                    sb.AppendLine($"                            <FieldLabel>@L[\"{name}\"]</FieldLabel>");
                    sb.AppendLine($"                            <NumericPicker TValue=\"{type}\" @bind-Value=\"@Editing{classDatas.ClassName}.{name}\" >");
                    sb.AppendLine("                                <Feedback>");
                    sb.AppendLine("                                    <ValidationError />");
                    sb.AppendLine("                                </Feedback>");
                    sb.AppendLine("                            </NumericPicker>");
                    sb.AppendLine("                        </Field>");
                    sb.AppendLine("                    </Validation>");
                    sb.AppendLine("");
                }


                else if (type == "string" || type == "string?")
                {
                    sb.AppendLine("");
                    sb.AppendLine("                    <Validation MessageLocalizer=\"@LH.Localize\">");
                    sb.AppendLine("                        <Field>");
                    sb.AppendLine($"                            <FieldLabel>@L[\"{name}\"] *</FieldLabel>");
                    sb.AppendLine($"                            <TextEdit @bind-Text=\"@Editing{classDatas.ClassName}.{name}\" MaxLength=\"{classDatas.ClassName}Consts.{name}MaxLength\" Role=\"TextRole.Email\">");
                    sb.AppendLine("                                <Feedback>");
                    sb.AppendLine("                                    <ValidationError />");
                    sb.AppendLine("                                </Feedback>");
                    sb.AppendLine("                            </TextEdit>");
                    sb.AppendLine("                        </Field>");
                    sb.AppendLine("                    </Validation>");
                    sb.AppendLine("");
                }

                else if (type == "TimeOnly" || type == "TimeOnly?")
                {
                    sb.AppendLine("");
                    sb.AppendLine("                    <Validation MessageLocalizer=\"@LH.Localize\">");
                    sb.AppendLine("                        <Field>");
                    sb.AppendLine($"                            <FieldLabel>@L[\"{name}\"]</FieldLabel>");
                    sb.AppendLine($"                            <TimeEdit TValue=\"TimeOnly\" @bind-Time=\"@Editing{classDatas.ClassName}.{name}\">");
                    sb.AppendLine("                                <Feedback>");
                    sb.AppendLine("                                    <ValidationError />");
                    sb.AppendLine("                                </Feedback>");
                    sb.AppendLine("                            </TimeEdit>");
                    sb.AppendLine("                        </Field>");
                    sb.AppendLine("                    </Validation>");
                    sb.AppendLine("");
                }

            }


            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("                </Validations>");
            sb.AppendLine("            </ModalBody>");
            sb.AppendLine("            <ModalFooter>");
            sb.AppendLine("                <Button Color=\"Color.Secondary\"");
            sb.AppendLine($"                        Clicked=\"CloseEdit{classDatas.ClassName}ModalAsync\">");
            sb.AppendLine("                    @L[\"Cancel\"]");
            sb.AppendLine("                </Button>");
            sb.AppendLine($"                <SubmitButton Form=\"Edit{classDatas.ClassName}Form\" Clicked=\"Update{classDatas.ClassName}Async\" />");
            sb.AppendLine("                @*//<suite-custom-code-block-9>*@");
            sb.AppendLine("                @*//</suite-custom-code-block-9>*@");
            sb.AppendLine("            </ModalFooter>");
            sb.AppendLine("        </Form>");
            sb.AppendLine("        @*//<suite-custom-code-block-10>*@");
            sb.AppendLine("        @*//</suite-custom-code-block-10>*@");
            sb.AppendLine("    </ModalContent>");
            sb.AppendLine("</Modal>");
            sb.AppendLine("");
            #endregion


            return sb.ToString();
        }

        public static string CreateEditModalTemplate(CreatedClassDatas classDatas)
        {
            StringBuilder sb = new StringBuilder();
            #region edit modal
            sb.AppendLine("@* ************************* EDIT MODAL ************************* *@");
            sb.AppendLine($"<Modal @ref=\"Edit{classDatas.ClassName}Modal\" Closing=\"@Edit{classDatas.ClassName}Modal.CancelClosingModalWhenFocusLost\">");
            sb.AppendLine("    <ModalContent Centered=\"true\">");
            sb.AppendLine("        @*//<suite-custom-code-block-8>*@");
            sb.AppendLine("        @*//</suite-custom-code-block-8>*@");
            sb.AppendLine($"        <Form id=\"Edit{classDatas.ClassName}Form\">");
            sb.AppendLine("            <ModalHeader>");
            sb.AppendLine("                <ModalTitle>@L[\"Update\"]</ModalTitle>");
            sb.AppendLine($"                <CloseButton Clicked=\"CloseEdit{classDatas.ClassName}ModalAsync\" />");
            sb.AppendLine("            </ModalHeader>");
            sb.AppendLine("            <ModalBody>");
            sb.AppendLine($"                <Validations @ref=\"@Editing{classDatas.ClassName}Validations\"");
            sb.AppendLine("                             Mode=\"ValidationMode.Auto\"");
            sb.AppendLine($"                             Model=\"@Editing{classDatas.ClassName}\"");
            sb.AppendLine("                             ValidateOnLoad=\"false\">");
            sb.AppendLine("");
            sb.AppendLine("");

            //properties
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
                    sb.AppendLine("                    <Field>");
                    sb.AppendLine($"                        <Check TValue=\"bool\" @bind-Checked=\"@Editing{classDatas.ClassName}.{name}\">@L[\"{name}\"]</Check>");
                    sb.AppendLine("                    </Field>");

                }

                else if (type == "DateTime" || type == "DateTime?" || type == "DateOnly" || type == "DateOnly?")
                {

                    sb.AppendLine("");
                    sb.AppendLine("                    <Validation MessageLocalizer=\"@LH.Localize\">");
                    sb.AppendLine("                        <Field>");
                    sb.AppendLine($"                            <FieldLabel>@L[\"{name}\"]</FieldLabel>");
                    sb.AppendLine($"                            <DateEdit TValue=\"{type}\" InputMode=\"DateInputMode.Date\" @bind-Date=\"@Editing{classDatas.ClassName}.{name}\">");
                    sb.AppendLine("                                <Feedback>");
                    sb.AppendLine("                                    <ValidationError />");
                    sb.AppendLine("                                </Feedback>");
                    sb.AppendLine("                            </DateEdit>");
                    sb.AppendLine("                        </Field>");
                    sb.AppendLine("                    </Validation>");
                    sb.AppendLine("");

                }

                else if (type == "byte" ||
                         type == "int" ||
                         type == "long" ||
                         type == "sbyte" ||
                         type == "uint" ||
                         type == "ulong" ||
                         type == "ushort")
                {

                    sb.AppendLine("");
                    sb.AppendLine("                    <Validation MessageLocalizer=\"@LH.Localize\">");
                    sb.AppendLine("                        <Field>");
                    sb.AppendLine($"                            <FieldLabel>@L[\"{name}\"] *</FieldLabel>");
                    sb.AppendLine($"                            <NumericPicker TValue=\"{type}\" @bind-Value=\"@Editing{classDatas.ClassName}.{name}\" Min=\"{classDatas.ClassName}Consts.{name}MinLength\" Max=\"{classDatas.ClassName}Consts.{name}MaxLength\" Decimals=\"0\">");
                    sb.AppendLine("                                <Feedback>");
                    sb.AppendLine("                                    <ValidationError />");
                    sb.AppendLine("                                </Feedback>");
                    sb.AppendLine("                            </NumericPicker>");
                    sb.AppendLine("                        </Field>");
                    sb.AppendLine("                    </Validation>");
                    sb.AppendLine("");
                }

                else if (type == "decimal" ||
                         type == "double" ||
                         type == "float")
                {
                    sb.AppendLine("");
                    sb.AppendLine("                    <Validation MessageLocalizer=\"@LH.Localize\">");
                    sb.AppendLine("                        <Field>");
                    sb.AppendLine($"                            <FieldLabel>@L[\"{name}\"] *</FieldLabel>");
                    sb.AppendLine($"                            <NumericPicker TValue=\"{type}\" @bind-Value=\"@Editing{classDatas.ClassName}.{name}\" Min=\"{classDatas.ClassName}Consts.{name}MinLength\" Max=\"{classDatas.ClassName}Consts.{name}MaxLength\">");
                    sb.AppendLine("                                <Feedback>");
                    sb.AppendLine("                                    <ValidationError />");
                    sb.AppendLine("                                </Feedback>");
                    sb.AppendLine("                            </NumericPicker>");
                    sb.AppendLine("                        </Field>");
                    sb.AppendLine("                    </Validation>");
                    sb.AppendLine("");
                }


                else if (type == "byte?" ||
                         type == "int?" ||
                         type == "long?" ||
                         type == "sbyte?" ||
                         type == "uint?" ||
                         type == "ulong?" ||
                         type == "ushort?")
                {

                    sb.AppendLine("");
                    sb.AppendLine("                    <Validation MessageLocalizer=\"@LH.Localize\">");
                    sb.AppendLine("                        <Field>");
                    sb.AppendLine($"                            <FieldLabel>@L[\"{name}\"]</FieldLabel>");
                    sb.AppendLine($"                            <NumericPicker TValue=\"{type}\" @bind-Value=\"@Editing{classDatas.ClassName}.{name}\" Decimals=\"0\">");
                    sb.AppendLine("                                <Feedback>");
                    sb.AppendLine("                                    <ValidationError />");
                    sb.AppendLine("                                </Feedback>");
                    sb.AppendLine("                            </NumericPicker>");
                    sb.AppendLine("                        </Field>");
                    sb.AppendLine("                    </Validation>");
                    sb.AppendLine("");
                }

                else if (type == "decimal?" ||
                         type == "double?" ||
                         type == "float?")
                {
                    sb.AppendLine("");
                    sb.AppendLine("                    <Validation MessageLocalizer=\"@LH.Localize\">");
                    sb.AppendLine("                        <Field>");
                    sb.AppendLine($"                            <FieldLabel>@L[\"{name}\"]</FieldLabel>");
                    sb.AppendLine($"                            <NumericPicker TValue=\"{type}\" @bind-Value=\"@Editing{classDatas.ClassName}.{name}\" >");
                    sb.AppendLine("                                <Feedback>");
                    sb.AppendLine("                                    <ValidationError />");
                    sb.AppendLine("                                </Feedback>");
                    sb.AppendLine("                            </NumericPicker>");
                    sb.AppendLine("                        </Field>");
                    sb.AppendLine("                    </Validation>");
                    sb.AppendLine("");
                }


                else if (type == "string" || type == "string?")
                {
                    sb.AppendLine("");
                    sb.AppendLine("                    <Validation MessageLocalizer=\"@LH.Localize\">");
                    sb.AppendLine("                        <Field>");
                    sb.AppendLine($"                            <FieldLabel>@L[\"{name}\"] *</FieldLabel>");
                    sb.AppendLine($"                            <TextEdit @bind-Text=\"@Editing{classDatas.ClassName}.{name}\" MaxLength=\"{classDatas.ClassName}Consts.{name}MaxLength\" Role=\"TextRole.Email\">");
                    sb.AppendLine("                                <Feedback>");
                    sb.AppendLine("                                    <ValidationError />");
                    sb.AppendLine("                                </Feedback>");
                    sb.AppendLine("                            </TextEdit>");
                    sb.AppendLine("                        </Field>");
                    sb.AppendLine("                    </Validation>");
                    sb.AppendLine("");
                }

                else if (type == "TimeOnly" || type == "TimeOnly?")
                {
                    sb.AppendLine("");
                    sb.AppendLine("                    <Validation MessageLocalizer=\"@LH.Localize\">");
                    sb.AppendLine("                        <Field>");
                    sb.AppendLine($"                            <FieldLabel>@L[\"{name}\"]</FieldLabel>");
                    sb.AppendLine($"                            <TimeEdit TValue=\"TimeOnly\" @bind-Time=\"@Editing{classDatas.ClassName}.{name}\">");
                    sb.AppendLine("                                <Feedback>");
                    sb.AppendLine("                                    <ValidationError />");
                    sb.AppendLine("                                </Feedback>");
                    sb.AppendLine("                            </TimeEdit>");
                    sb.AppendLine("                        </Field>");
                    sb.AppendLine("                    </Validation>");
                    sb.AppendLine("");
                }

            }


            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("                </Validations>");
            sb.AppendLine("            </ModalBody>");
            sb.AppendLine("            <ModalFooter>");
            sb.AppendLine("                <Button Color=\"Color.Secondary\"");
            sb.AppendLine($"                        Clicked=\"CloseEdit{classDatas.ClassName}ModalAsync\">");
            sb.AppendLine("                    @L[\"Cancel\"]");
            sb.AppendLine("                </Button>");
            sb.AppendLine($"                <SubmitButton Form=\"Edit{classDatas.ClassName}Form\" Clicked=\"Update{classDatas.ClassName}Async\" />");
            sb.AppendLine("                @*//<suite-custom-code-block-9>*@");
            sb.AppendLine("                @*//</suite-custom-code-block-9>*@");
            sb.AppendLine("            </ModalFooter>");
            sb.AppendLine("        </Form>");
            sb.AppendLine("        @*//<suite-custom-code-block-10>*@");
            sb.AppendLine("        @*//</suite-custom-code-block-10>*@");
            sb.AppendLine("    </ModalContent>");
            sb.AppendLine("</Modal>");
            sb.AppendLine("");
            #endregion


            return sb.ToString();
        }
    }
}
