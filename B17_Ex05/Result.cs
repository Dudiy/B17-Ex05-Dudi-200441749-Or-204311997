﻿using System;
using System.Collections.Generic;
using System.Text;
using B17_Ex05_GameLogic;
using System.Drawing;
using System.Windows.Forms;

namespace B17_Ex05
{
    internal class Result
    {
        protected readonly List<Button> r_Buttons = new List<Button>();
        private readonly int r_ButtonSize = (int)(0.45 * LetterSequence.LengthOfSequence);
        private readonly byte r_PaddingBetweenButtons = (byte)(0.05 * LetterSequence.LengthOfSequence);
        private int m_Top = 0;
        private int m_Left = 0;
        private static readonly Color sr_CorrectGuessColor = Color.Black;
        private static readonly Color sr_MisplacedGuessColor= Color.Yellow;

        internal Result(int i_Top, int i_Left)
        {
            m_Top = i_Top;
            m_Left = i_Left;
            initButtons();
        }

        // ==================================================== Methods ====================================================
        private void initButtons()
        {
            int currTop = m_Top;
            int currLeft = m_Left;
            int numButtons = LetterSequence.LengthOfSequence;

            for (int i = 0; i < numButtons; i++)
            {
                Button newButton = new Button();

                newButton.Width = r_ButtonSize;
                newButton.Height = r_ButtonSize;
                newButton.BackColor = Color.LightGray;
                newButton.IsAccessible = false;
                newButton.Top = currTop;
                newButton.Left = currLeft;
                currLeft += r_ButtonSize + r_PaddingBetweenButtons;
                r_Buttons.Add(newButton);

                if (i == numButtons / 2)
                {
                    currTop = m_Top + r_ButtonSize + r_PaddingBetweenButtons;
                    currLeft = m_Left;
                }
            }
        }

        internal void SetResult(int i_NumOfCorrectGuesses, int i_NumOfCorrectLettersInWrongPositions)
        {
            int currentButtonInd = 0;

            for (int i = 0; i < i_NumOfCorrectGuesses; i++)
            {
                r_Buttons[currentButtonInd].BackColor = sr_CorrectGuessColor;
                currentButtonInd++;
            }

            for (int i = 0; i < i_NumOfCorrectLettersInWrongPositions; i++)
            {
                r_Buttons[currentButtonInd].BackColor = sr_MisplacedGuessColor;
                currentButtonInd++;
            }
        }
    }
}
