class Program
{
  static void Main()
  {
    ReadFIle(@"C:\Projects\csharp\arquivo.txt");
  }

  private static void ReadFIle(string fileName)
  {
    using (StreamReader file = File.OpenText(fileName))
    {
      string line;
      while((line = file.ReadLine()) != null)
      {
        Console.WriteLine(line);
      }
    }
  }
};