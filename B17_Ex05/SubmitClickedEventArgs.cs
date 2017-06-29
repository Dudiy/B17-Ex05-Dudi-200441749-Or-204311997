using System;
using System.Collections.Generic;
using System.Text;

namespace B17_Ex05
{
    class SubmitClickedEventArgs : EventArgs
    {
        private string m_StringSubmitted;

        public string StringSubmitted
        {
            get { return m_StringSubmitted; }
            set { m_StringSubmitted = value; }
        }
    }
}
