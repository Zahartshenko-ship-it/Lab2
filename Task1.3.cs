using System;

namespace Lab2
{
    internal class Fio
    {
        private string? lastName;
        private string? firstName;
        private string? middleName;

        public Fio(
            string? lastName,
            string? firstName, 
            string? middleName
            )
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.MiddleName = middleName;
        }

        public Fio()
        {
            this.FirstName = null;
            this.LastName = null;
            this.MiddleName = null;
        }

        public Fio(string? lastName, string? firstName)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.MiddleName = null;
        }

        public Fio(string? firstName)
        {
            this.LastName = null;
            this.FirstName = firstName;
            this.MiddleName = null;
        }

        public string? LastName 
        {
            get { return this.lastName; }
            set
            {
                if (value != null)
                {
                    this.lastName = value;
                }
                else
                {
                    this.lastName = "";
                }
            }
        }

        public string? FirstName  
        {
            get { return this.firstName; }
            set
            {
                if (value != null)
                {
                    this.firstName = value;
                }
                else
                {
                    this.firstName = "";
                }
            }
        }

        public string? MiddleName  
        {
            get { return this.middleName; }
            set
            {
                if (value != null)
                {
                    this.middleName = value;
                }
                else
                {
                    this.middleName = "";
                }
            }
        }

        public override string ToString()
        {
            string result = "";

            if (!string.IsNullOrEmpty(lastName))
            {
                result += lastName;
            }

            if (!string.IsNullOrEmpty(firstName))
            {
                if (result.Length > 0)
                {
                    result += " ";
                }
                result += firstName;
            }

            if (!string.IsNullOrEmpty(middleName))
            {
                if (result.Length > 0)
                {
                    result += " ";
                }
                result += middleName;
            }

            return result;
        }
    }

}