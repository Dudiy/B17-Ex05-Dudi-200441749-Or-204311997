using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using B17_Ex05_GameLogic;

namespace B17_Ex05
{
    class BoardForm : Form
    {
        private CorrectSequenceButtons m_CorrectSequence;
        GameLogic m_GameLogic;
        private readonly List<RoundUI> r_Rounds = new List<RoundUI>();
        RoundUI m_ActiveRound;

        public BoardForm(byte i_NumRounds)
        {
            m_GameLogic = new GameLogic(i_NumRounds);
            m_CorrectSequence = new CorrectSequenceButtons(10, 10, m_GameLogic.ComputerSequence);
        }
    }
}
