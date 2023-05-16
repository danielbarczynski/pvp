
string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
string RED = Console.IsOutputRedirected ? "" : "\x1b[91m";
string GREEN = Console.IsOutputRedirected ? "" : "\x1b[92m";
string YELLOW = Console.IsOutputRedirected ? "" : "\x1b[93m";
string BLUE = Console.IsOutputRedirected ? "" : "\x1b[94m";
string MAGENTA = Console.IsOutputRedirected ? "" : "\x1b[95m";
string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
string GREY = Console.IsOutputRedirected ? "" : "\x1b[97m";
string BOLD = Console.IsOutputRedirected ? "" : "\x1b[1m";
string NOBOLD = Console.IsOutputRedirected ? "" : "\x1b[22m";
string UNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[4m";
string NOUNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[24m";
string REVERSE = Console.IsOutputRedirected ? "" : "\x1b[7m";
string NOREVERSE = Console.IsOutputRedirected ? "" : "\x1b[27m";


int playerHp = 100;
int enemyHp = 120;
Console.WriteLine("Rozpoczęłą się walka!");
Console.WriteLine("Zdrowie gracza: " + playerHp);
Console.WriteLine("Zdrowie przecwinika: " + enemyHp);

var rnd = new Random();
var rnd2 = new Random();

Console.WriteLine("Atakujesz! Wciśnij 'a' aby uderzyć\n");

while (true)
{
  int dmg = rnd.Next(5, 11);
  int crit = rnd.Next(0, 5); // 20% chance
  int enemyDmg = rnd.Next(4, 8);
  int enemyCrit = rnd.Next(0, 10); // 10% chance

  var key = Console.ReadKey(true);
  Console.WriteLine($"{NORMAL}Atakujesz");

  if (key.KeyChar == 'a')
  {
    if (crit == 4)
    {
      Console.WriteLine($"{YELLOW}+Cios krytyczny {NORMAL}");
      dmg *= 2;
    }

    Console.WriteLine("Zadano " + dmg + " obrażeń");
    enemyHp -= dmg;
    Console.WriteLine($"Zdrowie przeciwnika: {RED}" + enemyHp);
  }

  if (enemyHp <= 0)
  {
    Console.WriteLine($"{NORMAL}Walka zakończona. Zwyciężyeś");
    break;
  }

  Console.WriteLine();
  Console.WriteLine($"{NORMAL}Przeciwnik atakuje");
  if (enemyCrit == 4)
  {
    Console.WriteLine($"{YELLOW}+Cios krytyczny{NORMAL}");
    enemyDmg *= 2;
  }

  Console.WriteLine("Zadano " + enemyDmg + " obrażeń");
  playerHp -= enemyDmg;
  Console.WriteLine($"Twoje zdrowie: {GREEN}" + playerHp + $"\n");

  if (playerHp <= 0)
  {
    Console.WriteLine($"{NORMAL} Walka zakończona. Zwyciężył przeciwnik");
    break;
  }
}

