public class Employee
{
    public int ID { get; set; }
    public decimal Salary { get; set; }
    public HiringDate HireDate { get; set; }
    public char Gender { get; set; }

    public Employee(int id, decimal salary, HiringDate hireDate, char gender)
    {
        ID = id;
        Salary = salary;
        HireDate = hireDate;
        Gender = gender;
    }

    public override string ToString()
    {
        return $"ID: {ID}, Salary: {Salary}, Hire Date: {HireDate}, Gender: {Gender}";
    }
}
