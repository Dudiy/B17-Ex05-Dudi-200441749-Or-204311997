/*
 * B17_Ex05: Result.cs
 * 
 * This class is a part of each RoundUI, it facilitates the set of buttons
 * that are used to display the result of the user's guess in each round.
 * The Result object is updated after each round is played.
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using B17_Ex05_GameLogic;

namespace B17_Ex05
{
    internal class Result
    {
        private const byte k_PaddingAround = 15;
        private static readonly Color sr_CorrectGuessColor = Color.Black;
        private static readonly Color sr_MisplacedGuessColor = Color.Yellow;
        protected readonly List<Button> r_Buttons = new List<Button>();
        private readonly byte r_ButtonSize = (byte)(0.45 * PlayerGuessButton.ButtonSize);
        private readonly byte r_PaddingBetweenButtons = (byte)(0.05 * PlayerGuessButton.ButtonSize);
        private int m_Top = 0;
        private int m_Left = 0;
        private int m_Right = 0;

        internal Result(int i_Top, int i_Left)
        {
            m_Top = i_Top;
            m_Left = i_Left;
            initButtons();
        }

        // ==================================================== Properties =========================================================
        internal List<Button> Buttons
        {
            get { return r_Buttons; }
        }

        // The right edge of the Result object
        internal int Right
        {
            get { return m_Right; }
        }

        // ==================================================== Methods ============================================================
        /* After a round is played, the number of correct and mismatch guesses are used to 
         * update the colors of the Result buttons */
        internal void SetResult(int i_NumOfCorrectGuesses, int i_NumOfMismatches)
        {
            int currentButtonInd = 0;

            if (i_NumOfCorrectGuesses + i_NumOfMismatches > r_Buttons.Count)
            {
                throw new ArgumentException("The sum of inputs is greater than the number of possible results");
            }

            for (int i = 0; i < i_NumOfCorrectGuesses; i++)
            {
                r_Buttons[currentButtonInd].BackColor = sr_CorrectGuessColor;
                currentButtonInd++;
            }

            for (int i = 0; i < i_NumOfMismatches; i++)
            {
                r_Buttons[currentButtonInd].BackColor = sr_MisplacedGuessColor;
                currentButtonInd++;
            }
        }

        // Initalize all buttons in the Result object
        private void initButtons()
        {
            int currTop = m_Top;
            int currLeft = m_Left + k_PaddingAround;
            int numButtons = LetterSequence.LengthOfSequence;

            for (int i = 0; i < numButtons; i++)
            {
                Button newButton = new Button();

                if (i == numButtons / 2)
                {
                    currTop = m_Top + r_ButtonSize + r_PaddingBetweenButtons;
                    currLeft = m_Left + k_PaddingAround;
                }

                newButton.Width = r_ButtonSize;
                newButton.Height = r_ButtonSize;
                newButton.BackColor = Color.LightGray;
                newButton.Enabled = false;
                newButton.Top = currTop;
                newButton.Left = currLeft;
                currLeft += r_ButtonSize + r_PaddingBetweenButtons;
                r_Buttons.Add(newButton);
            }

            // after all Result buttons are set, update the m_Right value of the object
            m_Right = currLeft + k_PaddingAround;
        }
    }
}
