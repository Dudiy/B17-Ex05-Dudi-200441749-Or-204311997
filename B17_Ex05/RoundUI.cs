using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using B17_Ex05_GameLogic;

namespace B17_Ex05
{
    internal class RoundUI
    {
        SequenceButtons m_SequenceButtons;
        private readonly Result m_Result;
        private int m_Top = 0;
        private int m_Left = 0;
        private bool m_IsActive = false;
        private Button m_SubmitButton = new Button();
        private Round m_RoundLogic;
        //private byte m_CorrectGuesses = 0;
        //private byte m_MisplacedGuesses = 0;

        public RoundUI(int i_Top, int i_Left)
        {
            m_Top = i_Top;
            m_Left = i_Left;
            m_SequenceButtons = new SequenceButtons(m_Top, m_Left);
            initSubmitButton();
            int resultLeft = m_SubmitButton.Left + m_SubmitButton.Width + 5;
            m_Result = new Result(m_Top, resultLeft);
        }

        internal Result Result
        {
            get { return m_Result; }
        }

        //internal byte CorrectGuesses
        //{
        //    get { return m_CorrectGuesses; }
        //    set
        //    {
        //        if (value <= LetterSequence.LengthOfSequence)
        //        {
        //            m_CorrectGuesses = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentException("Invalid number of correct guesses");
        //        }
        //    }
        //}

        //internal byte MisplacedGuesses
        //{
        //    get { return m_MisplacedGuesses; }
        //    set
        //    {
        //        if (value <= LetterSequence.LengthOfSequence)
        //        {
        //            m_MisplacedGuesses = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentException("Invalid number of misplaced guesses");
        //        }
        //    }
        //}

        internal Round RoundLogic
        {
            //get { return m_RoundLogic; }
            set
            {
                // TODO should set result stay here or not?
                m_RoundLogic = value;
                m_Result.SetResult(value.NumOfCorrectGuesses, value.NumOfCorrectLetterInWrongPositions);
            }
        }

        internal SequenceButtons SequenceButtons
        {
            get { return m_SequenceButtons; }
        }

        internal Button SubmitButton
        {
            get { return m_SubmitButton; }
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

        private void initSubmitButton()
        {
            m_SubmitButton.BackColor = Color.LightGray;
            m_SubmitButton.Height = PlayerGuessButton.ButtonSize / 2;
            m_SubmitButton.Width = PlayerGuessButton.ButtonSize;
            m_SubmitButton.Top = m_Top + PlayerGuessButton.ButtonSize / 4;
            m_SubmitButton.Left = m_SubmitButton.Right + 5;
            m_SubmitButton.Text = "-->>";
            m_SubmitButton.IsAccessible = false;
        }

        internal bool AllButtonsAreSet()
        {
            return m_SequenceButtons.allButtonsAreSet();
        }

    }
}