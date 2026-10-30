using System;

namespace Lab2
{
    internal class FullName
    {
        private string? _lastName;
        private string? _firstName;
        private string? _patronymic;

        public FullName(
            string? _lastName,
            string? _firstName, 
            string? _patronymic
            )
        {
            this.LastName = _lastName;
            this.FirstName = _firstName;
            this.MiddleName = _patronymic;
        }

        public FullName()
        {
            this.FirstName = null;
            this.LastName = null;
            this.MiddleName = null;
        }

        public FullName(string? _lastName, string? _firstName)
        {
            this.LastName = _lastName;
            this.FirstName = _firstName;
            this.MiddleName = null;
        }

        public FullName(string? _firstName)
        {
            this.LastName = null;
            this.FirstName = _firstName;
            this.MiddleName = null;
        }

        public string? LastName 
        {
            get { return this._lastName; }
            set
            {
                if (value != null)
                {
                    this._lastName = value;
                }
                else
                {
                    this._lastName = "";
                }
            }
        }

        public string? FirstName  
        {
            get { return this._firstName; }
            set
            {
                if (value != null)
                {
                    this._firstName = value;
                }
                else
                {
                    this._firstName = "";
                }
            }
        }

        public string? MiddleName  
        {
            get { return this._patronymic; }
            set
            {
                if (value != null)
                {
                    this._patronymic = value;
                }
                else
                {
                    this._patronymic = "";
                }
            }
        }

        public override string ToString()
        {
            string result = "";

            if (!string.IsNullOrEmpty(_lastName))
            {
                result += _lastName;
            }

            if (!string.IsNullOrEmpty(_firstName))
            {
                if (result.Length > 0)
                {
                    result += " ";
                }
                result += _firstName;
            }

            if (!string.IsNullOrEmpty(_patronymic))
            {
                if (result.Length > 0)
                {
                    result += " ";
                }
                result += _patronymic;
            }

            return result;
        }
    }

}
