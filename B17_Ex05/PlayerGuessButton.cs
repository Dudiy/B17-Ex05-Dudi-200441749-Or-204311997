/*
 * B17_Ex05: PlayerGuessButton.cs
 * 
 * Inherits from the "Button" class.
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
        private static readonly byte sr_ButtonSize = 40;
        private char m_CharValue;
        private bool m_Hidden = false;
        private bool m_IsSet = false;

        // ==================================================== Initialize ====================================================
        internal PlayerGuessButton()
        {
            initButton();
        }

        private void initButton()
        {
            Width = sr_ButtonSize;
            Height = sr_ButtonSize;
            BackColor = Color.LightGray;
        }

        // ==================================================== Properties ====================================================
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

        internal static byte ButtonSize
        {
            get { return sr_ButtonSize; }
        }

        internal char CharValue
        {
            get { return m_CharValue; }
        }

        internal bool Hidden
        {
            get { return m_Hidden; }
            set
            {
                if (value)
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

        internal bool IsSet
        {
            get { return m_IsSet; }
        }

        // ==================================================== Methods ====================================================
        internal void SetColorByChar(char i_Char)
        {
            try
            {
                //eButtonColors colorValue = (eButtonColors)Enum.Parse(typeof(eButtonColors), i_Char.ToString());
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
