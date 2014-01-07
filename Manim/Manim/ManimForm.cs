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
        private ActionHistory actionHistory;
        private ToolStripMenuItem[]
            enableOnOpenFile,
            disableOnOpenFile,
            enableOnSaveFile,
            disableOnSaveFile,
            enableOnSaveAsFile,
            disableOnSaveAsFile,
            enableOnUndo,
            disableOnUndo,
            enableOnFinalUndo,
            disableOnFinalUndo,
            enableOnCopy,
            disableOnCopy,
            enableOnManipulation,
            disableOnManipulation;

        public ManimForm()
        {
            InitializeComponent();
            actionHistory = new ActionHistory();
            enableOnOpenFile = new ToolStripMenuItem[] {
                saveMenuItem,
                saveAsMenuItem,
                copyMenuItem,
                grayscaleMenuItem
            };
            disableOnOpenFile = new ToolStripMenuItem[] { };
            enableOnSaveFile = new ToolStripMenuItem[] { };
            disableOnSaveFile = new ToolStripMenuItem[] {
                saveMenuItem
            };
            enableOnSaveAsFile = new ToolStripMenuItem[] { };
            disableOnSaveAsFile = new ToolStripMenuItem[] {
                saveMenuItem
            };
            enableOnUndo = new ToolStripMenuItem[] { };
            disableOnUndo = new ToolStripMenuItem[] { };
            enableOnFinalUndo = new ToolStripMenuItem[] { };
            disableOnFinalUndo = new ToolStripMenuItem[] {
                undoMenuItem
            };
            enableOnCopy = new ToolStripMenuItem[] { };
            disableOnCopy = new ToolStripMenuItem[] { };
            enableOnManipulation = new ToolStripMenuItem[] { };
            disableOnManipulation = new ToolStripMenuItem[] { };
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            string filePath = openFileDialog.FileName;
            actionHistory.PushAction(new FileAction(filePath, FileAction.ActionType.Open));
            updateEnableds(enableOnOpenFile, disableOnOpenFile);
            // TODO
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if (!EnsureHasOpenedFile()) return;
            if (!actionHistory.HasSavedCurrentFile())
            {
                //
            }
            //actionHistory.PushAction(new FileAction(filePath, FileAction.ActionType.Save));
            updateEnableds(enableOnSaveFile, disableOnSaveFile);
            // TODO
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (!EnsureHasOpenedFile()) return;
            saveFileDialog.ShowDialog();
            string filePath = saveFileDialog.FileName;
            actionHistory.PushAction(new FileAction(filePath, FileAction.ActionType.SaveAs));
            updateEnableds(enableOnSaveAsFile, disableOnSaveAsFile);
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
            ManimAction action = actionHistory.PopAction();
            // TODO
            if (actionHistory.IsEmpty())
            {
                updateEnableds(enableOnFinalUndo, disableOnFinalUndo);
            }
            else
            {
                updateEnableds(enableOnUndo, disableOnUndo);
            }
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            if (!EnsureHasOpenedFile()) return;
            // TODO
            updateEnableds(enableOnCopy, disableOnCopy);
        }

        private void grayscaleMenuItem_Click(object sender, EventArgs e)
        {
            if (!EnsureHasOpenedFile()) return;
            saveMenuItem.Enabled = true;
            updateEnableds(enableOnManipulation, disableOnManipulation);
            // TODO
        }

        private bool EnsureHasOpenedFile()
        {
            var hasOpenedAFile = actionHistory.HasOpenedAFile();
            if (!hasOpenedAFile)
            {
                // TODO: ERROR: must first open a file
            }
            return hasOpenedAFile;
        }

        private void updateEnableds(ToolStripMenuItem[] toEnable, ToolStripMenuItem[] toDisable)
        {
            foreach (var item in toEnable)
            {
                item.Enabled = true;
            }
            foreach (var item in toDisable)
            {
                item.Enabled = false;
            }
        }
    }
}
