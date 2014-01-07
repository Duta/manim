using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Manim
{
    public partial class ManimForm : Form
    {
        private ActionMan actionMan;
        private ManipulationHistory manipulations;

        public ManimForm()
        {
            InitializeComponent();
            actionMan = new ActionMan(pictureBox);
            manipulations = new ManipulationHistory(actionMan);
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            string filePath = openFileDialog.FileName;
            // TODO: Load the file

            manipulations.Clear();
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Save the file.

            manipulations.Clear();
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
            string filePath = saveFileDialog.FileName;
            // TODO: Save the file.

            manipulations.Clear();
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
    }
}
