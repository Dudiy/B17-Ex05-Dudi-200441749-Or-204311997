/*
 * B17_Ex05: RoundUI.cs
 * 
 * This class represents a single round of the game to match the Round class
 * of the GameLogic.
 * Each RoundUI object includes a single SequenceButtons object, a submit button and a Result object
 * When a round is enabled all sequence buttons are enabled, and so is the submit button.
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using B17_Ex05_GameLogic;
using System.Collections.Generic;

namespace B17_Ex05
{
    internal class RoundUI
    {
        // TODO use delegate or action? what is the correct naming convention?
        public event Action<object> SubmitClicked;
        // according to stylecop a blank line is required here (?)
        private Result m_Result;
        private SequenceButtons m_SequenceButtons;
        private Button m_SubmitButton = new Button();
        private Round m_RoundLogic;
        private bool m_IsActive = false;
        private int m_Top = 0;
        private int m_Left = 0;
        private int m_Right = 0;

        public RoundUI(int i_Top, int i_Left)
        {
            m_Top = i_Top;
            m_Left = i_Left;
            initAllButtons();
            m_Right = Result.Right;
        }

        // ==================================================== Properties ====================================================
        // The right edge of the RoundUI object
        internal int Right
        {
            get { return m_Right; }
        }

        // When a rounds IsActive property is changed, will update the enable property of all relevant buttons.
        internal bool IsActive
        {
            get { return m_IsActive; }
            set
            {
                m_IsActive = value;
                m_SequenceButtons.SetButtonsState(value);
                m_SubmitButton.Enabled = value;
            }
        }

        // Get the Result object - for the BoardForm to add all buttons as controls
        internal Result Result
        {
            get { return m_Result; }
        }

        // Get the SequenceButtons object - for the BoardForm to add all buttons as controls
        internal SequenceButtons SequenceButtons
        {
            get { return m_SequenceButtons; }
        }

        // Get the SubmitButton - for the BoardForm to the button as a control
        internal Button SubmitButton
        {
            get { return m_SubmitButton; }
        }

        // Set the RoundUI's internal Round reference and update the Result object accordingly
        internal Round RoundLogic
        {
            set
            {
                // TODO should set result stay here or not?
                m_RoundLogic = value;
                m_Result.SetResult(value.NumOfCorrectGuesses, value.NumOfCorrectLetterInWrongPositions);
            }
        }

        internal List<Button> Buttons
        {
            get
            {
                List<Button> allRoundButtons = new List<Button>();

                allRoundButtons.AddRange(SequenceButtons.Buttons);
                allRoundButtons.Add(SubmitButton);
                allRoundButtons.AddRange(m_Result.Buttons);

                return allRoundButtons;
            }
        }

        // ==================================================== Methods ====================================================
        // initialize all buttons of a single RoundUI object
        private void initAllButtons()
        {
            m_SequenceButtons = new SequenceButtons(m_Top, m_Left);
            initSubmitButton();
            // TODO change 10 to const
            int resultLeft = m_SubmitButton.Right + 10;
            m_Result = new Result(m_Top, resultLeft);
        }

        private void initSubmitButton()
        {
            m_SubmitButton.BackColor = Color.LightGray;
            m_SubmitButton.Height = PlayerGuessButton.ButtonSize / 2;
            m_SubmitButton.Width = PlayerGuessButton.ButtonSize;
            m_SubmitButton.Top = m_Top + (PlayerGuessButton.ButtonSize / 4);
            m_SubmitButton.Left = m_SequenceButtons.Right + 5;
            m_SubmitButton.Text = "-->>";
            m_SubmitButton.Enabled = false;
            m_SubmitButton.Click += SubmitButton_Click;
        }

        // Notify the BoardForm when submit is clicked and what round was it clicked on
        private void OnSubmitClick()
        {
            if (SubmitClicked != null)
            {
                SubmitClicked.Invoke(this);
            }
        }

        public string GetStringValue()
        {
            StringBuilder stringValue = new StringBuilder();

            foreach (PlayerGuessButton button in m_SequenceButtons.Buttons)
            {
                stringValue.Append(button.CharValue);
            }

            return stringValue.ToString();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            OnSubmitClick();
        }

        // Check if all buttons in the current have a color
        internal bool AllButtonsAreSet()
        {
            return m_SequenceButtons.AllButtonsAreSet();
        }
    }
}