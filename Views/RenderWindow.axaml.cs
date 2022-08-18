using System.Collections.Generic;
using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using audit.ViewModels;

namespace audit.Views
{
    public partial class RenderWindow : Window
    {
        FormView formView = new();
        public RenderWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            formView.RetrieveControls(this);
        }
    }
}
