using System.Collections.Generic;
using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace audit.Views
{
    public partial class RenderWindow : Window
    {
        public RenderWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
