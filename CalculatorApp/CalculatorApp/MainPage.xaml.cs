﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorApp
{
	public partial class MainPage : ContentPage
	{
        private string displayValue = "0";
        private double firstNumber, secondNumber, result;
        private char operation;
        private bool anOperationClicked = false;

		public MainPage()
		{
			InitializeComponent();

            CButton.Clicked += (sender, e) =>
            {
                displayValue = "0";
                DisplayLabel.Text = displayValue;
                EquationLabel.Text = string.Empty;
                result = 0;
                anOperationClicked = false;
            };

            EqualsButton.Clicked += (sender, e) =>
            {

                int secondValueStart = firstNumber.ToString().Length + 1;

                if (displayValue.Substring(secondValueStart) == string.Empty)
                {
                    DisplayMessage("Syntax Error", "Press C button again.");
                }
                else
                {
                    secondNumber = double.Parse(displayValue.Substring(secondValueStart));
                    
                    switch (operation)
                    {
                        case '+':
                            result = firstNumber + secondNumber;
                            break;
                        case '-':
                            result = firstNumber - secondNumber;
                            break;
                        case '✕':
                            result = firstNumber * secondNumber;
                            break;
                        case '÷':
                            result = firstNumber / secondNumber;
                            break;
                        default:
                            DisplayMessage("Syntax Error", "Press C button again.");
                            break;
                    }

                    DisplayMessage(result.ToString(), displayValue);
                }
            };

		}

        public void NumberButtonEvent(Object sender, EventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if (displayValue == "0")
                displayValue = ClickedButton.Text;
            else
                displayValue += ClickedButton.Text;

            DisplayLabel.Text = displayValue;
        }

        public void OperationButtonEvent(Object sender, EventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if(displayValue.Substring(displayValue.Length - 1) == "+" || 
               displayValue.Substring(displayValue.Length - 1) == "-" ||
               displayValue.Substring(displayValue.Length - 1) == "÷" ||
               displayValue.Substring(displayValue.Length - 1) == "✕")
            {
                displayValue = displayValue.Remove(displayValue.Length - 1);
                displayValue += ClickedButton.Text;
            }
            else
            {
                firstNumber = double.Parse(displayValue);
                displayValue += ClickedButton.Text;
            }

            operation = Convert.ToChar(ClickedButton.Text);
            DisplayLabel.Text = displayValue;
        }

        private void DisplayMessage(string display, string equation)
        {
            DisplayLabel.Text = display;
            EquationLabel.Text = equation;
        }
    }
}
