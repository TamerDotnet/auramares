using System.Windows.Forms;

namespace Sample1
{
    public class OpenFileDialogWrapper : IOpenFileDialog
    {
        private readonly OpenFileDialog dialog;

        public OpenFileDialogWrapper()
        {
            dialog = new OpenFileDialog();
        }

        public string Filter
        {
            get { return dialog.Filter; }
            set { dialog.Filter = value; }
        }

        public string FileName
        {
            get { return dialog.FileName; }
        }

        public DialogResult ShowDialog()
        {
            return dialog.ShowDialog();
        }
    }
}