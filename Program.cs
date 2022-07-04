class Program
{
  static void Main()
  {
    ILogger logger = new ConsoleLogger();

    BankAccount account1 = new BankAccount("Fulano", 10, logger);
    account1.Deposit(-50);
    Console.WriteLine(account1.Name);
  }
};

interface ILogger
{
  void Log(string message){
     Console.WriteLine(message);
  }
}

class FileLogger : ILogger 
{
  public void Log (string message) {
    File.AppendAllText("log.txt", message);
  }
}
class ConsoleLogger : ILogger
{
}

class BankAccount
{
  private string? name;
  private decimal balance;
  private readonly ILogger logger;
  public string? Name
  {
    get { return name; }
    private set { name = value; }
  }
  public decimal Balance
  {
    get { return balance; }
    private set { balance += value; }
  }

  public BankAccount(string name, decimal balance, ILogger logger)
  {

    if (string.IsNullOrWhiteSpace(name))
    {
      throw new Exception("Invalid name. ");
    }

    if (balance <= 0)
    {
      throw new Exception("Balance can't negative, or invalid balance");
    }

    Name = name;
    Balance = balance;
    this.logger = logger;
  }

  public void Deposit(decimal amount)
  {
    if (amount <= 0)
    {
      logger.Log($"Não é possivel depositar {amount} na conta de {Name}{Environment.NewLine}");
      return;
    }
    this.balance += amount;
  }

  public decimal getBalance()
  {
    return this.balance;
  }
}