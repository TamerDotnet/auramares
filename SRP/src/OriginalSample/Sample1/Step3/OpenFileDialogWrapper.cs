using System.Windows.Forms;

namespace Sample1.Step3
{
    public class OpenFileDialogWrapper : IOpenFileDialog
    {
        public string Filter
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public string FileName
        {
            get { throw new System.NotImplementedException(); }
        }

        public DialogResult ShowDialog()
        {
            throw new System.NotImplementedException();
        }
    }
}