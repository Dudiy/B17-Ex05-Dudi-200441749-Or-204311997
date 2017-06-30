/*
 * B17_Ex05: BoardForm.cs
 * 
 * Inherits from the "Form" class.
 * 
 * That class is the board of the game.
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using B17_Ex05_GameLogic;
using System.Drawing;

namespace B17_Ex05
{
    internal class BoardForm : Form
    {
        private GameLogic m_GameLogic;
        private CorrectSequenceButtons m_CorrectSequence;
        private readonly List<RoundUI> r_Rounds = new List<RoundUI>();
        private byte m_ActiveRoundInd = 0;
        private Point m_CorrectSequencePos = new Point(10, 10);
        private Point m_FirstRoundPos = new Point(10, 70);
        private const byte m_PaddingBetweenRounds = 10;
        private Size clientSize = new Size();

        // ==================================================== Initialize Form ====================================================
        internal BoardForm(byte i_NumRounds)
        {
            m_GameLogic = new GameLogic(i_NumRounds);
            initializeForm();
        }

        private void initializeForm()
        {
            // initialize buttons
            initCorrectSequence();
            initRounds(m_GameLogic.MaxNumOfGuessesFromPlayer);
            // design
            ClientSize = clientSize;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void initCorrectSequence()
        {
            m_CorrectSequence = new CorrectSequenceButtons(m_CorrectSequencePos.X, m_CorrectSequencePos.Y, m_GameLogic.ComputerSequence);
            addButtonsToControls(m_CorrectSequence.Buttons);
        }

        private void initRounds(byte i_NumRounds)
        {
            RoundUI newRound;
            int currentTop = m_FirstRoundPos.Y;
            int currentLeft = m_FirstRoundPos.X;
            
            for (int i = 0; i < i_NumRounds; i++)
            {
                newRound = new RoundUI(currentTop, currentLeft);
                r_Rounds.Add(newRound);
                addButtonsToControls(newRound.Buttons);
                newRound.SubmitClicked += roundSubmitClicked;
                // update top
                currentTop += PlayerGuessButton.ButtonSize + m_PaddingBetweenRounds;
            }

            r_Rounds[m_ActiveRoundInd].IsActive = true;
            // boardForm design
            clientSize.Width = r_Rounds[0].Right;
            clientSize.Height = currentTop;
        }

        private void addButtonsToControls(List<Button> i_Buttons)
        {
            foreach (Button button in i_Buttons)
            {
                Controls.Add(button);
            }
        }

        // ==================================================== Submit Round ====================================================
        private void roundSubmitClicked(object sender)
        {
            RoundUI round = sender as RoundUI;

            if (round.AllButtonsAreSet())
            {
                SubmitClicked(round);
                r_Rounds[m_ActiveRoundInd].IsActive = false;
                checkState();
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

        private void checkState()
        {
            if (m_GameLogic.GameState == eGameState.Running)
            {
                m_ActiveRoundInd++;
                r_Rounds[m_ActiveRoundInd].IsActive = true;
            }
            else if (m_GameLogic.GameState == eGameState.PlayerWon)
            {
                MessageBox.Show("You win ! Press OK to continue");

                m_CorrectSequence.ShowCorrectGuess();
            }
            else if (m_GameLogic.GameState == eGameState.PlayerLost)
            {
                MessageBox.Show("You lose ! Press OK to view the correct sequence");

                m_CorrectSequence.ShowCorrectGuess();
            }
            else
            {
                throw new Exception("Unknown game state");
            }
        }
    }
}

        //private void SubmitButton_Click(object sender, EventArgs e)
        //{
        //    RoundUI round = sender as RoundUI;

        //    if (round.AllButtonsAreSet())
        //    {
        //        SubmitClicked(round);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Not all Buttons are set, select colors and try again");
        //    }
        //}
