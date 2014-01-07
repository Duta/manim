using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Manim
{
    public partial class ManimForm : Form
    {
        private ActionMan actionMan;
        private ManipulationHistory actionHistory;

        public ManimForm()
        {
            InitializeComponent();
            actionMan = new ActionMan(pictureBox);
            actionHistory = new ManipulationHistory(actionMan);
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            string filePath = openFileDialog.FileName;
            // TODO: Load the file

            actionHistory.Clear();
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if (!EnsureHasOpenedFile()) return;
            // TODO
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (!EnsureHasOpenedFile()) return;
            saveFileDialog.ShowDialog();
            string filePath = saveFileDialog.FileName;
            // TODO
        }

        private void quitMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
            Close();
        }

        private void undoMenuItem_Click(object sender, EventArgs e)
        {
            if (!EnsureHasOpenedFile()) return;
            actionHistory.Undo();
            // TODO
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            if (!EnsureHasOpenedFile()) return;
            // TODO
        }

        private void grayscaleMenuItem_Click(object sender, EventArgs e)
        {
            if (!EnsureHasOpenedFile()) return;
            saveMenuItem.Enabled = true;
            // TODO
        }

        private bool EnsureHasOpenedFile()
        {
            var hasOpenedAFile = pictureBox.Image != null;
            if (!hasOpenedAFile)
            {
                // TODO: ERROR: must first open a file
            }
            return hasOpenedAFile;
        }
    }
}
