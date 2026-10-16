using System;


namespace Lab2
{
    internal class Human
    {
        private string? name;
        private int height;

        public Human(int height)
        {
            this.Name = name;
            this.Height = height;
        }

        public Human(string name, int height)
        {
            this.Name = name;
            this.Height = height;
        }

        public string? Name
        {
            get { return this.name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.name = value;
                }
                else
                {
                    this.name = "Петр";
                }
            }
        }

        public int Height
        {
            get { return this.height; }
            set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    this.height = 170;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name}, рост: {Height}";
        }
    }
}
