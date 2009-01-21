using System.Windows.Forms;

namespace Sample1.Step3
{
    public interface IOpenFileDialog
    {
        string Filter { get; set; }
        string FileName { get; }
        DialogResult ShowDialog();
    }
}