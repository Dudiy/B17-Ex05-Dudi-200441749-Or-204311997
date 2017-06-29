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
        private char m_CharValue;
        private bool m_Hidden = false;
        private bool m_IsSet = false;

        internal PlayerGuessButton()
        {
            initButton();
        }

        internal bool IsSet
        {
            get { return m_IsSet; }
        }

        internal static byte ButtonSize
        {
            get { return sr_ButtonSize; }
        }

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

        internal char CharValue
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
