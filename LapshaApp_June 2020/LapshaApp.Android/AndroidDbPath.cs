﻿using System;
using LapshaApp.Droid;
using System.IO;
using Xamarin.Forms;


[assembly: Dependency(typeof(AndroidDbPath))]
namespace LapshaApp.Droid
{
    public class AndroidDbPath : IPath
    {
        public string GetDatabasePath(string filename)
        {            
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename);
        }
    }
}