using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace B17_Ex05
{
    public class GameManager
    {
        private InitForm m_InitForm = new InitForm();
        private BoardForm m_BoardForm;

        public GameManager()
        {
            initGame();
        }

        private void initGame()
        {
            DialogResult initFormResult = m_InitForm.ShowDialog();

            if (initFormResult != DialogResult.Cancel)
            {
                m_BoardForm = new BoardForm(m_InitForm.NumChoices);
                m_BoardForm.ShowDialog();
            }
        }
    }
}