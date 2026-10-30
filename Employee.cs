using System;

namespace Lab2
{
    internal class Employee
    {
        private string _name;
        private Department _department;
        private string _position;

        public Employee(string name, Department department)
        {
            this._name = name;
            this._department = department;
            this._position = "сотрудник";
        }

        public string Name
        {
            get { return this._name; }
            set { 
                    if (value != null)
                    {
                        this._name = value;
                    }
                    else
                    {
                        this._name = "Неизвестно";
                    }
                }
        }

        public Department Department
        {
            get { return this._department; }
            set { this._department = value; }
        }

        public string Position
        {
            get { return this._position; }
            set { this._position = value; }
        }

        public void MakeManager()
        {
            this._position = "начальник отдела";
        }

        public List<Employee> GetDepartmentEmployees()
        {
            if (this._department != null)
            {
                return this._department.Employees;
            }
            return new List<Employee>();
        }

        public override string ToString()
        {
            if (_position == "начальник отдела")
            {
                return $"{_name} начальник отдела {_department.Name}";
            }
            else
            {
                return $"{_name} работает в отделе {_department.Name}";
            }
        }
    }
}
