/*
 * B17_Ex05: GameManager.cs
 * 
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
 */
using System.Windows.Forms;

namespace B17_Ex05
{
    internal class GameManager
    {
        private InitForm m_InitForm = new InitForm();
        private BoardForm m_BoardForm;

        // ==================================================== Initialize ====================================================
        internal GameManager()
        {
            initGame();
        }

        private void initGame()
        {
            DialogResult initFormResult = m_InitForm.ShowDialog();

            if (initFormResult != DialogResult.Cancel)
            {
                m_BoardForm = new BoardForm(m_InitForm.NumChoices);
            }
        }

        internal void Run()
        {
            m_BoardForm.ShowDialog();
        }
    }
}