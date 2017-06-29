﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace B17_Ex05
{
    internal class PlayerGuessButton : Button
    {
        private static readonly byte sr_ButtonSize = 40;
        private char m_CharValue = ' ';

        public PlayerGuessButton()
        {
            initButton();
        }

        public static byte ButtonSize
        {
            get { return sr_ButtonSize; }
        }

        internal void SetColorByChar(char i_Char)
        {
            try
            {
                eButtonColors colorValue = (eButtonColors)Enum.Parse(typeof(eButtonColors), i_Char.ToString());
                BackColor = Color.FromName(colorValue.ToString());
                m_CharValue = i_Char;
            }
            catch
            {
                throw new ArgumentException("The given char is not supported");
            }
        }

        public Color Color
        {
            get { return BackColor; }
            set
            {
                try
                {
                    eButtonColors colorValue = (eButtonColors)Enum.Parse(typeof(eButtonColors), value.Name);
                    BackColor = value;
                    m_CharValue = (char)colorValue;
                }
                catch
                {
                    throw new ArgumentException("The given color is not supported");
                }
            }
        }
        
        // TODO for correct sequence - to change the color without changing the letter
        public void ColorInBlack()
        {

        }

        public char CharValue
        {
            get { return m_CharValue; }
        }

        private void initButton()
        {
            Width = sr_ButtonSize;
            Height = sr_ButtonSize;
            BackColor = Color.LightGray;
        }


    }
}
