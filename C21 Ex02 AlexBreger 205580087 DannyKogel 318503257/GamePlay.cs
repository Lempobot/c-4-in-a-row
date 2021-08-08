﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C21_Ex02_AlexBreger_205580087_DannyKogel_318503257
{
    class GamePlay
    {
        private const string mk_PositiveAnswer = "y";
        private const string mk_NegativeAnswer = "n";
        private int m_RoundCounter;
        private Board m_Board;
        private bool m_IsAgainstAi;
        private bool m_IsAnotherRound;
        private bool m_IsGameOn;
        private Player m_Player1;
        private Player m_Player2;
        private Chips m_Chips;


        public GamePlay(Board board)
        {
            Board = board;
            IsGameOn = true;
            RoundCounter = 0;
            Chips = new Chips();
        }

        private bool checkIfPlayerWantsAnotherRound()
        {
            bool isAnotherRound = true;
            string userInput;
            do
            {
                Console.WriteLine(string.Format("Please enter '{0}' if you want to play another round and '{1}' if you want to finish the game", mk_PositiveAnswer, mk_NegativeAnswer));
                userInput = Console.ReadLine();
            } while (!checkUserInputForYesNo(userInput));

            if (userInput.ToLower().Equals(mk_NegativeAnswer))
            {
                isAnotherRound = false;
            }

            return isAnotherRound;
        }

        private bool checkIfPlayAgainstAi()
        {
            bool isAgainstAi = true;
            string userInput;
            do
            {
                Console.WriteLine(string.Format("Please enter '{0}' if you want to play against AI and '{1}' if you want to play against a human", mk_PositiveAnswer, mk_NegativeAnswer));
                userInput = Console.ReadLine();
            } while (!checkUserInputForYesNo(userInput));

            if (userInput.ToLower().Equals(mk_NegativeAnswer))
            {
                isAgainstAi = false;
            }

            return isAgainstAi;
        }

        private bool checkUserInputForYesNo(string i_UserInput)
        {
            bool checkInput = true;
            if(!(i_UserInput.ToLower().Equals(mk_PositiveAnswer) || i_UserInput.ToLower().Equals(mk_NegativeAnswer)))
            {
                checkInput = false;
            }
            return checkInput;
        }
        private string choosePlayerSymbol()
        {
            string userInput;

            do
            {
                Console.WriteLine("Please choose your symbol from the list by entering the corresponding number symbol");
                userInput = Console.ReadLine();
            } while (!Chips.ChipsList.Contains(userInput));
            Chips.ChipsList.Remove(userInput);

            return userInput;
        }

        public void GameOn()
        {
            IsAgainstAi = true;
            string aIName = "CPU";
            if (checkIfPlayAgainstAi())
            {
                Player2 = new Player(Board);
                Player1 = new Player(Board);
                Player2.IsAi = IsAgainstAi;
                Player2.Name = aIName;
                Player1.PlayerSymbol = choosePlayerSymbol();
                Player2.PlayerSymbol = Chips.ChipsList.Last();
                Player1.PlayerTurn = true;
            }
            else
            {
                Random randomTurn = new Random();
                IsAgainstAi = false;
                Player1 = new Player(Board);
                Player2 = new Player(Board);
                Player1.PlayerSymbol = choosePlayerSymbol();
                Player2.PlayerSymbol = choosePlayerSymbol();
                Player1.PlayerTurn = randomTurn.NextDouble() > 0.5;
            }


            while (IsGameOn)
            {
                if ()
                {

                }
                
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

        public Player Player1
        {
            get
            {
                return m_Player1;
            }

            set
            {
                m_Player1 = value;
            }
        }

        public Player Player2
        {
            get
            {
                return m_Player2;
            }

            set
            {
                m_Player2 = value;
            }
        }
        public bool IsAgainstAi
        {
            get
            {
                return m_IsAgainstAi;
            }

            set
            {
                m_IsAgainstAi = value;
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
        public int RoundCounter
        {
            get
            {
                return m_RoundCounter;
            }

            set
            {
                m_RoundCounter = value;
            }
        }
        public bool IsGameOn
        {
            get
            {
                return m_IsGameOn;
            }

            set
            {
                m_IsGameOn = value;
            }
        }
        public bool IsAnotherRound
        {
            get
            {
                return m_IsAnotherRound;
            }

            set
            {
                m_IsAnotherRound = value;
            }
        }
    }
}