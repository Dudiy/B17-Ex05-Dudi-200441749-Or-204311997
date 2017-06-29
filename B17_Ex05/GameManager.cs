using System;
using System.Collections.Generic;
using System.Text;

namespace B17_Ex05
{
    public class GameManager
    {
        private InitForm m_InitForm = new InitForm();
        private BoardForm m_BoardForm;

        public GameManager()
        {
            initGame();
            m_BoardForm.ShowDialog();
        }

        private void initGame()
        {
            m_InitForm.ShowDialog();
            m_BoardForm = new BoardForm(m_InitForm.NumChoices);
        }
    }
}