class Program
{
  static void Main()
  {
    ReadFIle(1);
  }

  private static void ReadFIle(int fileNumber)
  {
    string filePath = @"C:\Projects\csharp\arquivo" +fileNumber + ".txt";

    // Verify if file exists
    if (File.Exists(filePath))
    {
      using (StreamReader file = File.OpenText(filePath))
      {
        string line;
        while ((line = file.ReadLine()) != null)
        {
          Console.WriteLine(line);
        }
      }
    }

    string filePath2 =  @"C:\Projects\csharp\arquivo" +fileNumber + 1 + ".txt";

    // Search for new
    if (File.Exists(filePath2))
    {
      ReadFIle(fileNumber + 1);
    }
  }
};