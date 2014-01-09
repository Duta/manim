using System;
using System.Drawing;
using System.Windows.Forms;

namespace Manim
{
    public partial class ManimForm : Form
    {
        private readonly ManipulationHistory _manipulations;
        private string _filePath;

        public ManimForm()
        {
            InitializeComponent();
            var actionMan = new ActionMan(pictureBox);
            _manipulations = new ManipulationHistory(actionMan);
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            _filePath = openFileDialog.FileName;
            pictureBox.Image = Image.FromFile(_filePath);
            _manipulations.Clear();
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
            _filePath = saveFileDialog.FileName;
            Save();
        }

        private void quitMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Check if the file needs saving.
            Close();
        }

        private void undoMenuItem_Click(object sender, EventArgs e)
        {
            _manipulations.Undo();
        }

        private void redoMenuItem_Click(object sender, EventArgs e)
        {
            _manipulations.Redo();
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Copy the image to the clipboard.
        }

        private void grayscaleMenuItem_Click(object sender, EventArgs e)
        {
            _manipulations.Add(Manipulation.Blur);
        }

        private void Save()
        {
            if (_filePath == null) return;
            pictureBox.Image.Save(_filePath);
            _manipulations.Clear();
        }
    }
}
