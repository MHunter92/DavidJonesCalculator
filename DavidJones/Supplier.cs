using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidJones
{
    class Supplier
    {

        // default constructor
        public Supplier()
            {
            Console.WriteLine("This is the default constructor");
            }

        public Supplier( string supplierName, int accNumber, double accBalance, double totalPayments, 
            double totalPurchases, double amountOwing, string suppCreditLimit)
        {
            SupplierName = supplierName;
            SuppAccNumber = accNumber;
            SuppAccBalance = accBalance;
            SuppTotalPurchases = totalPurchases;
            SuppTotalPayments = totalPayments;
            SupplierOwing = amountOwing;
            SuppCreditLimit = suppCreditLimit;



        }

        // field of variables

        private string supplierName, suppCreditLimit;
        private int accNumber;
        private double accBalance, totalPurchases, totalPayments, amountOwing;

        public string SupplierName
        {
            get
            {
                return supplierName;
            }
            
            set
            {
                supplierName = value;
            }
        }

        public int SuppAccNumber
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

        public double SuppAccBalance
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

        public double SuppTotalPurchases
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

        public double SuppTotalPayments
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

        public double SupplierOwing
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

        public string SuppCreditLimit
        {
            get
            {
                return suppCreditLimit;    
            }
            set
            {
                suppCreditLimit = value;
            }
        }

        //methods for getting supplier details

        public static string GetSupplierName(string custOrSupp)
        {
            string name;
            Console.WriteLine("\nPlease enter the name of the {0} ", custOrSupp);
            name = Console.ReadLine();
            while (name.Length < 5 || name.Length > 16)
            {
                Console.WriteLine("Invalid entry. \n Your account name must be between 6 and 15 characters.");
                name = Console.ReadLine();
            }
            return name;
        }

        public static int GetSupplierAccNumber(string details)
        {
            string inputValue;
            int accNumber;
            Console.WriteLine("\nPlease enter the {0}", details);
            inputValue = Console.ReadLine();
            while (int.TryParse(inputValue, out accNumber) == false || inputValue == "" == true || inputValue.Length != 6 || inputValue[0] != '2')
            {
                Console.WriteLine("Invalid entry. \n Your account number will be six digits and begin with a 2."
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

        public static void CreateNewSupplierObject(int numberOfRegistrars, Supplier[] SupplierArray)
        {

            for (int i = 0; i < numberOfRegistrars; i++)
            {
                const double creditLimit = 500;
                string errorMessage;

                string supplierName = GetSupplierName("supplier: ");
                int accNumber = GetSupplierAccNumber("supplier account number: ");
                double accBalance = GetOtherDetails("amount David Jones currently owes to this supplier (account balance): ");
                double totalPurchases = GetOtherDetails("supplier total purchases: ");
                double totalPayments = GetOtherDetails("supplier total payments: ");
                Console.WriteLine("\nSupplier Registered!");
                Console.ReadLine();
                Console.Clear();
                double amountOwing = (accBalance + totalPurchases) - totalPayments;

                if (amountOwing > creditLimit)
                    errorMessage = ("Payment is due now. ");

                else
                    errorMessage = ("");

                string suppCreditLimit = errorMessage;

                SupplierArray[i] = new Supplier(supplierName, accNumber, accBalance,
                    totalPayments, totalPurchases, amountOwing, suppCreditLimit);
            }


        }
    }
}
