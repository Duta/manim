using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Manim
{
    class ActionMan
    {
        private Image _baseImage;
        private readonly PictureBox _pictureBox;
        private readonly List<Manipulation> _manipulations;

        public ActionMan(PictureBox pictureBox)
        {
            _manipulations = new List<Manipulation>();
            _pictureBox = pictureBox;
            Rebase();
        }

        public void Apply(Manipulation manipulation)
        {
            _manipulations.Add(manipulation);
            Update();
        }

        public void ReverseLast()
        {
            if (_manipulations.Count == 0) return;
            int lastIndex = _manipulations.Count - 1;
            //var manipulation = _manipulations[lastIndex];
            _manipulations.RemoveAt(lastIndex);
            Update();
        }

        public void ReverseAll()
        {
            _manipulations.Clear();
            Update();
        }

        public void Rebase()
        {
            _baseImage = _pictureBox.Image;
        }

        private void Update()
        {
            if (_baseImage == null) return;
            var image = new Bitmap((Image)_baseImage.Clone());
            foreach (var manipulation in _manipulations)
            {
                switch (manipulation)
                {
                    case Manipulation.Blur:
                        image = ApplyBlur(image);
                        break;
                    default:
                        Console.Error.WriteLine("Unknown manipulation: " + manipulation);
                        break;
                }
            }
            _pictureBox.Image = image;
        }

        private Bitmap ApplyBlur(Bitmap image)
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
            var resultBuffer = new byte[pixelBuffer.Length];


            int imageStride = image.Width * 4;
            const int filterOffset = (10 - 1) / 2;
            var neighbourPixels = new List<int>();


            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                int filterY = -filterOffset;
                int filterX = -filterOffset;
                neighbourPixels.Clear();


                while (filterY <= filterOffset)
                {
                    int calcOffset = k + (filterX * 4) +
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
                byte[] middlePixel = BitConverter.GetBytes(
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
