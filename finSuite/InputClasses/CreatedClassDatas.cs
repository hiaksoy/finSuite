using System.Text;

namespace finSuite.InputClasses
{
    public class CreatedClassDatas
    {
        public List<CreatedProperties> CreatedProperties { get; set; }
        public Dictionary<string, string> NavigationProperties { get; set; }
        public string ClassName { get; set; }
        public string PluralName { get; set; }
        public string BaseClass  { get; set; }
        public string PrimaryKeyType { get; set; }
        public string NamespaceName { get; set; }


        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Collections.ObjectModel;");
            sb.AppendLine("using Volo.Abp.Domain.Entities;");
            sb.AppendLine("using Volo.Abp.Domain.Entities.Auditing;");
            sb.AppendLine("using Volo.Abp.MultiTenancy;");
            sb.AppendLine("using JetBrains.Annotations;");
            sb.AppendLine("");
            sb.AppendLine("using Volo.Abp;");
            sb.AppendLine("");
            sb.AppendLine($"namespace {NamespaceName}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {ClassName} : {BaseClass}<{PrimaryKeyType}>");
            sb.AppendLine("    {");

            foreach (var property in CreatedProperties)
            {
                sb.Append($"        public {property.Type}");
                if(property.Nullable)
                {
                sb.Append("?");
                }
                sb.AppendLine($" {property.Name} {{ get; set; }}");

                sb.AppendLine("");
            }

            sb.Append($"        public {ClassName}({PrimaryKeyType} id ,");
            for (int i = 0; i< CreatedProperties.Count; i++)
            {
                sb.Append($"{CreatedProperties[i].Type}");
                if (CreatedProperties[i].Nullable)
                {
                    sb.Append("?");
                }
                sb.Append($" {CreatedProperties[i].Name}");
                if (CreatedProperties[i].Nullable)
                {
                    sb.Append(" = null");
                }
                if (i != CreatedProperties.Count - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(")");

            sb.AppendLine("        {");
            sb.AppendLine("");
            sb.AppendLine("            Id = id;");

            foreach (var property in CreatedProperties)
            {
                if (property.Type == "string" && !string.IsNullOrEmpty(property.MinLength.ToString()))
                {
                    sb.AppendLine($"        if ({property.Name}.Length < {property.MinLength})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            throw new ArgumentException(\"{property.Name} length must be equal to or bigger than {property.MinLength}\", {property.Name});");
                    sb.AppendLine("        }");
                    sb.AppendLine("");
                }
                if (property.Type == "string"  && !string.IsNullOrEmpty(property.MaxLength.ToString()))
                {
                    sb.AppendLine($"        if ({property.Name}.Length > {property.MaxLength})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            throw new ArgumentException($\"{property.Name} length must be equal to or lower than {property.MaxLength}\", {property.Name});");
                    sb.AppendLine("        }");
                }





                else if (property.Type != "string")
                {
                    if (!string.IsNullOrEmpty(property.MinLength.ToString()))
                    {
                        sb.AppendLine($"            if ({property.Name} < {ClassName}Consts.{property.Name}MinLength)");
                        sb.AppendLine("            {");
                        sb.AppendLine($"                throw new ArgumentOutOfRangeException(nameof{property.Name}, {property.Name}, \"The value of '{property.Name}' cannot be lower than \" + {ClassName}Consts.{property.Name}MinLength);");
                        sb.AppendLine("            }");
                    }
                    if (!string.IsNullOrEmpty(property.MinLength.ToString()))
                    {
                        sb.AppendLine($"            if ({property.Name} > {ClassName}Consts.{property.Name}MaxLength)");
                        sb.AppendLine("            {");
                        sb.AppendLine($"                throw new ArgumentOutOfRangeException(nameof{property.Name}, {property.Name}, \"The value of '{property.Name}' cannot be greater than \" + {ClassName}Consts.{property.Name}MaxLength);");
                        sb.AppendLine("            }");
                    }
                }

            }


            foreach (var property in CreatedProperties)
            {
                sb.AppendLine($"            {property.Name} = {property.Name};");
            }

            sb.AppendLine("");
            sb.AppendLine("    }");
            sb.AppendLine("}");




            return sb.ToString();
        }


    }
}
