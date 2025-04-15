﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TimeKeeper.UIComponents.Dialogs
{
    /// <summary>
    /// Interaction logic for CreateNewProject.xaml
    /// </summary>
    public partial class CreateNewProject : Window
    {
        /// <summary>
        /// Text for the Code text box control.
        /// </summary>
        public string CodeText
        {
            get => CodeTextBox.Text;
            set => CodeTextBox.Text = value;
        }

        /// <summary>
        /// Text for the Name text box control.
        /// </summary>
        public string NameText
        {
            get => NameTextBox.Text;
            set => NameTextBox.Text = value;
        }

        /// <summary>
        /// Text for the WBS text box control.
        /// </summary>
        public string WbsText
        {
            get => WbsTextBox.Text;
            set => WbsTextBox.Text = value;
        }



        public CreateNewProject()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Sets the <see cref="Window.DialogResult"/> property to false.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        /// <summary>
        /// Sets the <see cref="Window.DialogResult"/> property to true.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(Object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
