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
        private double firstNumber, secondNumber;
        private char operation;
        private bool anOperationClicked = false;

		public MainPage()
		{
			InitializeComponent();

            CButton.Clicked += (sender, e) =>
            {
                displayValue = "0";
                DisplayLabel.Text = displayValue;
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
    }
}
