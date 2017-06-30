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
        private InitForm m_InitForm;
        private BoardForm m_BoardForm;

        // ==================================================== Initialize ====================================================
        internal GameManager()
        {
            m_InitForm = new InitForm();
        }

        internal void Run()
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