/*
 * B17_Ex05: PickColorForm.cs
 * 
 * A Form used to get a color selection from the user.
 * The form is opened when a PlayerGuessButton is clicked.
 * When a color is selected in the form, the form will close and update
 * it's caller with the selected color.
 * If the form is closed without a color being selected there will 
 * be no change in the caller's values.
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
        private const byte k_NumButtons = 8;
        private const byte k_PaddingFromEdge = 15;
        private const byte k_PaddingBetweenButtons = 5;
        private List<PlayerGuessButton> m_Buttons = new List<PlayerGuessButton>();
        private Color m_ColorPicked = Color.LightGray;

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
            initButtons();
            base.OnLoad(e);
        }

        private void initButtons()
        {
            int currentTopOfButton = k_PaddingFromEdge;
            int currentLeftOfButton = k_PaddingFromEdge;
            Array availableColorNames = Enum.GetNames(typeof(eButtonColors));
            int numColors = availableColorNames.Length;

            // itterate though all colors in eButtonColos enum and set a button for each one
            foreach (string buttonColor in availableColorNames)
            {
                PlayerGuessButton newButton = new PlayerGuessButton();

                newButton.Color = Color.FromName(buttonColor);
                newButton.Top = currentTopOfButton;
                newButton.Left = currentLeftOfButton;
                newButton.Click += button_Click;
                Controls.Add(newButton);
                // update left and top for next button
                currentLeftOfButton = newButton.Right + k_PaddingBetweenButtons;
                // if the button exceeds the ClientSize go
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
