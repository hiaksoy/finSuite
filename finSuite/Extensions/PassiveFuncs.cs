

namespace finSuite.Extensions
{
    internal class PassiveFuncs
    {

        //// Kullanıcının girdiği numaraları parse eden metod
        //private List<int> ParseUserInput(string input)
        //{
        //    List<int> excludedProperties = new List<int>();

        //    if (!string.IsNullOrEmpty(input))
        //    {
        //        string[] parts = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //        foreach (string part in parts)
        //        {
        //            if (int.TryParse(part.Trim(), out int number))
        //            {
        //                excludedProperties.Add(number);
        //            }
        //        }
        //    }

        //    return excludedProperties;
        //}



        //public void ExtractProperties(string filePath)
        //{


        //    List<string> properties = new List<string>();

        //    string[] lines = File.ReadAllLines(filePath);

        //    foreach (string line in lines)
        //    {
        //        if (IsProperty(line))
        //        {
        //            properties.Add(line.Trim());
        //        }
        //    }

        //    //Console.WriteLine("Property'ler:");
        //    //foreach (var prop in properties)
        //    //{
        //    //  Console.WriteLine(prop);
        //    //}
        //}

        //public void changeFileName()
        //{
        //    int sayac = 0;
        //    string file;
        //    int choose = 0;
        //    string newFile;

        //    Console.WriteLine("Değişecek dosyanın adını giriniz.");
        //    string fileName = Console.ReadLine();
        //    string filePath = $"../../../{fileName}.cs";
        //    file = File.ReadAllText(filePath);

        //    Console.WriteLine(file);

        //    Console.WriteLine("Değiştirmek istediğiniz kelimeyi giriniz.");
        //    string wordForChange = Console.ReadLine();


        //    bool x = true;

        //    while (x)
        //    {
        //        Console.WriteLine("Kelimeyi komple değiştirmek istiyorsanız 1'e " +
        //          "Sonuna ek eklemek istiyorsanız 2'ye basınız");
        //        choose = int.Parse(Console.ReadLine());

        //        if (choose == 1 || choose == 2)
        //        {
        //            x = false;
        //        }
        //        else
        //        {
        //            Console.WriteLine("1 veya 2 giriniz");
        //        }
        //    }

        //    if (choose == 1)
        //    {
        //        Console.WriteLine("Kelimenin yeni halini giriniz.");
        //        string newWord = Console.ReadLine();
        //        string newPath = $"../../../{newWord}.cs";
        //        newFile = file.Replace(wordForChange, newWord);
        //        File.WriteAllText(newPath, newFile);
        //        Console.WriteLine(newFile);
        //    }
        //    if (choose == 2)
        //    {
        //        Console.WriteLine("Kelimenin sonuna geleck Eki giriniz.");
        //        string sub = Console.ReadLine();
        //        string newWord = wordForChange + sub;
        //        string newPath = $"../../../{newWord}.cs";
        //        newFile = file.Replace(wordForChange, newWord);
        //        File.WriteAllText(newPath, newFile);
        //        Console.WriteLine(newFile);
        //    }
        //}



    }
}
