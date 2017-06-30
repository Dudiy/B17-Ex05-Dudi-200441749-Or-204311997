/*
 * B17_Ex05: SequenceButtons.cs
 * 
 * This class represents a sequence of buttons to match the LetterSequence class
 * of the GameLogic.
 * Each button represents a letter and is displayed as it's matching color.
 * When a button is clicked the PickColor form is displayed for the user
 * to pick a color for the button, this will update the char value of the matching button.
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using B17_Ex05_GameLogic;

namespace B17_Ex05
{
    internal delegate void ButtonClickEventHandler(object sender, EventArgs e);

    internal class SequenceButtons
    {
        internal event ButtonClickEventHandler ButtonClicked;
        // according to stylecop a blank line is required here (?)
        private const short k_PaddingBetweenButtons = 5;
        private static readonly PickColorForm sr_PickColorForm = new PickColorForm();
        protected readonly List<Button> r_Buttons = new List<Button>(LetterSequence.LengthOfSequence);
        private int m_Top = 0;
        private int m_Left = 0;
        private int m_Right = 0;

        // ==================================================== Initialize ============================================================
        internal SequenceButtons(int i_Top, int i_Left)
        {
            m_Top = i_Top;
            m_Left = i_Left;
            initButtons();
        }

        /*  initialize all PlayerGuessButtons in the sequence.
         *  By default the buttons are light grey and disabled.
         *  The buttons are positioned one after the other with padding between them */
        private void initButtons()
        {
            int currLeft = m_Left;

            // there are as many buttons as there are letters in GameLogic's letter sequence
            for (int i = 0; i < LetterSequence.LengthOfSequence; i++)
            {
                PlayerGuessButton newButton = new PlayerGuessButton();

                newButton.Top = m_Top;
                newButton.Left = currLeft;
                newButton.Enabled = false;
                newButton.Click += button_Click;
                r_Buttons.Add(newButton);
                currLeft += newButton.Width + k_PaddingBetweenButtons;
            }

            // after all buttons are positioned currLeft is the right of the last button with padding
            m_Right = currLeft + k_PaddingBetweenButtons;
        }

        // ==================================================== Properties =========================================================
        // the list of buttons, used by the BoardForm to add all buttons to the Contols
        internal List<Button> Buttons
        {
            get { return r_Buttons; }
        }

        // The right edge of the full sequence (includes a padding)
        internal int Right
        {
            get { return m_Right; }
        }

        // ==================================================== Methods ============================================================
        // Enable/Disable all buttons in the sequence
        internal void SetButtonsState(bool i_State)
        {
            foreach (PlayerGuessButton button in r_Buttons)
            {
                button.Enabled = i_State;
            }
        }

        // Check if all buttons are colored
        internal bool AllButtonsAreSet()
        {
            bool allSet = true;

            foreach (PlayerGuessButton button in r_Buttons)
            {
                if (!button.IsSet)
                {
                    allSet = false;
                    break;
                }
            }

            return allSet;
        }

        /*  Event listener for when a button is clicked.
         *  Shows the pickColor dialog and updates the color according to the user's choice.
         *  Will not update if the user closed the pickColor form without selecting a color */
        private void button_Click(object sender, EventArgs e)
        {
            DialogResult result = sr_PickColorForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                ((PlayerGuessButton)sender).Color = sr_PickColorForm.ColorPicked;
                OnButtonClick(null);
            }
        }

        protected virtual void OnButtonClick(EventArgs e)
        {
            if (ButtonClicked != null)
            {
                ButtonClicked.Invoke(this, null);
            }
        }

    }
}
