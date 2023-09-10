using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyCalculator : Page
	{
		public CurrencyCalculator()
		{
			this.InitializeComponent();
		}

		private async void convertButton_Click(object sender, RoutedEventArgs e)
		{
			double amount = 0;
			double total = 0;

			double[] us = new double[] { 0.85189982, 0.72872436, 74.257327 };
			double[] euro = new double[] { 1.1739732, 0.8556672, 87.00755 };
			double[] brit = new double[] { 1.371907, 1.1686692, 101.68635 };
			double[] rup = new double[] { 0.011492628, 0.013492774, 0.0098339397 };

			try
			{
				amount = double.Parse(amountTextBox.Text);
			}
			catch (Exception)
			{
				var dialogMessage = new MessageDialog("Error! Please Enter a number.");
				await dialogMessage.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				return;
			}

			if (fromComboBox.SelectedIndex == toComboBox.SelectedIndex)
			{
				amountFromTextBlock.Text = amount + " =";
				resultsTextBlock.Text = amount.ToString();
				fromToTextBlock.Text = "";
				toFromTextBlock.Text = "";
				return;
			}

			// US Dollars
			if (fromComboBox.SelectedIndex == 0)
			{
				if (toComboBox.SelectedIndex == 1)
				{
					total = amount * us[0];
					amountFromTextBlock.Text = amount + " US Dollars =";
					resultsTextBlock.Text = "€ " + total.ToString() + " Euro";
					fromToTextBlock.Text = "1 US Dollar = €" + us[0].ToString() + " Euro";
					toFromTextBlock.Text = "1 Euro = $" + euro[0].ToString() + " US Dollar";
					return;
				}
				else if (toComboBox.SelectedIndex == 2)
				{
					total = amount * us[1];
					amountFromTextBlock.Text = amount + " US Dollars =";
					resultsTextBlock.Text = "$ " + total.ToString() + " British Pounds";
					fromToTextBlock.Text = "1 US Dollar = £" + us[1].ToString() + " British Pounds";
					toFromTextBlock.Text = "1 British Pound = $" + brit[0].ToString() + " US Dollar";
					return;
				}
				else if (toComboBox.SelectedIndex == 3)
				{
					total = amount * us[2];
					amountFromTextBlock.Text = amount + " US Dollars =";
					resultsTextBlock.Text = "₹ " + total.ToString() + " Indian Rupees";
					fromToTextBlock.Text = "1 US Dollar = ₹" + us[2].ToString() + " Indian Rupees";
					toFromTextBlock.Text = "1 Indian Rupee = $" + rup[0].ToString() + " US Dollar";
					return;
				}
			}
			// Euro
			else if (fromComboBox.SelectedIndex == 1)
			{
				if (toComboBox.SelectedIndex == 0)
				{
					total = amount * euro[0];
					amountFromTextBlock.Text = amount + " Euro =";
					resultsTextBlock.Text = "$ " + total.ToString() + " US Dollars";
					fromToTextBlock.Text = "1 Euro = $" + euro[0].ToString() + " US Dollar";
					toFromTextBlock.Text = "1 US Dollar = €" + us[0].ToString() + " Euro";
					return;
				}
				else if (toComboBox.SelectedIndex == 2)
				{
					total = amount * euro[1];
					amountFromTextBlock.Text = amount + " Euro =";
					resultsTextBlock.Text = "£ " + total.ToString() + " British Pounds";
					fromToTextBlock.Text = "1 Euro = £" + euro[1].ToString() + " British Pound";
					toFromTextBlock.Text = "1 British Pound = €" + brit[1].ToString() + " Euro";
					return;
				}
				else if (toComboBox.SelectedIndex == 3)
				{
					total = amount * euro[2];
					amountFromTextBlock.Text = amount + " Euro =";
					resultsTextBlock.Text = "₹ " + total.ToString() + " Indian Rupees";
					fromToTextBlock.Text = "1 Euro = ₹" + euro[2].ToString() + " Indian Rupee";
					toFromTextBlock.Text = "1 Indian Rupee = €" + rup[1].ToString() + " Euro";
					return;
				}
			}
			// British Pounds
			else if (fromComboBox.SelectedIndex == 2)
			{
				if (toComboBox.SelectedIndex == 0)
				{
					total = amount * brit[0];
					amountFromTextBlock.Text = amount + " British Pounds =";
					resultsTextBlock.Text = "$ " + total.ToString() + " US Dollars";
					fromToTextBlock.Text = "1 British Pound = $" + brit[0].ToString() + " US Dollar";
					toFromTextBlock.Text = "1 US Dollar = £" + us[1].ToString() + " British Pound";
					return;
				}
				else if (toComboBox.SelectedIndex == 1)
				{
					total = amount * brit[1];
					amountFromTextBlock.Text = amount + " British Pounds =";
					resultsTextBlock.Text = "€ " + total.ToString() + " Euros";
					fromToTextBlock.Text = "1 British Pound = €" + brit[1].ToString() + " Euro";
					toFromTextBlock.Text = "1 Euro = £" + euro[1].ToString() + " British Pound";
					return;
				}
				else if (toComboBox.SelectedIndex == 3)
				{
					total = amount * brit[2];
					amountFromTextBlock.Text = amount + " British Pounds =";
					resultsTextBlock.Text = "₹ " + total.ToString() + " Indian Rupees";
					fromToTextBlock.Text = "1 British Pound = ₹" + brit[2].ToString() + " Indian Rupees";
					toFromTextBlock.Text = "1 Indian Rupee = £" + rup[2].ToString() + " British Pound";
					return;
				}
			}
			// Indian Rupee
			else
			{
				if (toComboBox.SelectedIndex == 0)
				{
					total = amount * rup[0];
					amountFromTextBlock.Text = amount + " Indian Rupees =";
					resultsTextBlock.Text = "$ " + total.ToString() + " US Dollars";
					fromToTextBlock.Text = "1 Indian Rupee = $" + rup[0].ToString() + " US Dollar";
					toFromTextBlock.Text = "1 US Dollar = ₹" + us[2].ToString() + " Indian Rupees";
					return;
				}
				else if (toComboBox.SelectedIndex == 1)
				{
					total = amount * rup[1];
					amountFromTextBlock.Text = amount + " Indian Rupees =";
					resultsTextBlock.Text = "€ " + total.ToString() + " Euros";
					fromToTextBlock.Text = "1 Indian Rupee = €" + rup[1].ToString() + " Euro";
					toFromTextBlock.Text = "1 Euro = ₹" + euro[2].ToString() + " Indian Rupees";
					return;
				}
				else if (toComboBox.SelectedIndex == 2)
				{
					total = amount * rup[2];
					amountFromTextBlock.Text = amount + " Indian Rupees =";
					resultsTextBlock.Text = "£ " + total.ToString() + " British Pounds";
					fromToTextBlock.Text = "1 Indian Rupee = £" + rup[2].ToString() + " British Pound";
					toFromTextBlock.Text = "1 British Pound = ₹" + brit[2].ToString() + " Indian Rupees";
					return;
				}
			}
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
