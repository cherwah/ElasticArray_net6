namespace ElasticArray;

class CommandLine
{
  private IntElasticArray elastic_arr;

  public CommandLine()
  {
    elastic_arr = new IntElasticArray();
  }

  public void ShowMenu()
  {
    while (true)
    {
      string prompt = "\n\nWHAT WOULD YOU LIKE TO DO?\n\n" +
          "1. ADD INTEGER\n" +
          "2. REMOVE INTEGERS OF VALUE X\n" +
          "3. REMOVE INTEGER AT POSITION X\n" +
          "4. FIND INTEGER\n" +
          "5. HOW MANY ELEMENTS RIGHT NOW?\n" +
          "6. SHOW CONTENT\n\n" +
          "PLEASE CHOOSE ONE: ";

      int? choice = GetInput(prompt);

      if (choice != null)
      {
        if (choice >= 1 && choice <= 6)
        {
          OnMenuSelect((int)choice);
        }
        else
        {
          Console.WriteLine(">>> INVALID CHOICE. <<<");
        }
      }
    }
  }

  public int? GetInput(string prompt)
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

  protected void AddInteger()
  {
    int? val = GetInput("\nENTER INTEGER TO ADD: ");

    if (val == null)
    {
      Console.WriteLine(">>> INVALID INPUT. <<<");
    }
    else
    {
      elastic_arr.Add((int)val);
      Console.WriteLine(">>> INTEGER ADDED. <<<");
    }
  }

  protected void RemoveInteger()
  {
    int? val = GetInput("\nENTER INTEGER TO REMOVE: ");

    if (val == null)
    {
      Console.WriteLine(">>> INVALID INPUT. <<<");
    }
    else
    {
      if (elastic_arr.Remove((int)val))
      {
        Console.WriteLine(">>> INTEGER REMOVED. <<<");
      }
      else
      {
        Console.WriteLine(">>> INTEGER NOT FOUND. <<<");
      }
    }
  }

  protected void RemoveIntegerAtPos()
  {
    int? val = GetInput("\nENTER POSITION (ZERO-BASED): ");

    if (val == null)
    {
      Console.WriteLine(">>> INVALID INPUT. <<<");
    }
    else
    {
      if (elastic_arr.RemoveAt((int)val))
      {
        Console.WriteLine(">>> INTEGER REMOVED. <<<");
      }
      else
      {
        Console.WriteLine(">>> INVALID POSITION GIVEN. <<<");
      }
    }
  }

  protected void FindInteger()
  {
    int? val = GetInput("\nENTER INTEGER TO FIND: ");

    if (val == null)
    {
      Console.WriteLine(">>> INVALID INPUT. <<<");
    }
    else
    {
      int pos = elastic_arr.FindFirst((int)val);
      if (pos != -1)
      {
        Console.WriteLine(String.Format(
            ">>> INTEGER {0} FOUND AT POSITION {1}. <<<", val, pos));
      }
      else
      {
        Console.WriteLine(String.Format(
            ">>> INTEGER {0} IS NOT FOUND. <<<", val));
      }
    }
  }

  protected void ShowListSize()
  {
    Console.WriteLine(String.Format(
        ">>> TOTAL COUNT: {0}. <<<", elastic_arr.GetLength()));
  }

  protected void ShowContent()
  {
    if (elastic_arr.GetLength() == 0)
    {
      Console.WriteLine(">>> THE ARRAY IS EMPTY. <<<");
    }
    else
    {
      elastic_arr.ShowContent();
      Console.WriteLine();    // add a new line for spacing
    }
  }

  protected void OnMenuSelect(int choice)
  {
    switch (choice)
    {
      case 1:
        AddInteger();
        break;

      case 2:
        RemoveInteger();
        break;

      case 3:
        RemoveIntegerAtPos();
        break;

      case 4:
        FindInteger();
        break;

      case 5:
        ShowListSize();
        break;

      case 6:
        ShowContent();
        break;
    }
  }
}
