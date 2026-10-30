namespace Lab2
{
    internal class Department
    {
        private string _name;
        private List<Employee> _employees;

        public Department(string name)
        {
            this._name = name;
            this._employees = new List<Employee>();
        }

        public string Name
        {
            get {return this._name;}
            set {this._name = value;}
        }

        public List<Employee> Employees
        {
            get { return this._employees; }
        }

        public void AddEmployee(Employee employee)
        {
            if (employee != null && !this._employees.Contains(employee))
            {
                this._employees.Add(employee);
            }
        }


    }
}
