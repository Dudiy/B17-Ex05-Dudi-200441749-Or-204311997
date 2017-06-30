/*
 * B17_Ex05: BoardForm.cs
 * 
 * The main form of the game, provides a user interface for the GameLogic
 * The form consists of the correct guess sequence and all rounds of the game.
 * On each round a single row of buttons is enabled for the user to select 
 * colors and submit the selection.
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using B17_Ex05_GameLogic;

namespace B17_Ex05
{
    internal class BoardForm : Form
    {
        private const int k_PaddingFromEdge = 10;
        private const int k_TopOfFirstRound = 70;
        private const byte m_PaddingBetweenRounds = 10;
        private readonly List<RoundUI> r_Rounds = new List<RoundUI>();
        private readonly GameLogic r_GameLogic;
        private CorrectSequenceButtons m_CorrectSequence;
        private byte m_ActiveRoundInd = 0;

        // ==================================================== Initialize Form ====================================================
        internal BoardForm(byte i_NumRounds)
        {
            r_GameLogic = new GameLogic(i_NumRounds);
            initializeForm();
        }

        private void initializeForm()
        {
            // initialize buttons
            initCorrectSequence();
            initRounds(r_GameLogic.MaxNumOfGuessesFromPlayer);
            // design of form
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void initCorrectSequence()
        {
            m_CorrectSequence = new CorrectSequenceButtons(k_PaddingFromEdge, k_PaddingFromEdge, r_GameLogic.ComputerSequence);
            addButtonsToControls(m_CorrectSequence.Buttons);
        }

        private void initRounds(byte i_NumRounds)
        {
            int currentLeft = k_PaddingFromEdge;
            int currentTop = k_TopOfFirstRound;

            for (int i = 0; i < i_NumRounds; i++)
            {
                RoundUI newRound = new RoundUI(currentTop, currentLeft);
                r_Rounds.Add(newRound);
                addButtonsToControls(newRound.Buttons);
                newRound.SubmitClicked += roundSubmitClicked;
                // update top
                currentTop += PlayerGuessButton.ButtonSize + m_PaddingBetweenRounds;
            }

            r_Rounds[0].IsActive = true;
            // after setting all rounds, update the ClientSize to fit
            ClientSize = new Size(r_Rounds[0].Right, currentTop);
        }

        private void addButtonsToControls(List<Button> i_Buttons)
        {
            foreach (Button button in i_Buttons)
            {
                Controls.Add(button);
            }
        }

        // ==================================================== Submit Round ====================================================
        // event handler for when on of the submit buttons is clicked.         
        private void roundSubmitClicked(object sender, EventArgs e)
        {
            RoundUI round = sender as RoundUI;

            // verify all buttons in the sender's round are colored
            if (round.AllButtonsAreSet())
            {
                // When the RoundLogic property is set, the Result buttons are updated
                round.RoundLogic = r_GameLogic.PlayRound(round.GetStringValue());
                r_Rounds[m_ActiveRoundInd].IsActive = false;
                setNextRound();
            }
            else
            {
                MessageBox.Show("Not all Buttons are set, select colors and try again");
            }
        }

        private void setNextRound()
        {
            if (r_GameLogic.GameState == eGameState.Running)
            {
                m_ActiveRoundInd++;
                r_Rounds[m_ActiveRoundInd].IsActive = true;
            }
            else if (r_GameLogic.GameState == eGameState.PlayerWon)
            {
                MessageBox.Show("You win ! Press OK to continue");

                m_CorrectSequence.ShowCorrectGuess();
            }
            else if (r_GameLogic.GameState == eGameState.PlayerLost)
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