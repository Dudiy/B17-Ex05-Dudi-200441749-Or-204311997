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
        private const byte k_PaddingFromEdge = 15;
        private const byte k_PaddingBetweenButtons = 5;
        private readonly List<PlayerGuessButton> r_Buttons = new List<PlayerGuessButton>();
        private Color m_ColorPicked = Color.LightGray;

        // ==================================================== Initialize Form ====================================================
        internal PickColorForm()
        {
            initializeForm();
        }

        protected override void OnLoad(EventArgs e)
        {
            initButtons();
            base.OnLoad(e);
        }

        private void initializeForm()
        {
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Text = "Pick A Color:";
            MaximizeBox = false;
            MinimizeBox = false;
        }

        // TODO is this function too long?
        private void initButtons()
        {
            int currentTopOfButton = k_PaddingFromEdge;
            int currentLeftOfButton = k_PaddingFromEdge;
            Array availableColorNames = Enum.GetNames(typeof(eButtonColors));
            int numColors = availableColorNames.Length;
            int currentColorCounter = 0;

            // itterate through all colors in eButtonColos enum and set a button for each one
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
                // half on the top row and half on the bottom row
                if (currentColorCounter == (numColors / 2) - 1)
                {
                    currentLeftOfButton = k_PaddingFromEdge;
                    currentTopOfButton = newButton.Bottom + k_PaddingBetweenButtons;
                }

                currentColorCounter++;
            }

            // after setting the positions of all buttons update the ClientSize to fit
            int clientWidth = currentLeftOfButton + k_PaddingFromEdge - k_PaddingBetweenButtons;
            int clientHeight = currentTopOfButton + PlayerGuessButton.ButtonSize + k_PaddingFromEdge;
            ClientSize = new Size(clientWidth, clientHeight);
        }

        // ==================================================== Properties ====================================================
        internal Color ColorPicked
        {
            get { return m_ColorPicked; }
        }

        // ==================================================== Methods ====================================================
        // an event handler for when one of the buttons is clicked
        private void button_Click(object sender, EventArgs e)
        {
            m_ColorPicked = ((PlayerGuessButton)sender).Color;
            DialogResult = DialogResult.OK;            
            Hide();
        }
    }
}
