using System.Windows.Forms;

namespace Sample1
{
    public interface IOpenFileDialog
    {
        string Filter { get; set; }
        string FileName { get; }
        DialogResult ShowDialog();
    }
}