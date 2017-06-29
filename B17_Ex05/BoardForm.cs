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
        private RoundUI m_ActiveRound;
        private Point m_CorrectSequencePos = new Point(10, 10);
        private Point m_FirstRoundPos = new Point(10, 40);

        public BoardForm(byte i_NumRounds)
        {
            m_GameLogic = new GameLogic(i_NumRounds);
            m_CorrectSequence = new CorrectSequenceButtons(m_CorrectSequencePos, m_GameLogic.ComputerSequence);
            initRounds(i_NumRounds);
        }

        private void initRounds(byte i_NumRounds)
        {
            int left = m_FirstRoundPos.X;
            int top = m_FirstRoundPos.Y;

            for (int i = 0; i < i_NumRounds; i++)
            {
                RoundUI newRound = new RoundUI(top, left);

                addSequenceButtonsToControls(newRound.SequenceButtons);
                newRound.SubmitButton.Click += SubmitButton_Click;
                Controls.Add(newRound.SubmitButton);
                r_Rounds.Add(newRound);
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
                SubmitClickedEventArgs args = e as SubmitClickedEventArgs;
                SubmitClicked(round, args.StringSubmitted);
            }
            else
            {
                MessageBox.Show("Not all Buttons are set, select colors and try again");
            }
        }

        internal void SubmitClicked(RoundUI i_RoundUI, string i_SequenceSubmitted)
        {
            byte correctGuessesReturned;
            byte missplacedGuessesReturned;

            m_GameLogic.PlayRound(i_SequenceSubmitted, out correctGuessesReturned, out missplacedGuessesReturned);
            i_RoundUI.CorrectGuesses = correctGuessesReturned;
            i_RoundUI.MisplacedGuesses = missplacedGuessesReturned;
        }
    }
}
