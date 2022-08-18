namespace ElasticArray;

class IntElasticArray
{
  private int num_elems;
  private int?[] arr;

  public IntElasticArray()
  {
    arr = new int?[3]; // will grow on demand
    num_elems = 0;  // no elements in our array at the start           
  }

  public void Add(int val)
  {
    // arr.Length is the size of array (no. of elements it can take)
    // num_elems is the no. of elements currently in the array
    if (num_elems == arr.Length)
    {
      Grow(arr.Length * 2);
    }

    arr[num_elems] = val;
    num_elems++;
  }

  public bool Remove(int val)
  {
    int pos = FindFirst(val);
    if (pos == -1)
    {
      return false;
    }

    do
    {
      num_elems--;
      ShiftLeftFrom(pos, num_elems);

      pos = FindFirst(val);
    } while (pos != -1);

    return true;
  }

  public bool RemoveAt(int pos)
  {
    if (pos >= num_elems)
    {
      return false;
    }

    num_elems--;
    ShiftLeftFrom(pos, num_elems);

    return true;
  }

  public int FindFirst(int val)
  {
    for (int i = 0; i < num_elems; i++)
    {
      if (arr[i] == val)
      {
        return i;
      }
    }

    return -1;
  }

  public void ShowContent()
  {
    Console.Write("VALUES: ");
    for (int i = 0; i < num_elems; i++)
    {
      Console.Write(arr[i] + " ");
    }
  }

  public int GetLength()
  {
    return num_elems;
  }

  protected void Grow(int new_size)
  {
    int?[] new_arr = new int?[new_size];

    // copy contents of old array into new array
    for (int i = 0; i < num_elems; i++)
    {
      new_arr[i] = arr[i];
    }

    // set 'arr' variable to point to new array
    arr = new_arr;
  }

  protected void ShiftLeftFrom(int pos, int n)
  {
    int i = 0;

    // shift all elements up by one position;
    // starting at a specific position in the array
    for (i = pos; i < n; i++)
    {
      arr[i] = arr[i + 1];
    }

    // clear last "shifted" value
    if (i < arr.Length) 
    {
      arr[i] = null;
    }
  }
}
