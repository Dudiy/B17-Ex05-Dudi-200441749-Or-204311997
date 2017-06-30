/*
 * B17_Ex05: PlayerGuessButton.cs
 * 
 * Inherits from the "Button" class. 
 * A Single button on the form which represents a single char that is selected by the user as part of a sequnce.
 * Each button holds both it's Color value and the Char that it represents, both these values are 
 * always updated simultaneously.
 * A PlayerGuessButton can also be hidden - will be colored black (used for the correct sequence buttons)
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace B17_Ex05
{
    internal class PlayerGuessButton : Button
    {
        private const byte k_ButtonSize = 40;
        private char m_CharValue;
        private bool m_Hidden = false;
        private bool m_IsSet = false;

        // ==================================================== Initialize =========================================================
        internal PlayerGuessButton()
        {
            initButton();
        }

        internal PlayerGuessButton(int i_Top, int i_Left)
            :this()
        {
            Top = i_Top;
            Left = i_Left;
        }

        private void initButton()
        {
            Width = k_ButtonSize;
            Height = k_ButtonSize;
            BackColor = Color.LightGray;
        }

        // ==================================================== Properties ====================================================
        // Color property of each button, when set will also update the Button's m_CharValue data member accordingly
        internal Color Color
        {
            get { return BackColor; }
            set
            {
                try
                {
                    eButtonColors colorValue = (eButtonColors)Enum.Parse(typeof(eButtonColors), value.Name);

                    BackColor = value;
                    m_CharValue = (char)colorValue;
                    m_IsSet = true;
                }
                catch
                {
                    throw new ArgumentException("The given color is not supported");
                }
            }
        }

        // No set methoid for this property, can only be changed by setting the Color property or via SetColorByChar method
        internal char CharValue
        {
            get { return m_CharValue; }
        }

        internal static byte ButtonSize
        {
            get { return k_ButtonSize; }
        }

        /* When a button is hidden its color is black but the m_CharValue isn't changed.
         * When a button is revealed its color is restored according to it's m_CharValue. */
        internal bool Hidden
        {
            get { return m_Hidden; }
            set
            {
                if (value == true)
                {
                    BackColor = Color.Black;
                }
                else
                {
                    SetColorByChar(m_CharValue);
                }

                m_Hidden = value;
            }
        }

        // returns TRUE if a button has a color
        internal bool IsSet
        {
            get { return m_IsSet; }
        }

        // ==================================================== Methods ====================================================
        /* update a button's color by setting it's m_CharValue.
         * we chose not to use a setter in order to improve readability */
        internal void SetColorByChar(char i_Char)
        {
            try
            {
                eButtonColors colorValue = (eButtonColors)i_Char;
                BackColor = Color.FromName(colorValue.ToString());
                m_CharValue = i_Char;
                m_IsSet = true;
            }
            catch
            {
                throw new ArgumentException("The given char is not supported");
            }
        }        
    }
}
