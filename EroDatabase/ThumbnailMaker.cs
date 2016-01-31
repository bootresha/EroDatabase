using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EroDatabase
{
    class ThumbnailMaker
    {
        public static Bitmap makeThumb(Image sourceImg, int thumbTargetWidth, int thumbTargetHeight, Boolean highQuality)
        {
            double ratioWidthHeight = 0;
            ratioWidthHeight = (double)sourceImg.Width / (double)sourceImg.Height;

            //Create thumbnails
            int thumbResizedWidth;
            int thumbResizedHeight;

            if (sourceImg.Width > sourceImg.Height)
            {
                thumbResizedWidth = thumbTargetWidth;
                thumbResizedHeight = (int)(thumbTargetHeight / ratioWidthHeight);
            }
            else
            {
                thumbResizedWidth = (int)(thumbTargetWidth * ratioWidthHeight);
                thumbResizedHeight = thumbTargetHeight;
            }

            int thumbx = (thumbTargetWidth - thumbResizedWidth) / 2;
            int thumby = (thumbTargetHeight - thumbResizedHeight) / 2;

            Bitmap thumbnail = new Bitmap(thumbTargetWidth, thumbTargetHeight);
            Graphics tempgraph = Graphics.FromImage(thumbnail);
            if (highQuality)
            {
                tempgraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                tempgraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                tempgraph.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            }
            tempgraph.DrawImage(sourceImg,
                new Rectangle(thumbx, thumby, thumbResizedWidth, thumbResizedHeight),
                new Rectangle(0, 0, sourceImg.Width, sourceImg.Height),
                GraphicsUnit.Pixel);

            return thumbnail;
        }
    }
}
