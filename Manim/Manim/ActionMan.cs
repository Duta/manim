using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manim
{
    class ActionMan
    {
        public Image baseImage { get; set; }
        private PictureBox pictureBox;
        private List<Manipulation> manipulations;

        public ActionMan(PictureBox _pictureBox)
        {
            pictureBox = _pictureBox;
        }

        public void Reverse(Manipulation manipulation)
        {
            throw new NotImplementedException();
        }

        public void Apply(Manipulation manipulation)
        {
            throw new NotImplementedException();
        }
    }
}
