using System;

/*
    If using Visual Studio Code as IDE,
        - dotnet new console --framework net6.0
        - dotnet run
*/

namespace ElasticArray
{
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
           
            if (input != null) {
                try {
                    choice = int.Parse(input);
                }
                catch (FormatException) {
                    Console.WriteLine(">>> PLEASE PROVIDE NUMBER INPUTS. <<<");                    
                }                
            }

            return choice;
        }
    }

    class CommandLine
    {
        private IntElasticArray elastic_arr;

        public CommandLine()
        {
            elastic_arr = new IntElasticArray();
        }

        public void ShowMenu()
        {
            while (true) {
                string prompt = "\n\nWHAT WOULD YOU LIKE TO DO?\n\n" +
                    "1. ADD INTEGER\n" +
                    "2. REMOVE INTEGERS OF VALUE X\n" +
                    "3. REMOVE INTEGER AT POSITION X\n" +
                    "4. FIND INTEGER\n" +
                    "5. HOW MANY ELEMENTS RIGHT NOW?\n" +
                    "6. SHOW CONTENT\n\n" +
                    "PLEASE CHOOSE ONE: ";

                int? choice = Program.GetIntegerInput(prompt);

                if (choice != null) {
                    if (choice >= 1 && choice <= 6) {
                        OnMenuSelect((int) choice);
                    }
                    else {
                        Console.WriteLine(">>> INVALID CHOICE. <<<");    
                    }
                }
            }
        }

        public void AddInteger() {
            int? val = Program.GetIntegerInput("\nENTER INTEGER TO ADD: ");

            if (val == null) {
                Console.WriteLine(">>> INVALID INPUT. <<<");
            }
            else {
                elastic_arr.Add((int) val);
                Console.WriteLine(">>> INTEGER ADDED. <<<");
            }
        }

        public void RemoveInteger() {
            int? val = Program.GetIntegerInput("\nENTER INTEGER TO REMOVE: ");

            if (val == null) {
                Console.WriteLine(">>> INVALID INPUT. <<<");
            }
            else {
                if (elastic_arr.Remove((int) val)) {
                    Console.WriteLine(">>> INTEGER REMOVED. <<<");
                }
                else {
                    Console.WriteLine(">>> INTEGER NOT FOUND. <<<");
                }                        
            }
        }

        public void RemoveIntegerAtPos() {
            int? val = Program.GetIntegerInput("\nENTER POSITION (ZERO-BASED): ");

            if (val == null) {
                Console.WriteLine(">>> INVALID INPUT. <<<");
            }
            else {
                if (elastic_arr.RemoveAt((int) val)) {
                    Console.WriteLine(">>> INTEGER REMOVED. <<<");
                }
                else {
                    Console.WriteLine(">>> INVALID POSITION GIVEN. <<<");                            
                }
            }
        }

        public void FindInteger() {
            int? val = Program.GetIntegerInput("\nENTER INTEGER TO FIND: ");

            if (val == null) {
                Console.WriteLine(">>> INVALID INPUT. <<<");
            }
            else {
                int pos = elastic_arr.FindFirst((int) val);
                if (pos != -1) {
                    Console.WriteLine(String.Format(
                        ">>> INTEGER {0} FOUND AT POSITION {1}. <<<", val, pos));
                }
                else {
                    Console.WriteLine(String.Format(
                        ">>> INTEGER {0} IS NOT FOUND. <<<", val));
                }
            }
        }

        public void ShowListSize() {
            Console.WriteLine(String.Format(
                ">>> TOTAL COUNT: {0}. <<<", elastic_arr.GetLength()));            
        }

        public void ShowContent() {
            if (elastic_arr.GetLength() == 0) {
                Console.WriteLine(">>> THE ARRAY IS EMPTY. <<<");
            }
            else {
                elastic_arr.ShowContent();
                Console.WriteLine();    // add a new line for spacing
            }
        }

        public void OnMenuSelect(int choice)
        {
            switch (choice) {
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

    class IntElasticArray
    {
        public const int INIT_SZ = 5;   
        private int num_elems;
        private int[] arr;

        public IntElasticArray()
        {
            arr = new int[INIT_SZ]; // will grow on demand
            num_elems = 0;  // no elements in our array at the start           
        }

        public void Add(int val)
        {
            if (num_elems == arr.Length) {
                Grow(arr.Length * 2);
            }

            arr[num_elems] = val;
            num_elems++;
        }

        public bool Remove(int val)
        {
            int pos = FindFirst(val);
            if (pos == -1) {
                return false;
            }

            do {
                num_elems--;
                ShiftLeftFrom(pos, num_elems);

                pos = FindFirst(val);
            } while (pos != -1);

            return true;
        }

        public bool RemoveAt(int pos)
        {
            if (pos >= num_elems) {
                return false;
            }

            num_elems--;
            ShiftLeftFrom(pos, num_elems);

            return true;
        }

        public int FindFirst(int val)
        {
            for (int i=0; i<num_elems; i++) {
                if (arr[i] == val) {
                    return i;
                }
            }

            return -1;
        }

        public void ShowContent()
        {
            Console.Write("VALUES: ");
            for (int i = 0; i < num_elems; i++) {
                Console.Write(arr[i] + " ");
            }
        }

        public int GetLength()
        {
            return num_elems;
        }

        protected void Grow(int new_size)
        {
            int[] new_arr = new int[new_size];

            // copy contents of old array into new array
            for (int i = 0; i < num_elems; i++) {
                new_arr[i] = arr[i];
            }

            // set 'arr' variable to point to new array
            arr = new_arr;
        }

        protected void ShiftLeftFrom(int pos, int n)
        {
            // shift all elements up by one position;
            // starting at a specific position in the array
            for (int i=pos; i<n; i++) {
                arr[i] = arr[i + 1];
            }
        }
    }
}
