using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C21_Ex02_AlexBreger_205580087_DannyKogel_318503257
{
    class Board
    {
        private const byte mk_MaxSize = 8;
        private const byte mk_MinSize = 4;
        private static byte m_Rows;
        private static byte m_Columns;
        private BoardNode[,] m_BoardMatrix;
        private int[] m_ArrayToCheckUserInsertion;
        private BoardUi m_BoardUi;

        public Board()
        {
            BoardUi = new BoardUi(this);
            Rows = userInput();
            Columns = userInput();
            InitializeMatrix();
            InitializeArray();
        }

        public BoardUi BoardUi
        {
            get
            {
                return m_BoardUi;
            }

            set
            {
                m_BoardUi = value;
            }
        }
        public int[] ArrayToCheckUserInsertion
        {
            get
            {
                return m_ArrayToCheckUserInsertion;
            }

            set
            {
                m_ArrayToCheckUserInsertion = value;
            }
        }

        public static byte Rows
        {
            get
            {
                return m_Rows;
            }

            set
            {
                m_Rows = value;
            }
        }

        public static byte Columns
        {
            get
            {
                return m_Columns;
            }

            set
            {
                m_Columns = value;
            }
        }

        public BoardNode[,] BoardMatrix
        {
            get
            {
                return m_BoardMatrix;
            }

            set
            {
                m_BoardMatrix = value;
            }
        }

        public void InitializeArray()
        {
            ArrayToCheckUserInsertion = new int[Columns];
            for (int i = 0; i < ArrayToCheckUserInsertion.Length; i++)
            {
                ArrayToCheckUserInsertion[i] = Rows - 1;
            }
        }

        public void InitializeMatrix()
        {
            BoardMatrix = new BoardNode[Rows, Columns];
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    BoardMatrix[row, column] = new BoardNode();
                }
            }
        }

        public bool checkUserInputIntoBoard(int i_UserInput)
        {
            return i_UserInput >= 0 && i_UserInput < Columns && ArrayToCheckUserInsertion[i_UserInput] > -1;
        }

        public bool IsBoardFull()
        {
            bool flagToCheckZeroesInArray = true;
            for (int i = 0; i < ArrayToCheckUserInsertion.Length; i++)
            {
                if (ArrayToCheckUserInsertion[i] != -1)
                {
                    flagToCheckZeroesInArray = false;
                    break;
                }
            }

            return flagToCheckZeroesInArray;
        }

        private static bool checkBoardSizeLimits(byte value)
        {
            bool isSizeLimitOk = true;
            if (value > mk_MaxSize || value < mk_MinSize)
            {
                isSizeLimitOk = false;
            }

            return isSizeLimitOk;
        }

        private byte userInput()
        {
            string input;
            byte inputInByte;

            do
            {
                input = BoardUi.BoardUserInput(mk_MaxSize, mk_MinSize);
            } while (!(byte.TryParse(input, out inputInByte) && checkBoardSizeLimits(inputInByte)));

            return inputInByte;
        }
    }
}
