//No AI was used for this Project

//Program class containing all methods and classes
class Program
{
    //|-----------------------------------Test Plan for Main method-----------------------------------|
    //| Input                                  | Expected Output                      | Actual Output |
    //|                                                                                               |
    //| 1                                      | Water Calculator method is called      | As Expected |
    //| 2                                      | Library Catalog method is called       | As Expected |
    //| 3                                      | Hexadecimal Converter method is called | As Expected |
    //| 4                                      | Program exits                          | As Expected |
    //| Invalid input (e.g., 123456, Two, -1)  | Error message prompts for valid input  | As Expected |
    //| Invalid input (" " = Spacebar String)  | Error message prompts for valid input  | As Expected |
    //|-----------------------------------------------------------------------------------------------|

    //Main method
    static void Main()
    {
        bool exitProgram = false; // Flag to control program exit
        while (!exitProgram)
        {
            // Display menu
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Water Calculator");
            Console.WriteLine("2. Library Catalog");
            Console.WriteLine("3. Hexadecimal Converter");
            Console.WriteLine("4. Quit");
            Console.WriteLine("Please select an option (1-4): ");

            bool isValidInput = false;
            while (!isValidInput)
            {
                // Get user input and validate so that it is an integer between 1 and 4
                string? input = Console.ReadLine();
                int userInput;
                if (input != null && int.TryParse(input, out userInput) && userInput >= 1 && userInput <= 4)
                {
                    //Switch case statement to call the appropriate method
                    switch (userInput)
                    {
                        case 1:
                            waterCalc();
                            break;
                        case 2:
                            libCatalog();
                            break;
                        case 3:
                            hexaConverter();
                            break;
                        case 4:
                            // Quit the program
                            exitProgram = true;
                            Console.WriteLine("Exiting the program. Goodbye!");
                            break;
                    }
                    // Set isValidInput to true to exit the input validation loop so program can close
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4\n");
                }
            }
        }
    }


    //|---------------------Test Plan for waterCalc and other corresponding methods---------------------|
    //| Input                                | Expected Output                          | Actual Output |
    //|                                                                                                 | 
    //| Kitchen Tap                          | calcWaterUsage method is called            | As Expected |   
    //| Washing Machine                      | calcWaterUsage method is called            | As Expected |         
    //| Shower                               | calcWaterUsage method is called            | As Expected |
    //| 2                                    | Returns to main menu                       | As Expected |
    //| Invalid input                        | Error message prompts for valid input      | As Expected |
    //| (e.g., Dishwasher, Kettle, 123)                                                                 |
    //|-------------------------------------------------------------------------------------------------|
    //|--------------------------------------calcWaterUsage method--------------------------------------|
    //| Input                                | Expected Output                          | Actual Output |
    //|                                                                                                 |
    //| 1                                    | waterInputMethod1 is called                | As Expected |
    //| 2                                    | waterInputMethod2 is called                | As Expected |
    //| Invalid input (e.g., 21, one, -1)    | Error message prompts for valid input      | As Expected |
    //|-------------------------------------------------------------------------------------------------|
    //|------------------------------------waterInputMethod1 method-------------------------------------|
    //| Input                                | Expected Output                          | Actual Output |
    //|                                                                                                 |
    //| 9, 10, 2.5                           | Correct water usage and cost calculations  | As Expected |
    //| 13, 5, 3.0                           | Correct water usage and cost calculations  | As Expected |
    //| 5, 12, 2.99                          | Correct water usage and cost calculations  | As Expected |
    //| Invalid input (e.g., four, a, 5 + 5) | Error message prompts for positive number  | As Expected |
    //| Invalid input (e.g., -3, -10, -21)   | Error message prompts for positive number  | As Expected |
    //|-------------------------------------------------------------------------------------------------|
    //|------------------------------------waterInputMethod2 method-------------------------------------|
    //| Input                                | Expected Output                          | Actual Output |
    //|                                                                                                 |
    //| 50, 3, 2.5                           | Correct water usage and cost calculations  | As Expected |
    //| 21, 2, 1.5                           | Correct water usage and cost calculations  | As Expected |
    //| 25, 1, 3.25                          | Correct water usage and cost calculations  | As Expected |
    //| Invalid input (e.g., ten, b, 99 * 2) | Error message prompts for positive number  | As Expected |
    //| Invalid input (e.g., -5, -2, -10)    | Error message prompts for positive number  | As Expected |
    //|-------------------------------------------------------------------------------------------------|

    //Water calculator method
    static void waterCalc()
    {
        bool exitWaterLoop = false;
        while (!exitWaterLoop)
        {
            Console.WriteLine("\n==============================================================\n");
            Console.WriteLine("You selected Water Calculator");
            Console.WriteLine("\nThe appliances are as follows:\n->Kitchen Tap<-\n->Washing Machine<-\n->Shower<-");
            while (true)
            {
                Console.WriteLine("\nPlease Enter an Appliance Name: ");
                string? appInp = Console.ReadLine();
                string appliance = appInp ?? string.Empty;
                switch (appliance.ToLower())
                {
                    case "kitchen tap":
                        Console.WriteLine("Kitchen Tap selected");
                        calcWaterUsage();
                        break;
                    case "washing machine":
                        Console.WriteLine("Washing Machine selected");
                        calcWaterUsage();
                        break;
                    case "shower":
                        Console.WriteLine("Shower selected");
                        calcWaterUsage();
                        break;
                    default:
                        Console.WriteLine("This is not an appliance that has been listed");
                        continue;
                }

                Console.WriteLine("\n==============================================================\n");

                // Ask user if they want to return to main menu
                Console.WriteLine("Press 2 if you wish to return to the main menu: ");
                string? exitChoice2 = Console.ReadLine();
                if (exitChoice2 == "2")
                {
                    exitWaterLoop = true;
                    break;
                }
            }
        }
    }

    //Calculate water usage method
    static void calcWaterUsage()
    {
        int mode;
        // Will keep asking for mode until valid input is given
        while (true)
        {
            Console.WriteLine("\nSelect Mode:\n1. Litres per minute\n2. Litres per cycle");
            string? modeInput = Console.ReadLine();
            if (modeInput != null && int.TryParse(modeInput, out mode) && (mode == 1 || mode == 2))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 1 or 2");
            }
        }

        // Get inputs based on selected mode and run the corresponding method
        if (mode == 1)
        {
            waterInputMethod1();
        }

        // If mode 2 is selected run the corresponding method
        else if (mode == 2)
        {
            waterInputMethod2();
        }
    }

    //Method to determine cost based on Litres per MINUTE
    static void waterInputMethod1()
    {
        double flowRate;
        // Will keep asking for flow rate until valid input is given
        while (true)
        {
            Console.WriteLine("Enter the flow rate in litres per minute: ");
            string? flowInput = Console.ReadLine();
            if (flowInput != null && double.TryParse(flowInput, out flowRate) && flowRate > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive number for flow rate");
            }
        }

        double duration;
        // Will keep asking for duration until valid input is given
        while (true)
        {
            Console.WriteLine("Enter the minutes used per day: ");
            string? durationInput = Console.ReadLine();
            if (durationInput != null && double.TryParse(durationInput, out duration) && duration > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive number for duration");
            }
        }

        double price;
        // Will keep asking for price until valid input is given
        while (true)
        {
            Console.WriteLine("Enter water price per 1000 litres: ");
            string? priceInput = Console.ReadLine();
            if (priceInput != null && double.TryParse(priceInput, out price) && price > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive number for price per 1000 litres");
            }
        }

        // Calculate water usage and costs
        double dailyLitres = Math.Round(flowRate * duration, 2);
        double monthlyLitres = Math.Round(dailyLitres * 30, 2);
        double annualLitres = Math.Round(dailyLitres * 365, 2);

        double dailyCost = Math.Round(dailyLitres / 1000 * price, 2);
        double monthlyCost = Math.Round(monthlyLitres / 1000 * price, 2);
        double annualCost = Math.Round(annualLitres / 1000 * price, 2);

        // Output results
        Console.WriteLine("\nTotal water used in a day: {0} litres", dailyLitres);
        Console.WriteLine("Total water used in a month: {0} litres", monthlyLitres);
        Console.WriteLine("Total water used in a year: {0} litres", annualLitres);

        Console.WriteLine("\nCost of water used in a day: £{0}", dailyCost);
        Console.WriteLine("Cost of water used in a month: £{0}", monthlyCost);
        Console.WriteLine("Cost of water used in a year: £{0}", annualCost);
    }

    //Method to determine cost based on Litres per CYCLE 
    static void waterInputMethod2()
    {
        double volumePerCycle;
        // Will keep asking for volume per cycle until valid input is given
        while (true)
        {
            Console.WriteLine("Enter the volume per cycle: ");
            string? volumeInput = Console.ReadLine();
            if (volumeInput != null && double.TryParse(volumeInput, out volumePerCycle) && volumePerCycle > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive number for volume per cycle");
            }
        }

        double cyclesPerDay;
        // Will keep asking for cycles per day until valid input is given
        while (true)
        {
            Console.WriteLine("Enter the cycles used per day: ");
            string? cyclesInput = Console.ReadLine();
            if (cyclesInput != null && double.TryParse(cyclesInput, out cyclesPerDay) && cyclesPerDay > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive number for cycles per day");
            }
        }

        double price;
        // Will keep asking for price until valid input is given
        while (true)
        {
            Console.WriteLine("Enter water price per 1000 litres: ");
            string? priceInput = Console.ReadLine();
            if (priceInput != null && double.TryParse(priceInput, out price) && price > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive number for price per 1000 litres");
            }
        }

        // Calculate water usage and costs
        double dailyVolume = Math.Round(volumePerCycle * cyclesPerDay, 2);
        double monthlyVolume = Math.Round(dailyVolume * 30, 2);
        double annualVolume = Math.Round(dailyVolume * 365, 2);

        double dailyCost = Math.Round(dailyVolume / 1000 * price, 2);
        double monthlyCost = Math.Round(monthlyVolume / 1000 * price, 2);
        double annualCost = Math.Round(annualVolume / 1000 * price, 2);

        // Output results
        Console.WriteLine("\nTotal water used in a day: {0} litres", dailyVolume);
        Console.WriteLine("Total water used in a month: {0} litres", monthlyVolume);
        Console.WriteLine("Total water used in a year: {0} litres", annualVolume);

        Console.WriteLine("\nCost of water used in a day: £{0}", dailyCost);
        Console.WriteLine("Cost of water used in a month: £{0}", monthlyCost);
        Console.WriteLine("Cost of water used in a year: £{0}", annualCost);
    }


//|-------------------------------------Test Plan for hexaConverter method------------------------------------|
//| Input                                    | Expected Output                                | Actual Output |
//|                                                                                                           |
//| 21                                       | Correct hexadecimal value (15)                   | As Expected |
//| 2                                        | Correct hexadecimal value (2)                    | As Expected |
//| 8745                                     | Correct hexadecimal value (2229)                 | As Expected |
//| 10990                                    | Correct hexadecimal value (2AEE)                 | As Expected |
//| 300                                      | Correct hexadecimal value (12C)                  | As Expected |
//| 0                                        | Correct hexadecimal value (0)                    | As Expected |
//| Invalid input (e.g., -10, abc)           | Error message prompts for positive integer       | As Expected |
//| 2 (When prompted to Return to main menu) | Returns to main menu                             | As Expected |
//|-----------------------------------------------------------------------------------------------------------|

    //Hexadecimal converter method
    static void hexaConverter()
    {
        bool exitHexLoop = false;
        while (!exitHexLoop)
        {
            Console.WriteLine("==============================================================");
            Console.WriteLine("You selected Hexadecimal Converter\n");

            Console.WriteLine("Enter an integer to convert to hexadecimal: ");
            bool isValidInput1 = false;
            while (!isValidInput1)
            {
                string? input = Console.ReadLine();
                // Validate input to ensure it is a positive integer
                if (input != null && int.TryParse(input, out int number) && number >= 0)
                {
                    //Array of hexadecimal digits
                    string hexDigits = "0123456789ABCDEF";
                    // Variable to store the hexadecimal value
                    string hexValue = "";
                    //Create a temporary variable to hold the number
                    int temp = number;

                    //If the number entered is 0, the hexadecimal value is also 0
                    if (temp == 0)
                    {
                        hexValue = "0";
                    }
                    else
                    {
                        //While temp is greater than 0, divide by 16 and get the remainder to find the hexadecimal digit
                        while (temp > 0)
                        {
                            int remainder = temp % 16; // Get the remainder
                            hexValue = hexDigits[remainder] + hexValue; // Get the corresponding hex digit and append to the front of hexValue string
                            temp /= 16;
                        }
                    }
                    Console.WriteLine("The hexadecimal value of {0} is: {1}\n", number, hexValue);
                    Console.WriteLine("==============================================================");
                    isValidInput1 = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer\n");
                }
            }
            // Ask user if they want to convert another number or return to main menu
            Console.WriteLine("Press 2 if you wish to return to the main menu: ");
            string? exitChoice = Console.ReadLine();
            if (exitChoice == "2")
            {
                exitHexLoop = true;
            }
        }
    }


//|----------------------------------------Test Plan for libCatalog method----------------------------------------|
//| Input                                                  | Expected Output                      | Actual Output |
//|                                                                                                               |
//| 1                                                      | Add Book prompts and adds book         | As Expected |
//| 2                                                      | showBooks method is called             | As Expected |
//| 3                                                      | Returns to main menu                   | As Expected |
//| Invalid input (e.g., 4, a, 0)                          | Error message prompts for valid input  | As Expected |
//|---------------------------------------------------------------------------------------------------------------|
//|---------------------------------------------Case 1 (Adding Books)---------------------------------------------|
//| Input                                                          | Expected Output              | Actual Output |
//|                                                                                                               |
//| Fiction, Fantasy, How To Train Your Dragon, Cressida Cowel     | Book added successfully!       | As Expected |
//| Non-Fiction, Biography, The Diary of a Young Girl, Anne Frank  | Book added successfully!       | As Expected |
//| f, Mystery, The Hound of the Baskervilles, Arthur Conan Doyle  | Book added successfully!       | As Expected |
//| n, Science, A Brief History of Time, Stephen Hawking           | Book added successfully!       | As Expected |
//| Gibberish, Everything, Invalid Book Title, The Ocean           | Invalid input. Book not added  | As Expected |
//| fitcion, Adventure, Treasure Island, Robert Louis Stevenson    | Invalid input. Book not added  | As Expected |
//|---------------------------------------------------------------------------------------------------------------|
//|------------------------------------------------showBooks Method-----------------------------------------------|
//| Input                                         | Expected Output                               | Actual Output |
//|                                                                                                               |
//| 1, Fantasy                                    | Will output all Fantasy books' Title and author | As Expected |
//|                                                  if they are in the List                                      |
//| 1, Biography                                  | Will output all Biography books' Title and      | As Expected |
//|                                                  author if they are in the List                               |
//| 2                                             | Displays all books in the catalog               | As Expected |
//| Invalid input (e.g., 3, a, -107)              | Error message prompts for valid input           | As Expected |
//|---------------------------------------------------------------------------------------------------------------|

    //Library catalog method
    static void libCatalog()
    {
        Console.WriteLine("You selected Library Catalog");

        List<Book> books = new List<Book>();
        bool exitLibLoop = false;
        while (!exitLibLoop)
        {
            Console.WriteLine("\n==============================================================\n");
            Console.WriteLine("Library Catalog Menu:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Display Books");
            Console.WriteLine("3. Return to Main Menu");
            Console.WriteLine("Please select an option (1-3): ");

            string? input = Console.ReadLine();
            int bookInput;
            if (input != null && int.TryParse(input, out bookInput) && bookInput >= 1 && bookInput <= 3)
            {
                switch (bookInput)
                {
                    // Add Book to the list 
                    case 1:
                        Console.WriteLine("Enter Book Type (Fiction/ Non-Fiction): ");
                        string? type = Console.ReadLine();
                        //Make input lower case for easier comparison 
                        type = type?.ToLower();

                        // Take various inputs for different ways of entering Fiction/Non-Fiction 
                        string normalisedType = type switch
                            {
                                "fiction" => "Fiction",
                                "f" => "Fiction",
                                "non-fiction" => "Non-Fiction",
                                "non fiction" => "Non-Fiction",
                                "nonfiction" => "Non-Fiction",
                                "n" => "Non-Fiction",
                                _ => string.Empty
                            };

                        Console.WriteLine("Enter Book Genre: ");
                        string? genre = Console.ReadLine();
                        Console.WriteLine("Enter Book Title: ");
                        string? title = Console.ReadLine();
                        Console.WriteLine("Enter Book Author: ");
                        string? author = Console.ReadLine();

                        if ((normalisedType == "Fiction" || normalisedType == "Non-Fiction")  && genre != null && title != null && author != null)
                        {
                            books.Add(new Book(normalisedType, genre, title, author));
                            Console.WriteLine("Book added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("\n>>>>>Invalid input. Book not added<<<<<");
                        }
                        break;

                    // Display Books
                    case 2:
                        showBooks(books);
                        break;

                    // Return to Main Menu
                    case 3:
                        exitLibLoop = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 3\n");
                        break;
                }
            }

            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3\n");
            }
        }
    }

    // Method to show books based on user choice
    static void showBooks(List<Book> books)
    {
        bool exitLibLoop = false;
        while (!exitLibLoop)
        {
            Console.WriteLine("\n==============================================================\n");
            Console.WriteLine("Displaying Books Menu:");
            Console.WriteLine("1. Display Books By Genre");
            Console.WriteLine("2. Display All Books");
            Console.WriteLine("Please select an option (1 or 2): ");

            string? displayInput = Console.ReadLine();
            int displayBookInput;
            // Get user input and validate so that it is either integer 1 or 2
            if (displayInput != null && int.TryParse(displayInput, out displayBookInput) && displayBookInput >= 1 && displayBookInput <= 2)
            {
                switch (displayBookInput)
                {
                    // Display books by genre from the list 
                    case 1:        
                        Console.WriteLine("Enter Genre to filter by: ");
                        string? genreFilter = Console.ReadLine();
                        if (genreFilter != null)
                        {
                            //Use Lambda expression to select the genre from list of objects
                            var filteredBooks = books.Where(b => b.GetGenre() == genreFilter);

                            Console.WriteLine($"\nBooks in Genre '{genreFilter}':\n");
                            foreach (var book in filteredBooks)
                            {
                                //Only return book Title and Author for specific Genre
                                Console.WriteLine($"Title: {book.GetTitle()}, \nAuthor: {book.GetAuthor()}, \n-------------------------");
                            }
                            Console.WriteLine($"Total number of books in genre '{genreFilter}': {filteredBooks.Count()}\n");
                        }
                        else
                        {
                            Console.WriteLine("There are no books in this genre\n");
                        }
                        break;

                    // Display All Books in the List
                    case 2:
                        Console.WriteLine("\nBooks in Catalog:\n");
                        foreach (var book in books)
                        {
                            Console.WriteLine($"Type: {book.GetBookType()}, Genre: {book.GetGenre()}, Title: {book.GetTitle()}, Author: {book.GetAuthor()}");
                        }
                        Console.WriteLine($"\nTotal number of books: {books.Count}");
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please enter either 1 and 2\n");
                        break;
                }
            }

            else
            {
                Console.WriteLine("Invalid input. Please enter either 1 and 2\n");
            }

            // Allows user to return to the Library Catalogue menu to see if they want to add more books etc
            Console.WriteLine("\nPress 2 if you wish to return to the Library menu: ");
            string? exitChoice3 = Console.ReadLine();
            if (exitChoice3 == "2")
            {
                exitLibLoop = true;
            }
        }
    }

    // Book class for problem 3
    private class Book
    {
        private string pType;
        private string pGenre;
        private string pTitle;
        private string pAuthor;

        public Book(string type, string genre, string title, string author)
        {
            pType = type;
            pGenre = genre;
            pTitle = title;
            pAuthor = author;
        }

        public string GetTitle()
        {
            return pTitle;
        }

        public string GetAuthor()
        {
            return pAuthor;
        }

        public string GetGenre()
        {
            return pGenre;
        }

        public string GetBookType()
        {
            return pType;
        }
    }

}