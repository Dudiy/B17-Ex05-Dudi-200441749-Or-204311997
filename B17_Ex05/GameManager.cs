/*
 * B17_Ex05: GameManager.cs
 * 
 * The manager of the app, connects between the InitForm and the BoardForm. 
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

        // ==================================================== Initialize =========================================================
        internal GameManager()
        {
            m_InitForm = new InitForm();
        }

        internal void Run()
        {
            DialogResult initFormResult = m_InitForm.ShowDialog();

            // if the user closes the InitForm without selecting "Start" do not start the game
            if (initFormResult != DialogResult.Cancel)
            {
                m_BoardForm = new BoardForm(m_InitForm.NumChoices);
                m_BoardForm.ShowDialog();
            }
        }
    }
}