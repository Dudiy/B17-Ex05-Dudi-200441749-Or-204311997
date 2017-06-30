using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace B17_Ex05
{
    internal class CorrectSequenceButtons : SequenceButtons
    {
        private string m_CorrectSequence;

        internal CorrectSequenceButtons(int i_Top, int i_Left, string i_CorrectSequence) 
            : base(i_Top, i_Left)
        {
            m_CorrectSequence = i_CorrectSequence;
            initButtons();
        }

        internal CorrectSequenceButtons(Point i_Point, string i_CorrectSequence) 
            : this(i_Point.X, i_Point.Y, i_CorrectSequence)
        {
        }

        private void initButtons()
        {
            byte charIndex = 0;
            foreach (PlayerGuessButton button in r_Buttons)
            {
                button.SetColorByChar(m_CorrectSequence[charIndex]);
                button.Enabled = false;
                button.Hidden = true;
                charIndex++;
            }
        }

        internal void ShowCorrectGuess()
        {
            foreach (PlayerGuessButton button in r_Buttons)
            {
                button.Hidden = false;
            }
        }
    }
}
