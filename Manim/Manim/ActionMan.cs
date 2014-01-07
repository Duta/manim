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
        private Image baseImage;
        public Image BaseImage
        {
            get
            {
                return baseImage;
            }
            set
            {
                baseImage = value;
                update();
            }
        }
        private PictureBox pictureBox;
        private List<Manipulation> manipulations;

        public ActionMan(PictureBox _pictureBox)
        {
            manipulations = new List<Manipulation>();
            pictureBox = _pictureBox;
            BaseImage = pictureBox.Image;
        }

        public void Apply(Manipulation manipulation)
        {
            manipulations.Add(manipulation);
            update();
        }

        public void ReverseLast()
        {
            if (manipulations.Count == 0) return;
            int lastIndex = manipulations.Count - 1;
            var manipulation = manipulations[lastIndex];
            manipulations.RemoveAt(lastIndex);
            update();
        }

        public void ReverseAll()
        {
            manipulations.Clear();
            update();
        }

        private void update()
        {
            // TODO
        }
    }
}
