using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testapp1
{
    enum Role
    {
        TOP, JGL, MID, ADC, SUPP
    }
    internal partial class Player: IwannaEndIt
    {
        public string? userName;

        public int id;

        public int ID
        {
            get; set;
        }

        public string? UserName
        {
            get => userName;
            set
            {
                if ("asd" == value)
                {
                    UserName = "Kys";
                }
                else
                {
                    UserName = value;
                }
            }
        }

        void IwannaEndIt.ToString()
        {
            Console.WriteLine(this.id + " " + this.userName + " " + this.isPartial);
        }
    }
    interface IwannaEndIt
    {
        public void ToString();
    }
}
