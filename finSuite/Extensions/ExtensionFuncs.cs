using finSuite.InputClasses;

namespace finSuite.Extensions
{
    public class ExtensionFuncs
    {



        public static void ParseClassProperties(
            string filePath,
            List<string> accessModifiers,
            out ClassDatas classDatas)
        {
            classDatas = new ClassDatas(); // Initialize the out parameter
            classDatas.InheritanceList = new List<string>();
            classDatas.Properties = new Dictionary<string, string>();
            classDatas.NavigationProperties = new Dictionary<string, string>();


            // Dosyayı satır satır okuma
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                // Namespace satırını bul
                if (trimmedLine.StartsWith("namespace"))
                {
                    classDatas.NamespaceName = trimmedLine.Replace("namespace ", "").Trim();

                }

                // Sınıf adını ve kalıtım aldığı sınıf veya interfaceleri bul
                if (trimmedLine.Contains(" class "))
                {
                    // Sınıf adını 'class' kelimesinden sonra gelen kelime olarak almak
                    string[] parts = trimmedLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // 'class' kelimesini bul ve bir sonraki kısmın sınıf adı olduğunu varsay
                    int classIndex = Array.IndexOf(parts, "class");
                    if (classIndex != -1 && classIndex + 1 < parts.Length)
                    {
                        classDatas.ClassName = parts[classIndex + 1].Replace("Base", "");

                        // Sınıf adından sonra ":" varsa, bu kalıtım veya interface'leri belirtir
                        int colonIndex = Array.IndexOf(parts, ":");
                        if (colonIndex != -1 && colonIndex + 1 < parts.Length)
                        {
                            // ':' sonrasındaki tüm kısımları kalıtım veya interface listesine ekle
                            for (int i = colonIndex + 1; i < parts.Length; i++)
                            {
                                classDatas.InheritanceList.Add(parts[i].Trim(','));
                            }
                        }
                    }
                }

                // Property olan satırları bul ve property türlerini ve adlarını dictionary'ye ekle
                if (IsProperty(trimmedLine, out bool isNavigationProperty))
                {
                    // Erişim belirleyicisini kaldırmak için satırı parçalara ayırma
                    string[] parts = trimmedLine.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    // Erişim belirleyiciyi çıkarıp tür ve isim almak için index hesaplama
                    string matchingModifier = accessModifiers.FirstOrDefault(am => trimmedLine.StartsWith(am));
                    int typeIndex = matchingModifier != null ? matchingModifier.Split(' ').Length : 0;

                    if (typeIndex < parts.Length - 1) // property tanımı "type name" şeklinde olduğundan -1
                    {
                        // Tür ve isim bilgilerini al
                        string type = parts[typeIndex];
                        string name = parts[typeIndex + 1];

                        // Navigation property olup olmadığına göre ilgili dictionary'ye ekleme
                        if (isNavigationProperty)
                        {
                            classDatas.NavigationProperties[name] = type;
                        }
                        else
                        {
                            classDatas.Properties[name] = type;
                        }
                    }
                }
            }
        }

        public static CreatedClassDatas CreateClassFromEntries(
            List<CreatedProperties> createdProperties,
            string className,
            string pluralName,
            string baseClass,
            string primaryKeyType,
            string namespaceName)
        {
            CreatedClassDatas createdClassDatas = new();

            createdClassDatas.CreatedProperties = new List<CreatedProperties>();
            createdClassDatas.NavigationProperties = new Dictionary<string, string>();

            createdClassDatas.ClassName = className;
            createdClassDatas.PluralName = pluralName;
            createdClassDatas.BaseClass = baseClass;
            createdClassDatas.PrimaryKeyType = primaryKeyType;
            createdClassDatas.NamespaceName = namespaceName;

            createdClassDatas.CreatedProperties = createdProperties;

            return createdClassDatas;
        }







        private bool IsNumericType(string type)
        {
            string[] numericTypes = { "int", "long", "float", "double", "decimal", "short", "uint", "ulong", "ushort" };
            return numericTypes.Contains(type);
        }






        public static bool IsProperty(string line, out bool isNavigationProperty)
        {
            // Temel C# türleri listesi
            List<string> basicCSharpTypes = new List<string>
            {
                // ? ile nullable versiyonlar (En başta yer alacak)
                "int?", "string?", "double?", "bool?", "DateTime?", "Guid?", "float?", "long?", "short?", "byte?",
                "decimal?", "char?", "uint?", "ulong?", "ushort?", "sbyte?", "object?", "DateOnly?", "TimeOnly?","Guid?",
            
                // Normal versiyonlar (Orijinal liste)
                "int", "string", "double", "bool", "DateTime", "Guid", "float", "long", "short", "byte",
                "decimal", "char", "uint", "ulong", "ushort", "sbyte", "object", "DateOnly", "TimeOnly","Guid"
            };




            // Navigation property olup olmadığını kontrol etmek için
            isNavigationProperty = false;

            // Satırda erişim belirleyicilerinden biri olup olmadığını ve property olup olmadığını kontrol et
            bool isProperty = (line.Contains("{ get;") || line.Contains("{ get; set; }")) && finSuiteConsts.accessModifiers.Any(am => line.StartsWith(am));

            if (isProperty)
            {
                // Satırı parçalara ayır
                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                // Erişim belirleyicisini tam olarak bulabilmek için kontrol yap
                string matchingModifier = finSuiteConsts.accessModifiers.FirstOrDefault(am => line.StartsWith(am));

                int typeIndex = 0;

                if (matchingModifier != null)
                {
                    // Erişim belirleyiciye karşılık gelen sözcük sayısını hesapla
                    int accessModifierWordCount = matchingModifier.Split(' ').Length;

                    // typeIndex'i erişim belirleyici kelime sayısından sonrakine ayarla
                    typeIndex = accessModifierWordCount;
                }

                if (typeIndex < parts.Length)
                {
                    string type = parts[typeIndex];

                    // Temel C# türleri ve System namespace'ini kullanan türler navigation property değildir
                    if (!basicCSharpTypes.Contains(type) && !type.StartsWith("System."))
                    {
                        // Temel C# türü değilse, bu bir navigation property olabilir
                        isNavigationProperty = true;
                    }
                }
            }

            return isProperty;
        }


        public void ParseProperty(string propertyList, List<string> accessModifiers, out string type, out string name)
        {
            var propertyParts = propertyList.Split(' ');

            // Satırdaki erişim belirleyiciyi bul
            string matchingModifier = accessModifiers.FirstOrDefault(am => propertyList.StartsWith(am));

            // Eğer matchingModifier null değilse, bu matchingModifier'ın kelime sayısına göre type ve name belirlenir
            if (matchingModifier != null)
            {
                // matchingModifier'ın kelime sayısını al
                int modifierWordCount = matchingModifier.Split(' ').Length;

                // modifierWordCount kelime sayısına göre type ve name belirlemesi yap
                type = propertyParts[modifierWordCount];
                name = propertyParts[modifierWordCount + 1];
            }
            else
            {
                // Eğer erişim belirleyici bulunamazsa varsayılan değer atayın
                type = propertyParts[0];
                name = propertyParts[1];
            }
        }



    }
}

