using System;

namespace Lab2
{
    internal class Employee
    {
        private string name;
        private Department department;
        private string position;

        public Employee(string name, Department department)
        {
            this.name = name;
            this.department = department;
            this.position = "сотрудник";
        }

        public string Name
        {
            get { return this.name; }
            set { 
                    if (value != null)
                    {
                        this.name = value;
                    }
                    else
                    {
                        this.name = "Неизвестно";
                    }
                }
        }

        public Department Department
        {
            get { return this.department; }
            set { this.department = value; }
        }

        public string Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public void MakeManager()
        {
            this.position = "начальник отдела";
        }

        public List<Employee> GetDepartmentEmployees()
        {
            if (this.department != null)
            {
                return this.department.Employees;
            }
            return new List<Employee>();
        }

        public override string ToString()
        {
            if (position == "начальник отдела")
            {
                return $"{name} начальник отдела {department.Name}";
            }
            else
            {
                return $"{name} работает в отделе {department.Name}";
            }
        }
    }
}