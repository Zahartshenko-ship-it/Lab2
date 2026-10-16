namespace Lab2
{
    internal class Department
    {
        private string name;
        private List<Employee> employees;

        public Department(string name)
        {
            this.name = name;
            this.employees = new List<Employee>();
        }

        public string Name
        {
            get {return this.name;}
            set {this.name = value;}
        }

        public List<Employee> Employees
        {
            get { return this.employees; }
        }

        public void AddEmployee(Employee employee)
        {
            if (employee != null && !this.employees.Contains(employee))
            {
                this.employees.Add(employee);
            }
        }


    }
}