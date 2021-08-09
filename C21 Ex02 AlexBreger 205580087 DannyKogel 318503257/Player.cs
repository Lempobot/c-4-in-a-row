﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex02_AlexBreger_205580087_DannyKogel_318503257
{
    class Player
    {
        private string m_Name;
        private int m_NumberOfWins;
        private Board m_Board;
        private string m_PlayerSymbol;
        private bool m_IsAi;
        private bool m_PlayerTurn;
        private int m_LastRowInsertion;
        private int m_LastColumnInsertion;
        private Chips m_Chips;


        public Player(Board i_Board, bool i_IsAi)
        {
            initPlayerName();
            Board = i_Board;
            IsAi = i_IsAi;
            choosePlayerSymbol();
            PlayerTurn = false;
        }

        private void initPlayerName()
        {
            if (!IsAi)
            {
                Console.WriteLine("Please enter your name");
                Name = Console.ReadLine();
            }
            else
            {
                Name = "CPU";
            }
        }

        public void InsertIntoBoard()
        {
            Random randomInputForAi = new Random();
            int inputInInt;
            string userInput;
            if (!IsAi)
            {
                do
                {
                    Console.WriteLine(string.Format("{0} please choose a column number to insert the token into", Name));
                    userInput = Console.ReadLine();
                } while (!(int.TryParse(userInput, out inputInInt) && Board.checkUserInputIntoBoard(inputInInt)));
            }
            else
            {
                inputInInt = randomInputForAi.Next(1, Board.Columns);
            }

            LastColumnInsertion = inputInInt;
            Board.BoardMatrix[Board.ArrayToCheckUserInsertion[inputInInt - 1], inputInInt - 1].PlayerSymbol = PlayerSymbol;
            LastRowInsertion = Board.ArrayToCheckUserInsertion[inputInInt - 1];
            Board.ArrayToCheckUserInsertion[inputInInt - 1] = Board.ArrayToCheckUserInsertion[inputInInt - 1] - 1;
        }

        public void changeTurnState()
        {
            PlayerTurn = !PlayerTurn;
        }

        private void choosePlayerSymbol()
        {
            string userInput;

            if (!IsAi)
            {
                do
                {
                    Console.WriteLine("Please choose your symbol from the list by entering the corresponding symbol");
                    Chips.ChipsList.ForEach(Console.Write);
                    Console.WriteLine();
                    userInput = Console.ReadLine();
                } while (!Chips.ChipsList.Contains(userInput)) ;
                Chips.ChipsList.Remove(userInput);
                PlayerSymbol = userInput;
            }
            else
            {
                PlayerSymbol = Chips.ChipsList.Last();
            }
            

        }

        public Chips Chips
        {
            get
            {
                return m_Chips;
            }
            set
            {
                m_Chips = value;
            }
        }
        public int LastRowInsertion
        {
            get
            {
                return m_LastRowInsertion;
            }
            set
            {
                m_LastRowInsertion = value;
            }
        }

        public int LastColumnInsertion
        {
            get
            {
                return m_LastColumnInsertion;
            }
            set
            {
                m_LastColumnInsertion = value;
            }
        }

        public bool PlayerTurn
        {
            get
            {
                return m_PlayerTurn;
            }

            set
            {
                m_PlayerTurn = value;
            }
        }
        
        public bool IsAi
        {
            get
            {
                return m_IsAi;
            }

            set
            {
                m_IsAi = value;
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
        public Board Board
        {
            get
            {
                return m_Board;
            }

            set
            {
                m_Board = value;
            }
        }
        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
            }
        }

        public int Score
        {
            get
            {
                return m_NumberOfWins;
            }

            set
            {
                m_NumberOfWins = value;
            }
        }
    }
}
