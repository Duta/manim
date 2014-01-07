using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Manim
{
    public partial class ManimForm : Form
    {
        private ActionMan actionMan;
        private ManipulationHistory manipulations;
        private string filePath;

        public ManimForm()
        {
            InitializeComponent();
            actionMan = new ActionMan(pictureBox);
            manipulations = new ManipulationHistory(actionMan);
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            filePath = openFileDialog.FileName;
            pictureBox.Image = Image.FromFile(filePath);
            manipulations.Clear();
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
            filePath = saveFileDialog.FileName;
            save();
        }

        private void quitMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Check if the file needs saving.
            Close();
        }

        private void undoMenuItem_Click(object sender, EventArgs e)
        {
            manipulations.Undo();
        }

        private void redoMenuItem_Click(object sender, EventArgs e)
        {
            manipulations.Redo();
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Copy the image to the clipboard.
        }

        private void grayscaleMenuItem_Click(object sender, EventArgs e)
        {
            manipulations.Add(Manipulation.Grayscale);
        }

        private void save()
        {
            if (filePath == null) return;
            pictureBox.Image.Save(filePath);
            manipulations.Clear();
        }
    }
}
