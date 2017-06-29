using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace B17_Ex05
{
    internal class CorrectSequenceButtons : SequenceButtons
    {
        private string m_CorrectSequence;

        public CorrectSequenceButtons(int i_Top, int i_Left, string i_CorrectSequence) 
            : base(i_Top, i_Left)
        {
            m_CorrectSequence = i_CorrectSequence;
            initButtons();
        }

        private void initButtons()
        {
            byte charIndex = 0;
            foreach (PlayerGuessButton button in m_Buttons)
            {
                button.SetColorByChar(m_CorrectSequence[charIndex]);               
                charIndex++;
            }

        }
    }
}
