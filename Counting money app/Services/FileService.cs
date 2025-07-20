using System.IO;
using System.Windows.Forms;

namespace MoneyCounterApp.Services
{
    public class FileService
    {
        public string OpenFileDialog(string filter)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = filter;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
                return string.Empty;
            }
        }

        public string SaveFileDialog(string filter, string defaultFileName)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = filter;
                saveFileDialog.FileName = defaultFileName;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
                return string.Empty;
            }
        }

        public string ReadTextFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}