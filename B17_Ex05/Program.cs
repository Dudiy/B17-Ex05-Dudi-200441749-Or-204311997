using System;
using System.Collections.Generic;
using System.Text;
using B17_Ex05_GameLogic;

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
            GameLogic theGame = new GameLogic(initForm.NumChoices);
            
        }
    }
}
