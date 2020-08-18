using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    static class Program
    {
        internal static string constr;
        public static int lanthi;
        public static string StrCon { get; internal set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDangNhap());
            //Application.Run(new Truong.frmNhapKhoa());
        }
    }
}