/*
 * B17_Ex05: PickColorForm.cs
 * 
 * Inherits from the "Form" class.
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace B17_Ex05
{
    internal class PickColorForm : Form
    {   
        private List<PlayerGuessButton> m_Buttons = new List<PlayerGuessButton>();
        private Color m_ColorPicked = Color.LightGray;
        private const byte k_NumButtons = 8;
        private const byte k_PaddingFromEdge = 15;
        private const byte k_PaddingBetweenButtons = 5;

        // ==================================================== Initialize Form ====================================================
        internal PickColorForm()
        {
            initializeForm();
        }

        private void initializeForm()
        {
            // we know that there are 8 colors to pick from!            
            int clientWidth = (PlayerGuessButton.ButtonSize * 4) + (k_PaddingFromEdge * 2) + (k_PaddingBetweenButtons * 3);
            int clientHeight = (PlayerGuessButton.ButtonSize * 2) + (k_PaddingFromEdge * 2) + (k_PaddingBetweenButtons * 1);
            ClientSize = new Size(clientWidth, clientHeight);
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            initButtons();
        }

        private void initButtons()
        {
            int currentTopOfButton = k_PaddingFromEdge;
            int currentLeftOfButton = k_PaddingFromEdge;

            foreach (string buttonColor in Enum.GetNames(typeof(eButtonColors)))
            {
                PlayerGuessButton newButton = new PlayerGuessButton();
                newButton.Color = Color.FromName(buttonColor);
                newButton.Top = currentTopOfButton;
                newButton.Left = currentLeftOfButton;
                newButton.Click += button_Click;
                Controls.Add(newButton);
                // update left and top for next button
                currentLeftOfButton = newButton.Right + k_PaddingBetweenButtons;
                if (currentLeftOfButton + PlayerGuessButton.ButtonSize > ClientSize.Width)
                {
                    currentLeftOfButton = k_PaddingFromEdge;
                    currentTopOfButton = newButton.Bottom + k_PaddingBetweenButtons;
                }
            }
        }

        // ==================================================== Properties ====================================================
        internal Color ColorPicked
        {
            get { return m_ColorPicked; }
        }

        // ==================================================== Buttons Events ====================================================
        private void button_Click(object sender, EventArgs e)
        {
            m_ColorPicked = ((PlayerGuessButton)sender).Color;
            DialogResult = DialogResult.OK;
            Hide();
        }
    }
}
