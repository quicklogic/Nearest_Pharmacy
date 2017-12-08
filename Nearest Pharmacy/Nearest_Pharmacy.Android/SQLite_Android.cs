using System;
using Nearest_Pharmacy.Droid;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace Nearest_Pharmacy.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}