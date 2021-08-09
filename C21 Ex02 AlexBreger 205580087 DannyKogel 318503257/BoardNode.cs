﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex02_AlexBreger_205580087_DannyKogel_318503257
{
    class BoardNode
    {
        private string m_DefaultEmptySpaceValue = " ";
        private bool m_Free;
        private string m_PlayerSymbol;
        
        public BoardNode()
        {
            Free = true;
            PlayerSymbol = m_DefaultEmptySpaceValue;
        }

        public override string ToString()
        {
            return string.Format("|{0}", PlayerSymbol);
        }

        public bool Free
        {
            get
            {
                return m_Free;
            }

            set
            {
                m_Free = value;
            }
        }

        public string PlayerSymbol
        {
            get
            {
                return m_PlayerSymbol;
            }

            set
            {
                m_PlayerSymbol = value;
            }
        }

    }
}
