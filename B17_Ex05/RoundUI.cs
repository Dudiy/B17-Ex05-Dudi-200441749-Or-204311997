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
using System.Collections.Generic;
using B17_Ex05_GameLogic;

namespace B17_Ex05
{
    internal delegate void SubmitClickedEventHandler(object sender, EventArgs e);

    internal class RoundUI
    {
        public event SubmitClickedEventHandler SubmitClicked;
        // according to stylecop a blank line is required here (?)
        private readonly List<Button> r_AllRoundButtons = new List<Button>();
        private Result m_Result = null;
        private SequenceButtons m_SequenceButtons = null;
        private Button m_SubmitButton = new Button();
        private Round m_RoundLogic = null;
        private bool m_IsActive = false;
        private int m_Top = 0;
        private int m_Left = 0;
        private int m_Right = 0;

        // ==================================================== Initialize =========================================================
        public RoundUI(int i_Top, int i_Left)
        {
            m_Top = i_Top;
            m_Left = i_Left;
            initAllButtons();
            m_Right = m_Result.Right;
        }

        // initialize all buttons of a single RoundUI object
        private void initAllButtons()
        {
            m_SequenceButtons = new SequenceButtons(m_Top, m_Left);
            initSubmitButton();
            m_Result = new Result(m_Top, m_SubmitButton.Right);
            // add all buttons to m_AllRoundButtons
            r_AllRoundButtons.AddRange(m_SequenceButtons.Buttons);
            r_AllRoundButtons.Add(m_SubmitButton);
            r_AllRoundButtons.AddRange(m_Result.Buttons);
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

        // ==================================================== Properties =========================================================
        // Set the RoundUI's internal Round reference and update the Result object accordingly
        internal Round RoundLogic
        {
            set
            {
                m_RoundLogic = value;
                m_Result.SetResult(value.NumOfCorrectGuesses, value.NumOfCorrectLetterInWrongPositions);
            }
        }

        // return a list of all the buttons in RoundUI for the BoardForm to add as controls
        internal List<Button> Buttons
        {
            get { return r_AllRoundButtons; }
        }

        // When a round's IsActive property is changed, will update the enable property of all relevant buttons accordingly.
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

        // The right edge of the RoundUI object
        internal int Right
        {
            get { return m_Right; }
        }

        // ==================================================== Methods ============================================================
        // Get the set of chars represented by the Round's button colors as a string
        internal string GetStringValue()
        {
            StringBuilder stringValue = new StringBuilder();

            foreach (PlayerGuessButton button in m_SequenceButtons.Buttons)
            {
                stringValue.Append(button.CharValue);
            }

            return stringValue.ToString();
        }

        // Check if all buttons in the current have a color
        internal bool AllButtonsAreSet()
        {
            return m_SequenceButtons.AllButtonsAreSet();
        }

        internal void SetResult(int i_NumOfCorrectGuesses, int i_NumOfMismatches)
        {
            m_Result.SetResult(i_NumOfCorrectGuesses, i_NumOfMismatches);
        }

        // Notify the BoardForm when submit is clicked and what round was it clicked on
        protected virtual void OnSubmitClick(EventArgs e)
        {
            if (SubmitClicked != null)
            {
                SubmitClicked.Invoke(this, e);
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            OnSubmitClick(e);
        }
    }
}