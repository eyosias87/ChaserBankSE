﻿using System;
using ChasersBankSE;
namespace ChasersBankSE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Chasers Bank SE!");
            BankSystem bankSystem = new BankSystem();
            bankSystem.DisplayMainMenu();
        }
    }
}
