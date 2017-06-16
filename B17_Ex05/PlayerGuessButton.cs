using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace B17_Ex05
{
    internal class PlayerGuessButton : Button
    {        
        private byte m_Size = 20;
        private char m_CharValue;


        public PlayerGuessButton()
        {
            Width = Height = m_Size;
            BackColor = Color.Gray;

        }
    }
}
