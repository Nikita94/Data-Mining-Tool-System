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
using System.Windows.Navigation;
using System.Windows.Shapes;

using dms.view_models;
using Xceed.Wpf.AvalonDock.Layout;
using dms.tools;

namespace dms.gui
{
    /// <summary>
    /// Interaction logic for LearnSolverPage.xaml
    /// </summary>
    public partial class LearnSolverPage : UserControl, IDocumentContent
    {
        public LearnSolverPage(LearnSolverViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            vm.OnClose += OnClose;
        }

        public LayoutDocument ParentDocument { get; set; }
        private void OnClose(object sender, EventArgs e)
        {
            if (ParentDocument != null)
            {
                ParentDocument.Close();
                ParentDocument = null;
            }
        }
    }
}
