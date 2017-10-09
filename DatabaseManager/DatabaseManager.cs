using System;
using System.Windows.Forms;
using SCADACommon.Service;

namespace DatabaseManager
{
    public static class DatabaseManager
    {
        public static IDatabaseManager Proxy;

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DbForm());
        }
    }
}