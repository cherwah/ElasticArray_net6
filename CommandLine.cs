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

      int? choice = Program.GetIntegerInput(prompt);

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

  public void AddInteger()
  {
    int? val = Program.GetIntegerInput("\nENTER INTEGER TO ADD: ");

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

  public void RemoveInteger()
  {
    int? val = Program.GetIntegerInput("\nENTER INTEGER TO REMOVE: ");

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

  public void RemoveIntegerAtPos()
  {
    int? val = Program.GetIntegerInput("\nENTER POSITION (ZERO-BASED): ");

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

  public void FindInteger()
  {
    int? val = Program.GetIntegerInput("\nENTER INTEGER TO FIND: ");

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

  public void ShowListSize()
  {
    Console.WriteLine(String.Format(
        ">>> TOTAL COUNT: {0}. <<<", elastic_arr.GetLength()));
  }

  public void ShowContent()
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

  public void OnMenuSelect(int choice)
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
