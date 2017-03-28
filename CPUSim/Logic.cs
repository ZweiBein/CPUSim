﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSim
{
    internal enum OpCodes
    {
        LOAD = 01,
        ADD = 02,
        SUBTRACT = 03,
        DIVIDE = 04,
        MULTIPLY = 05,
        STORE = 06,
        JUMP = 07,
        TEST_ZERO = 08,
        TEST_GREATER_THAN = 09,
        STOP = 99

    }
    internal class Logic
    {
        
        uint[] _ram;
        uint _accumulator;
        uint _programCounter;
        OpCodes _command;

        public uint[] RAM
        {
            get { return _ram; }
            set { _ram = value; }
            
        }

        public uint Accumulator
        {
            get { return _accumulator; }
        }

        public Logic()
        {
            _ram = new uint[40];
            _accumulator = 0; //remmember thiis is unsigned.
            _programCounter = 0;
            
        }

        public void RunProgram(List<string> instructions)
        {
            while (instructions.Count > _programCounter)
            {
                TakeCommand(instructions[(int)_programCounter]);
            }
            
        }

        public void TakeCommand(string inputString)
        {
            _ram[_programCounter] = uint.Parse(inputString);
            _command = (OpCodes)(int.Parse(inputString.Substring(0, 2)));
            uint inputValue = uint.Parse(inputString.Substring(2));

            switch (_command)
            {
                case OpCodes.LOAD:
                    Load(inputValue);
                    
                    break;
                case OpCodes.ADD:
                    Add(inputValue);
                    break;
                case OpCodes.SUBTRACT:
                    Subtract(inputValue);
                    break;
                case OpCodes.DIVIDE:
                    Divide(inputValue);
                    break;
                case OpCodes.MULTIPLY:
                    Multiply(inputValue);
                    break;
                case OpCodes.STORE:
                    Store(inputValue);
                    break;
                case OpCodes.JUMP:
                    break;
                case OpCodes.TEST_ZERO:
                    break;
                case OpCodes.TEST_GREATER_THAN:
                case OpCodes.STOP:
                    Exit();
                    break;
                
            }
        }

        void Load(uint inputValue)
        {
            _accumulator = _ram[inputValue];
            _programCounter++;
        }

        void Add(uint inputValue)
        {
            _accumulator += _ram[inputValue];
            _programCounter++;
        }

        void Subtract(uint inputValue)
        {
            _accumulator -= _ram[inputValue];
            _programCounter++;
        }

        void Divide(uint inputValue)
        {
            _accumulator = _accumulator / _ram[inputValue];
            _programCounter++;
        }
        void Multiply(uint inputValue)
        {
            _accumulator = _accumulator * _ram[inputValue];
            _programCounter++;
        }

        void Store(uint inputValue)
        {
            _ram[inputValue] = _accumulator;
            _programCounter++;
        }

        void Jump(uint inputValue)
        {
            _programCounter = inputValue;
        }

        void TestZero()
        {
            if (_accumulator == 0)
            {
                _programCounter++;
            }
            else
            {
                _programCounter += 2;
            }
        }

        void TestGreaterThan(uint inputValue)
        {
            if (_accumulator.CompareTo(inputValue) == 1 || _accumulator.CompareTo(inputValue) == 1)
            {
                _programCounter++;
            }
            else
            {
                _programCounter += 2;
            }
        }
        void Exit()
        {
            Environment.Exit(0);
        }
    }
}