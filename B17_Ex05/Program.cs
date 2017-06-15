using System;
using System.Collections.Generic;
using System.Text;

namespace B17_Ex05
{
    public class Program
    {        
        public static void Main()
        {
            run();
        }

        private static void run()
        {

            InitForm initForm = new InitForm();
            initForm.ShowDialog();
        }
    }
}
