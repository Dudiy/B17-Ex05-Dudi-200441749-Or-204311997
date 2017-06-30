/*
 * B17_Ex05: InitForm.cs
 * 
 * The for that initializes the game, gets the number of guesses from the user and 
 * starts a new game when "Start" is clicked
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
 */
using System;
using System.Windows.Forms;
using System.Drawing;
using B17_Ex05_GameLogic;

namespace B17_Ex05
{
    internal class InitForm : Form
    {
        private const short k_ClientWidth = 250;
        private const short k_ClientHeight = 100;
        private const short k_PaddingFromEdge = 10;
        private Button m_ButtonStart = new Button();
        private Button m_ButtonNumChoices = new Button();
        private byte m_NumChoices = GameLogic.MinNumOfGuesses;

        // ==================================================== Initialize =========================================================
        internal InitForm()
        {
            setFormProperties();
        }

        private void setFormProperties()
        {
            ClientSize = new Size(k_ClientWidth, k_ClientHeight);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Bool Pgia";
        }

        protected override void OnLoad(EventArgs e)
        {
            initControls();
            base.OnLoad(e);
        }

        private void initControls()
        {
            // initialize m_ButtonNumChoices
            m_ButtonNumChoices.Width = ClientSize.Width - (2 * k_PaddingFromEdge);
            m_ButtonNumChoices.Top = k_PaddingFromEdge;
            m_ButtonNumChoices.Left = k_PaddingFromEdge;
            m_ButtonNumChoices.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            m_ButtonNumChoices.Text = string.Format("Number of chances: {0}", m_NumChoices);
            m_ButtonNumChoices.Click += buttonNumChoices_Click;
            Controls.Add(m_ButtonNumChoices);
            // initialize m_ButtonStart
            m_ButtonStart.Width = ClientSize.Width / 3;
            m_ButtonStart.Top = ClientSize.Height - k_PaddingFromEdge - m_ButtonStart.Height;
            m_ButtonStart.Left = ClientSize.Width - k_PaddingFromEdge - m_ButtonStart.Width;
            m_ButtonStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            m_ButtonStart.Text = "Start";
            m_ButtonStart.Click += buttonStart_Click;
            Controls.Add(m_ButtonStart);
        }

        // ==================================================== Properties =========================================================
        internal byte NumChoices
        {
            get { return m_NumChoices; }
        }

        // ==================================================== Methods =====================================================
        private void buttonStart_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonNumChoices_Click(object sender, EventArgs e)
        {
            m_NumChoices++;
            if (m_NumChoices > GameLogic.MaxNumOfGuesses)
            {
                m_NumChoices = GameLogic.MinNumOfGuesses;
            }

            ((Button)sender).Text = string.Format("Number of chances: {0}", m_NumChoices);
        }
    }
}
