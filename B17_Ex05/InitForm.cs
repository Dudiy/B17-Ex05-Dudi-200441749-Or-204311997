using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using B17_Ex05_GameLogic;

namespace B17_Ex05
{
    internal class InitForm : Form
    {
        private Button m_ButtonStart = new Button();
        private Button m_ButtonNumChoices = new Button();
        private byte m_NumChoices = GameLogic.MinNumOfGuesses;

        internal InitForm()
        {
            initializeForm();
        }

        private void initializeForm()
        {
            Text = "Bool Pgia";
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        internal byte NumChoices
        {
            get { return m_NumChoices; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            initControls();
        }

        private void initControls()
        {
            // initialize m_ButtonNumChoices
            m_ButtonNumChoices.Left = 10;
            m_ButtonNumChoices.Top = 10;
            m_ButtonNumChoices.Width = ClientSize.Width - 20;
            m_ButtonNumChoices.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            m_ButtonNumChoices.Text = string.Format("Number of chances: {0}", m_NumChoices);
            m_ButtonNumChoices.Click += buttonNumChoices_Click;
            Controls.Add(m_ButtonNumChoices);
            // initialize m_ButtonStart
            m_ButtonStart.Width = 40;
            m_ButtonStart.Left = ClientSize.Width - 10 - m_ButtonStart.Width;
            m_ButtonStart.Top = ClientSize.Height - 10 - m_ButtonStart.Height;
            m_ButtonStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            m_ButtonStart.Text = "Start";
            m_ButtonStart.Click += buttonStart_Click;
            AcceptButton = m_ButtonStart;
            Controls.Add(m_ButtonStart);
        }

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
