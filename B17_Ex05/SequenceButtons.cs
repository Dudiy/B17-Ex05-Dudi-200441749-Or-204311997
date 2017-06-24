using System;
using System.Collections.Generic;
using System.Text;
using B17_Ex05_GameLogic;
using System.Drawing;

namespace B17_Ex05
{
    internal class SequenceButtons
    {
        protected readonly List<PlayerGuessButton> m_Buttons = new List<PlayerGuessButton>(LetterSequence.LengthOfSequence);
        private bool m_IsActive = false;
        private byte m_PaddingBetweenButtons = 5;
        private int m_Top = 0;
        private int m_Left = 0;
        private static readonly PickColorForm m_PickColorForm = new PickColorForm();

        internal SequenceButtons(int i_Top, int i_Left)
        {
            m_Top = i_Top;
            m_Left = i_Left;
            initButtons();
        }

        // ==================================================== Properties ====================================================
        
        private void initButtons()
        {            
            int currLeft = m_Left;
            foreach (PlayerGuessButton button in m_Buttons)
            {
                PlayerGuessButton newButton = new PlayerGuessButton();
                newButton.Top = m_Top;
                newButton.Left = currLeft;
                newButton.IsAccessible = false;
                currLeft += newButton.Width + m_PaddingBetweenButtons;
                newButton.Click += NewButton_Click;
            }
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            m_PickColorForm.ShowDialog();
            ((PlayerGuessButton)sender).Color = m_PickColorForm.ColorPicked;
            // TODO does the color on the button really change?
        }

        internal void ActivateButtons()
        {
            foreach (PlayerGuessButton button in m_Buttons)
            {
                button.IsAccessible = true;
            }
        }
    }
}
