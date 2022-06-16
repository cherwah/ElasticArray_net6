using System;

/*
    If using Visual Studio Code as IDE,
        - dotnet new console --framework net6.0
        - dotnet run
*/

namespace ElasticArray;

class Program
{
  static void Main(string[] args)
  {
    new CommandLine().ShowMenu();
  }

  static public int? GetIntegerInput(string prompt)
  {
    int? choice = null;

    Console.Write(prompt);
    string? input = Console.ReadLine();

    if (input != null)
    {
      try
      {
        choice = int.Parse(input);
      }
      catch (FormatException)
      {
        Console.WriteLine(">>> PLEASE PROVIDE NUMBER INPUTS. <<<");
      }
    }

    return choice;
  }
}


