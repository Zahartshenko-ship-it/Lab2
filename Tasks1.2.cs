using System;


namespace Lab2
{
    internal class Human
    {
        private string? _name;
        private int _height;

        public Human(int height)
        {
            this.Name = _name;
            this.Height = height;
        }

        public Human(string name, int height)
        {
            this.Name = name;
            this.Height = height;
        }

        public string? Name
        {
            get { return this._name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this._name = value;
                }
                else
                {
                    this._name = "Петр";
                }
            }
        }

        public int Height
        {
            get { return this._height; }
            set
            {
                if (value > 0)
                {
                    this._height = value;
                }
                else
                {
                    this._height = 170;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name}, рост: {Height}";
        }
    }
}
