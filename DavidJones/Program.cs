using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidJones
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuChoice = 0;
            int numberOfRegistrars;

            Customers[] CustomerArray = null;
            Supplier[] SupplierArray = null;


            
            //loop that starts because menuChoice doesnt equal 5 (exit)
            while (menuChoice != 5)
            {
                if (menuChoice == 0)
            // method to determine users menu choice
                menuChoice = MainMenu();

                switch (menuChoice)
                {
                    case 1:


                        // numberOfRegistrars method to determine size of the array
                        numberOfRegistrars = int.Parse(NumberOfRegistrars(menuChoice));
                        CustomerArray = new Customers[numberOfRegistrars];

                        // creates new customer objects as required
                        Customers.CreateNewCustomerObject(numberOfRegistrars, CustomerArray);

                        //menu choice 0 returns to main menu, menu choice 1 registers more customers
                        Console.WriteLine("Would you like to record anymore customers?");
                        string answer1 = Console.ReadLine();
                        if (answer1 == "yes")
                        {
                            menuChoice = 1;
                        }
                        else
                            menuChoice = 0;



                        break;





                    case 2:

                        // all exact same as case 1 except for suppliers

                        numberOfRegistrars = int.Parse(NumberOfRegistrars(menuChoice));
                        SupplierArray = new Supplier[numberOfRegistrars];

                        Supplier.CreateNewSupplierObject(numberOfRegistrars, SupplierArray);

                        Console.WriteLine("Would you like to record anymore Suppliers?");
                        string answer2 = Console.ReadLine();
                        if (answer2 == "yes")
                        {
                            menuChoice = 2;
                        }
                        else
                            menuChoice = 0;
                        break;


                    case 3:

                        // account track determines user menu choice 3 or 4 and displays accounts accordingly

                        AccountTrack(menuChoice, CustomerArray, SupplierArray);
                        menuChoice = 0;

                        break;


                    case 4:

                        AccountTrack(menuChoice, CustomerArray, SupplierArray);
                        menuChoice = 0;


                        break;

                    case 5:
                        { }
                        break;

                      Console.ReadKey();
                }
                
             }
        }




        // Main Menu Display Method
        public static int MainMenu()
        {
            string inputValue;
            int menuSelection;
            Console.Clear();
            Console.WriteLine("-------------    Welcome to David Jones tracking application.    ----------------" +
                            "\n\n      This application will let you enter customer and supplier details      "
                            + "\n             or search existing customer or supplier accounts. ");
            Console.WriteLine();
            Console.WriteLine("     Please select what you would like to do using the numpad : (1,2,3,4).");
            Console.WriteLine("\n\n\n 1.) Register a new Customer Account: " +
                           "\n 2.) Register a new Supplier Account: " +
                           "\n 3.) Track an existing Customer Account: " +
                           "\n 4.) Track an existing Supplier Account: " +
                           "\n 5.) Exit the program.");
            Console.WriteLine();
            Console.Write("---- ");
            inputValue = Console.ReadLine();
            while (int.TryParse(inputValue, out menuSelection) == false || menuSelection < 1 || menuSelection > 5)
            {
                Console.WriteLine("Please enter a number between 1 and 5.");
                Console.Write("---- ");
                inputValue = Console.ReadLine();
            }
            return menuSelection;
        }

        //Customer or Supplier Registration Choice SubProcess

        public static string NumberOfRegistrars(int menuChoice)
        {
            
            string inputValue;
            switch (menuChoice)
            {

                case 1:
                    int registrarNumber;
                    Console.WriteLine();
                    Console.WriteLine("\nYou have selected to register a new Customer Account."
                                     + "\n\nPress enter to begin: ");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-------------    David Jones tracking application   ----------------");
                    Console.WriteLine("\nHow many Customers would you like to register?");
                    Console.Write("---- ");
                    inputValue = Console.ReadLine();
                    while (int.TryParse(inputValue, out registrarNumber) == false || registrarNumber < 0)
                    {
                        Console.WriteLine("Invalid entry. Please enter the number of customers you would like to register.");
                        inputValue = Console.ReadLine();
                    }

                    break;

                case 2:
                    
                    Console.WriteLine("\nYou have selected to register a new Supplier Account."
                                     + "\n\nPress enter to begin: ");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("-------------    David Jones tracking application   ----------------");
                    Console.WriteLine("\nHow many Suppliers would you like to register?");
                    Console.Write("---- ");
                    inputValue = Console.ReadLine();
                    while (int.TryParse(inputValue, out registrarNumber) == false || registrarNumber < 0)
                    {
                        Console.WriteLine("Invalid entry. Please enter the number of suppliers you would like to register.");
                        inputValue = Console.ReadLine();
                    }
                    break;

                default: inputValue = "This is not a valid input, please try again.";
                    break;
            }
            return inputValue;
        }


        // viewing account listings subprocess
        public static void AccountTrack(int menuChoice, Customers []CustomerArray, Supplier []SupplierArray)
        {
            
            switch (menuChoice)
            {

                case 3:
                    Console.WriteLine();
                    
                                     
                    if (CustomerArray == null)
                    {
                        Console.WriteLine("There are no accounts to display.");
                        Console.WriteLine("Press enter to return to the main menu.");
                        Console.ReadLine();
                    }

                    else if (CustomerArray.Length > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Here are the existing Customer Accounts:");
                        DisplayCustomerRecords(CustomerArray);
                        Console.WriteLine();
                        Console.WriteLine("Press enter to return to the main menu.");
                        Console.ReadLine();
                    }
                    
                    
                    Console.WriteLine();

                    

                    break;

                case 4:
                    Console.WriteLine();


                    if (SupplierArray == null)
                    {
                        Console.WriteLine("There are no accounts to display.");
                        Console.WriteLine("Press enter to return to the main menu.");
                        Console.ReadLine();
                    }

                    else if (SupplierArray.Length > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Here are the existing Supplier Accounts:");
                        DisplaySupplierRecords(SupplierArray);
                        Console.WriteLine();
                        Console.WriteLine("Press enter to return to the main menu.");
                        Console.ReadLine();
                    }


                    Console.WriteLine();

                    break;      
            }
   
        }
     

     
        // method for displaying customer accounts
        public static void DisplayCustomerRecords(Customers[] CustomerArray)
        {
            for (int i = 0; i < CustomerArray.Length; i++)
            {                
                Console.WriteLine("\nCustomer Name: {0}", CustomerArray[i].CustomerName.ToString(), "\n");
                Console.WriteLine("Customer Account Number: {0} ", CustomerArray[i].CustAccNumber.ToString(), "\n");
                Console.WriteLine("Customer Remaining Account Balance: {0}", CustomerArray[i].CustomerOwing.ToString("C2"), "\n");
                Console.WriteLine(CustomerArray[i].CustCreditLimit.ToString() );
            } 
         }

        // method for displaying supplier accounts
        public static void DisplaySupplierRecords(Supplier[] SupplierArray)
        {
            for (int i = 0; i < SupplierArray.Length; i++)
            {
                Console.WriteLine("\nSupplier Name: {0}", SupplierArray[i].SupplierName.ToString(), "\n");
                Console.WriteLine("Supplier Account Number: {0} ", SupplierArray[i].SuppAccNumber.ToString(), "\n");
                Console.WriteLine("Supplier Remaining Account Balance: {0}", SupplierArray[i].SupplierOwing.ToString("C2"), "\n");
                Console.WriteLine(SupplierArray[i].SuppCreditLimit.ToString());
            }
        }


    }      
}
