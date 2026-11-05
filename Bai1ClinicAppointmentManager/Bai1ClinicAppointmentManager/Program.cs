using Bai1ClinicAppointmentManager;
using System;
using System.Windows.Forms;

namespace Bai1ClinicAppointmentManager
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}