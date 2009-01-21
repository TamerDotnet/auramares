using System;
using System.Windows.Forms;

namespace Sample1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var presenter = new ProductPresenter();
            Application.Run((Form) presenter.View);
        }
    }
}
