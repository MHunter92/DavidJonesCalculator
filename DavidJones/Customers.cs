using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidJones
{
    class Customers
    { // default constructor
        public Customers()
        {
            Console.WriteLine("");
        }

        //secondary constructor
        public Customers(string custName, int accNumber, double accBalance, double totalPayments,
            double totalPurchases, double amountOwing, string custCreditLimit)
        {

            CustomerName = custName;
            CustAccNumber = accNumber;
            CustAccBalance = accBalance;
            CustTotalPurchases = totalPurchases;
            CustTotalPayments = totalPayments;
            CustomerOwing = amountOwing;
            CustCreditLimit = custCreditLimit;


        }







        // field of variables

        private string custName, custCreditLimit;
        private int accNumber;
        private double accBalance, totalPurchases, totalPayments;
        private double amountOwing;




        // get set variables 


        public string CustCreditLimit
        {
            get
            {
                return custCreditLimit;
            }
            set
            {
                custCreditLimit = value;

            }
        }
        public double CustomerOwing
        {
            get
            {
                return amountOwing;
            }
            set
            {
                amountOwing = value;
            }
        }
        public string CustomerName
        {
            get
            {
                return custName;
            }

            set
            {
                custName = value;
            }
        }

        public int CustAccNumber
        {
            get
            {
                return accNumber;
            }
            set
            {
                accNumber = value;
            }
        }

        public double CustAccBalance
        {
            get
            {
                return accBalance;
            }
            set
            {
                accBalance = value;
            }
        }

        public double CustTotalPurchases
        {
            get
            {
                return totalPurchases;
            }
            set
            {
                totalPurchases = value;
            }
        }

        public double CustTotalPayments
        {
            get
            {
                return totalPayments;
            }
            set
            {
                totalPayments = value;
            }
        }

        //methods for getting customer details 
        public static string GetCustName(string custOrSupp)
        {
            string name;
            Console.WriteLine("\nPlease enter the name of the {0} ", custOrSupp);
            name = Console.ReadLine();
            while (name.Length < 6 || name.Length > 15)
            {
                Console.WriteLine("Invalid entry. \n Your account name must be between 6 and 15 characters.");
                name = Console.ReadLine();
            }
            return name;
        }



        public static int GetCustAccNumber(string details)
        {
            string inputValue;
            int accNumber;
            Console.WriteLine("\nPlease enter the {0}", details);
            inputValue = Console.ReadLine();
            while (int.TryParse(inputValue, out accNumber) == false || inputValue == "" == true || inputValue.Length != 6 || inputValue[0] != '1')
            {
                Console.WriteLine("Invalid entry. \n Your account number will be six digits and begin with a 1."
                    + "\n Please enter your account number.");
                inputValue = Console.ReadLine();

            }
            return accNumber;
        }

        public static double GetOtherDetails(string details)
        {
            string inputValue;
            double accDetails;
            Console.WriteLine("\nPlease enter the {0}", details);
            Console.Write("$"); inputValue = Console.ReadLine();
            while (double.TryParse(inputValue, out accDetails) == false || accDetails < 0)
            {
                Console.WriteLine("Invalid entry, this cannot be less than $0.");
                inputValue = Console.ReadLine();
            }
            return accDetails;
        }

       
        // method for creating new customerObjects
        public static void CreateNewCustomerObject(int numberOfRegistrars,
                                               Customers[] CustomerArray)
        {
            for (int i = 0; i < numberOfRegistrars; i++)
            {
                const double creditLimit = 400;
                string errorMessage;

                string customerName = GetCustName("customer: ");
                int accNumber = GetCustAccNumber("customer account number: ");
                double accBalance = GetOtherDetails("amount the Customer currently owes David Jones (account Balance): ");
                double totalPurchases = GetOtherDetails("customer total purchases: ");
                double totalPayments = GetOtherDetails("customer total payments: ");

                double totalBalance = accBalance + totalPurchases;
                while (totalPayments > totalBalance)
                {
                    Console.WriteLine("This is not a valid entry, payments cannot be more than balance + purchases");
                    totalPayments = GetOtherDetails("customer total payments: ");
                }
                Console.WriteLine("\nCustomer registered!");
                Console.ReadLine();
                Console.Clear();
                double amountOwing =
                    (accBalance + totalPurchases)
                       - totalPayments;

                if (amountOwing > creditLimit)
                    errorMessage = ("Your credit limit has been exceeded. ");

                else
                    errorMessage = ("");

                string custCreditLimit = errorMessage;

                CustomerArray[i] = new Customers(customerName, accNumber, accBalance, totalPayments,
                    totalPurchases, amountOwing, custCreditLimit);
            }
        }
    }
}