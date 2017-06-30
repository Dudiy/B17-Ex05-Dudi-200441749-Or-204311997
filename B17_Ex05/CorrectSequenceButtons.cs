/*
 * B17_Ex05: CorrectSequenceButtons.cs
 * 
 * Inherits from the "SequenceButtons" class. 
 * This class holds the correct sequence and hides it from the user untill
 * the game ends.
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
 */
using System.Drawing;

namespace B17_Ex05
{
    internal class CorrectSequenceButtons : SequenceButtons
    {
        private string m_CorrectSequence;

        // ==================================================== Initialize ====================================================
        internal CorrectSequenceButtons(int i_Top, int i_Left, string i_CorrectSequence) 
            : base(i_Top, i_Left)
        {
            m_CorrectSequence = i_CorrectSequence;
            initButtons();
        }

        private void initButtons()
        {
            byte charIndex = 0;

            /* Itterate through all Sequence buttons update them according to the 
             * m_CorrectSequence string */
            foreach (PlayerGuessButton button in r_Buttons)
            {
                button.SetColorByChar(m_CorrectSequence[charIndex]);
                button.Enabled = false;
                button.Hidden = true;
                charIndex++;
            }
        }

        // ==================================================== Methods ====================================================
        internal void ShowCorrectGuess()
        {
            foreach (PlayerGuessButton button in r_Buttons)
            {
                button.Hidden = false;
            }
        }
    }
}
