// Copyright (C) 2025 Ryan Luu
//
// This file is part of Fluent Auto Clicker.
//
// Fluent Auto Clicker is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Fluent Auto Clicker is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with Fluent Auto Clicker. If not, see <https://www.gnu.org/licenses/>.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace FluentAutoClicker;
public sealed partial class HotkeyControl : UserControl
{
    private string? originalHotkey;

    public HotkeyControl()
    {
        InitializeComponent();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        // Save original value in case user cancels
        originalHotkey = HotkeyTextBox.Text;

        // Enable the textbox for input
        HotkeyTextBox.IsEnabled = true;
        HotkeyTextBox.Focus(FocusState.Programmatic);

        // Update button visibility
        EditButton.Visibility = Visibility.Collapsed;
        CancelButton.Visibility = Visibility.Visible;
        AcceptButton.Visibility = Visibility.Visible;
    }

    private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        // Show the pressed key in the textbox
        HotkeyTextBox.Text = e.Key.ToString();
        e.Handled = true; // Prevent default handling
    }

    private void AcceptButton_Click(object sender, RoutedEventArgs e)
    {
        // Save the new hotkey (the textbox already has the value)

        // Reset control state
        RestoreControlState();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        // Restore original hotkey
        HotkeyTextBox.Text = originalHotkey;

        // Reset control state
        RestoreControlState();
    }

    private void RestoreControlState()
    {
        // Disable textbox
        HotkeyTextBox.IsEnabled = false;
        HotkeyTextBox.IsReadOnly = true;

        // Reset button visibility
        EditButton.Visibility = Visibility.Visible;
        CancelButton.Visibility = Visibility.Collapsed;
        AcceptButton.Visibility = Visibility.Collapsed;
    }
}
