using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manim
{
    class ActionMan
    {
        private Image baseImage;
        private PictureBox pictureBox;
        private List<Manipulation> manipulations;

        public ActionMan(PictureBox _pictureBox)
        {
            manipulations = new List<Manipulation>();
            pictureBox = _pictureBox;
            Rebase();
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

        public void Rebase()
        {
            baseImage = pictureBox.Image;
        }

        private void update()
        {
            if (baseImage == null) return;
            Bitmap image = new Bitmap((Image)baseImage.Clone());
            foreach (var manipulation in manipulations)
            {
                switch (manipulation)
                {
                    case Manipulation.Grayscale:
                        image = applyGrayscale(image);
                        break;
                    default:
                        Console.Error.WriteLine("Unknown manipulation: " + manipulation);
                        break;
                }
            }
            pictureBox.Image = image;
        }

        private Bitmap applyGrayscale(Bitmap image)
        {
            /*byte[] inPixels = image.ToByteArray();
            int numPixels = inPixels.Length;
            byte[] outPixels = new byte[numPixels];
            for (int i = 0; i < numPixels; i++)
            {
                outPixels[i] = inPixels[i];
            }
            return outPixels.ToImage();*/
            byte[] pixelBuffer = image.ToByteArray();
            byte[] resultBuffer = new byte[pixelBuffer.Length];
            byte[] middlePixel;


            int imageStride = image.Width * 4;
            int filterOffset = (10 - 1) / 2;
            int calcOffset = 0, filterY = 0, filterX = 0;
            List<int> neighbourPixels = new List<int>();


            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                filterY = -filterOffset; filterX = -filterOffset;
                neighbourPixels.Clear();


                while (filterY <= filterOffset)
                {
                    calcOffset = k + (filterX * 4) +
                    (filterY * imageStride);


                    if (calcOffset > 0 &&
                        calcOffset + 4 < pixelBuffer.Length)
                    {
                        neighbourPixels.Add(BitConverter.ToInt32(
                                            pixelBuffer, calcOffset));
                    }


                    filterX++;


                    if (filterX > filterOffset)
                    { filterX = -filterOffset; filterY++; }
                }


                neighbourPixels.Sort();
                middlePixel = BitConverter.GetBytes(
                              neighbourPixels[filterOffset]);


                resultBuffer[k] = middlePixel[0];
                resultBuffer[k + 1] = middlePixel[1];
                resultBuffer[k + 2] = middlePixel[2];
                resultBuffer[k + 3] = middlePixel[3];
            }


            return resultBuffer.ToBitmap(image.Width, image.Height);
        }
    }
}
