namespace Main
{
    class Program
    {
        #region  Sorting Employees Function
        public static Employee[] Sorting(Employee[] employees)
        {
            for (int i = 0; i < employees.Length - 1; i++)
            {
                for (int j = 0; j < employees.Length - 1 - i; j++)
                {

                    if (employees[j].HireDate.Year > employees[j + 1].HireDate.Year)
                    {

                        var temp = employees[j];
                        employees[j] = employees[j + 1];
                        employees[j + 1] = temp;
                    }

                    else if (employees[j].HireDate.Year == employees[j + 1].HireDate.Year)
                    {
                        if (employees[j].HireDate.Month > employees[j + 1].HireDate.Month)
                        {

                            var temp = employees[j];
                            employees[j] = employees[j + 1];
                            employees[j + 1] = temp;
                        }

                        else if (employees[j].HireDate.Month == employees[j + 1].HireDate.Month)
                        {
                            if (employees[j].HireDate.Day > employees[j + 1].HireDate.Day)
                            {
                                var temp = employees[j];
                                employees[j] = employees[j + 1];
                                employees[j + 1] = temp;
                            }
                        }
                    }
                }
            }
            return employees;

        }
        #endregion



        static void Main(string[] args)
        {
            HashSet<int> usedIds = new HashSet<int>();

            Console.Write("Enter the number of employees: ");
            int Emp_num = int.Parse(Console.ReadLine());

            Employee[] employees = new Employee[Emp_num];

            for (int i = 0; i < Emp_num; i++)
            {
                Console.WriteLine($"\nEnter Data For Employee {i + 1}:");


                #region Validate Input ID
                int id;
                do
                {
                    Console.Write("Enter ID (must be unique): ");
                    string inputId = Console.ReadLine();
                    if (!int.TryParse(inputId, out id) || usedIds.Contains(id))
                    {
                        Console.WriteLine("Invalid ID. Please enter a unique integer ID.");
                    }
                    else
                    {
                        usedIds.Add(id);
                        break;
                    }
                } while (true);
                #endregion

                #region Validate Input Salary
                decimal salary;
                do
                {
                    Console.Write("Enter Salary: ");
                    string inputSalary = Console.ReadLine();

                    if (!decimal.TryParse(inputSalary, out salary) || salary < 0)
                    {
                        Console.WriteLine("Invalid salary. Please enter a valid positive number.");
                    }
                    else
                    {
                        break;
                    }
                } while (true);
                #endregion

                #region Validate Input Day

                int day;
                do
                {
                    Console.Write("Enter Hire Date (Day): ");
                    string inputDay = Console.ReadLine();


                    if (!int.TryParse(inputDay, out day) || day < 1 || day > 31)
                    {
                        Console.WriteLine("Invalid day. Please enter a number between 1 and 31.");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                #endregion

                #region Validate Input Month

                int month;
                do
                {
                    Console.Write("Enter Hire Date (Month): ");
                    string inputMonth = Console.ReadLine();
                    if (!int.TryParse(inputMonth, out month) || month < 1 || month > 12)
                    {
                        Console.WriteLine("Invalid month. Please enter a number between 1 and 12.");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                #endregion

                #region Validate Input Year

                int year;
                do
                {
                    Console.Write("Enter Hire Date (Year): ");
                    string inputYear = Console.ReadLine();
                    if (!int.TryParse(inputYear, out year) || year > DateTime.Now.Year)
                    {
                        Console.WriteLine($"Invalid year. Year cannot be greater than {DateTime.Now.Year}.");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                #endregion

                HiringDate hireDate = new HiringDate(day, month, year);

                #region Validate Input Gender
                char gender;
                do
                {
                    Console.Write("Enter Gender (M/F): ");
                    string inputGender = Console.ReadLine().ToUpper();
                    if (inputGender.Length != 1 || (inputGender[0] != 'M' && inputGender[0] != 'F'))
                    {
                        Console.WriteLine("Invalid gender. Please enter 'M' or 'F'.");
                    }
                    else
                    {
                        gender = inputGender[0];
                        break;
                    }
                } while (true);

                #endregion

                employees[i] = new Employee(id, salary, hireDate, gender);
            }

            Employee[] sortedArray = Sorting(employees);

            Console.WriteLine("\nSorted Employees by Hire Date:");
            foreach (var employee in sortedArray)
            {
                Console.WriteLine(employee);
            }
        }
    }
}