using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using B17_Ex05_GameLogic;
using System.Drawing;

namespace B17_Ex05
{
    class BoardForm : Form
    {
        private CorrectSequenceButtons m_CorrectSequence;
        private GameLogic m_GameLogic;
        private readonly List<RoundUI> r_Rounds = new List<RoundUI>();
        private byte m_ActiveRoundInd = 0;
        private Point m_CorrectSequencePos = new Point(10, 10);
        private Point m_FirstRoundPos = new Point(10, 70);
        private const byte m_PaddingBetweenRounds = 10;
        private Size clientSize = new Size();
        
        public BoardForm(byte i_NumRounds)
        {
            m_GameLogic = new GameLogic(i_NumRounds);
            initCorrectSequence();
            initRounds(i_NumRounds);
            r_Rounds[m_ActiveRoundInd].IsActive = true;
            initializeForm();
        }

        private void initializeForm()
        {
            ClientSize = clientSize;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void initCorrectSequence()
        {
            m_CorrectSequence = new CorrectSequenceButtons(m_CorrectSequencePos.X, m_CorrectSequencePos.Y, m_GameLogic.ComputerSequence);
            foreach (PlayerGuessButton button in m_CorrectSequence.Buttons)
            {
                Controls.Add(button);
            }
        }

        private void initRounds(byte i_NumRounds)
        {
            int left = m_FirstRoundPos.X;
            int top = m_FirstRoundPos.Y;

            for (int i = 0; i < i_NumRounds; i++)
            {
                RoundUI newRound = new RoundUI(top, left);

                addSequenceButtonsToControls(newRound.SequenceButtons);
                Controls.Add(newRound.SubmitButton);
                addResultButtonsToControls(newRound.Result);
                //newRound.SubmitButton.Click += SubmitButton_Click;
                newRound.SubmitClicked += Round_SubmitClicked;
                r_Rounds.Add(newRound);

                top += PlayerGuessButton.ButtonSize + m_PaddingBetweenRounds;
            }
            clientSize.Height = top;
            clientSize.Width = r_Rounds[0].Right;
        }

        private void Round_SubmitClicked(object sender)
        {
            RoundUI round = sender as RoundUI;

            if (round.AllButtonsAreSet())
            {
                SubmitClicked(round);
                r_Rounds[m_ActiveRoundInd].IsActive = false;
                // TODO if at the last round stop game
                m_ActiveRoundInd++;
                r_Rounds[m_ActiveRoundInd].IsActive = true;
            }
            else
            {
                MessageBox.Show("Not all Buttons are set, select colors and try again");
            }
        }

        private void addResultButtonsToControls(Result i_Result)
        {
            foreach (Button button in i_Result.Buttons)
            {
                Controls.Add(button);
            }
        }

        private void addSequenceButtonsToControls(SequenceButtons i_SequenceButtons)
        {
            foreach (PlayerGuessButton button in i_SequenceButtons.Buttons)
            {
                Controls.Add(button);
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            RoundUI round = sender as RoundUI;

            if (round.AllButtonsAreSet())
            {
                SubmitClicked(round);
            }
            else
            {
                MessageBox.Show("Not all Buttons are set, select colors and try again");
            }
        }

        internal void SubmitClicked(RoundUI i_RoundUI)
        {
            // When the RoundLogic property is set, the Result buttons are updated
            i_RoundUI.RoundLogic = m_GameLogic.PlayRound(i_RoundUI.GetStringValue());
        }
    }
}
