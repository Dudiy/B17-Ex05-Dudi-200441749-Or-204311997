﻿/*
 * B17_Ex05: SequenceButtons.cs
 * 
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
 */
using System;
using System.Collections.Generic;
using B17_Ex05_GameLogic;
using System.Windows.Forms;

namespace B17_Ex05
{
    internal class SequenceButtons
    {
        protected readonly List<Button> m_Buttons = new List<Button>(LetterSequence.LengthOfSequence);
        private bool m_IsActive = false;
        private byte m_PaddingBetweenButtons = 5;
        private int m_Top = 0;
        private int m_Left = 0;
        private int m_Right = 0;
        private static readonly PickColorForm m_PickColorForm = new PickColorForm();

        // ==================================================== Initialize ====================================================
        internal SequenceButtons(int i_Top, int i_Left)
        {
            // there are as many buttons as there are letters in GameLogic's letter sequence
            m_Top = i_Top;
            m_Left = i_Left;
            initButtons();
        }

        private void initButtons()
        {
            int currLeft = m_Left;

            for (int i = 0; i < LetterSequence.LengthOfSequence; i++)
            {
                PlayerGuessButton newButton = new PlayerGuessButton();
                newButton.Top = m_Top;
                newButton.Left = currLeft;
                newButton.Enabled = false;
                currLeft += newButton.Width + m_PaddingBetweenButtons;
                newButton.Click += Button_Click;
                m_Buttons.Add(newButton);
            }

            m_Right = currLeft + m_PaddingBetweenButtons;
        }

        // ==================================================== Properties ====================================================
        internal List<Button> Buttons
        {
            get { return m_Buttons; }
        }

        internal int Right
        {
            get { return m_Right; }
        }


        // ==================================================== Methods ====================================================
        internal void SetButtonsState(bool i_ActiveState)
        {
            foreach (PlayerGuessButton button in m_Buttons)
            {
                button.Enabled = i_ActiveState;
            }
        }

        public bool allButtonsAreSet()
        {
            bool allSet = true;

            foreach (PlayerGuessButton button in m_Buttons)
            {
                if (!button.IsSet)
                {
                    allSet = false;
                    break;
                }
            }

            return allSet;
        }

        // ==================================================== Buttons Events ====================================================
        private void Button_Click(object sender, EventArgs e)
        {
            DialogResult result = m_PickColorForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                ((PlayerGuessButton)sender).Color = m_PickColorForm.ColorPicked;
            }
            // TODO does the color on the button really change?
        }
    }
}
