using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
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
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		private async void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			double borrowAmount = 0;
			int years = 0;
			int months = 0;
			double yearlyRate = 0;
			double monthlyRate;
			double monthlyRepay;

			//checking that inputs are correct data type
			try
			{
				borrowAmount = double.Parse(borrowTextBox.Text);
			}
			catch (Exception)
			{
				var dialogMessage = new MessageDialog("Error! Principle borrow entered must be whole number.");
				await dialogMessage.ShowAsync();
				borrowTextBox.Focus(FocusState.Programmatic);
				return;
			}
			try
			{
				years = int.Parse(yearsTextBox.Text);
			}
			catch (Exception)
			{
				var dialogMessage = new MessageDialog("Error! Years enetered must be whole number.");
				await dialogMessage.ShowAsync();
				yearsTextBox.Focus(FocusState.Programmatic);
				return;
			}
			try
			{
				months = int.Parse(monthsTextBox.Text);
			}
			catch (Exception)
			{
				var dialogMessage = new MessageDialog("Error! Months entered must be whole number");
				await dialogMessage.ShowAsync();
				monthsTextBox.Focus(FocusState.Programmatic);
				return;
			}
			try
			{
				yearlyRate = double.Parse(yearlyRateTextBox.Text);
			}
			catch (Exception)
			{
				var dialogMessage = new MessageDialog("Error! Yearly Interest rate must be a number.");
				await dialogMessage.ShowAsync();
				yearlyRateTextBox.Focus(FocusState.Programmatic);
				return;
			}
			int totalMonths = (years * 12) + months;

			monthlyRate = (yearlyRate / 100 / 12);
			monthlyRateTextBox.Text = monthlyRate.ToString();
			monthlyRepay = borrowAmount * (monthlyRate * Math.Pow(1 + monthlyRate, totalMonths)) / (Math.Pow(1 + monthlyRate, totalMonths) - 1);
			monthlyRepayTextBox.Text = monthlyRepay.ToString("C");
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
