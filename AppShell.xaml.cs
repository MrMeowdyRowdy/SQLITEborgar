﻿using SQLiteDemo.Views;

namespace SQLiteDemo;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AddUpdateBorgarDetail), typeof(AddUpdateBorgarDetail));
    }
}
