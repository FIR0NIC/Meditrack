using System;
using System.Drawing;
using CustomControls;

namespace MediTrack
{
    public static class PlaceholderTextHelper
    {
        public static void SetPlaceholder(CustomTextBox textBox, string placeholder, bool isPasswordField = false)
        {
            if (string.IsNullOrEmpty(textBox.Text) || textBox.Text == placeholder)
            {
                textBox.Text = placeholder;
                textBox.InnerForeColor = Color.Gray;

                // Temporarily disable password masking to show plain text placeholder
                if (isPasswordField)
                {
                    textBox.IsPasswordField = false;
                }
            }
        }

        public static void ClearPlaceholder(CustomTextBox textBox, string placeholder, bool isPasswordField = false)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.InnerForeColor = Color.Black;

                // Re-enable password masking when user starts typing
                if (isPasswordField)
                {
                    textBox.IsPasswordField = true;
                }
            }
        }

        public static void HandlePasswordTextChanged(CustomTextBox textBox, string placeholder)
        {
            // If user is typing real content (not the placeholder)
            if (textBox.Text != placeholder && !string.IsNullOrEmpty(textBox.Text))
            {
                // Ensure password masking is ON for actual passwords
                if (!textBox.IsPasswordField)
                {
                    textBox.IsPasswordField = true;
                }
                // Ensure text color is black (not gray)
                if (textBox.InnerForeColor != Color.Black)
                {
                    textBox.InnerForeColor = Color.Black;
                }
            }
        }

        public static bool IsPlaceholderActive(CustomTextBox textBox, string placeholder)
        {
            return textBox.Text == placeholder;
        }

        public static string GetActualText(CustomTextBox textBox, string placeholder)
        {
            return textBox.Text == placeholder ? string.Empty : textBox.Text;
        }
    }
}