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
            Run();
        }

        // TODO move to other class
        private static void Run()
        {
            //InitForm initForm = new InitForm();
            //initForm.ShowDialog();
            PickColorForm pcForm = new PickColorForm();
            pcForm.ShowDialog();
            //GameLogic theGame = new GameLogic(initForm.NumChoices);
            
        }
    }
}
