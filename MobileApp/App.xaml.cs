using System;
using MobileApp.Data;
using System.IO;
namespace MobileApp;

public partial class App : Application
{
    static ShoeProductDatabase database;
    public static ShoeProductDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
              ShoeProductDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "ShoeApp.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
