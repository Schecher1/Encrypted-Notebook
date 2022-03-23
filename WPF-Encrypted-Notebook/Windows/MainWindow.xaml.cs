﻿using System;
using System.Collections.Generic;
using System.IO;
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
using WPF_Encrypted_Notebook.Pages;
using LIB_Encrypted_Notebook.Database;

namespace WPF_Encrypted_Notebook
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DatabaseManager db = new DatabaseManager("localhost", "ihopenothinggetdie","root","");

            db.Database.EnsureCreated();

            if (File.Exists("c2s_owl.gnm"))
                pageMirror.Content = new PageServerOneWayLogin();
            else
                pageMirror.Content = new PageServerLogin();
        }
    }
}
