using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLiHongTraNgoGia
{
    internal static class Program
    {
        //hello ae 
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DangNhap());
        }
    }

    public class LapHoaDonFormWrapper : Form
    {
        private LapHoaDonForm lapHoaDonForm;

        public LapHoaDonFormWrapper()
        {
            lapHoaDonForm = new LapHoaDonForm();
            Controls.Add(lapHoaDonForm);
            lapHoaDonForm.Dock = DockStyle.Fill;
        }
    }
}