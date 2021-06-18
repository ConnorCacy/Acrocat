using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acrocat
{
    public class Acrofield
    {
        public iTextSharp.text.Rectangle GetPdfRectangle(SizeF pageSize)
        {
            float widthRatio;
            float heightRatio;
            if (PictureSize.Width > pageSize.Width)
            {
                widthRatio = pageSize.Width / PictureSize.Width;
                heightRatio = pageSize.Height / PictureSize.Height;
            }
            else
            {
                widthRatio = PictureSize.Width / pageSize.Width;
                heightRatio = PictureSize.Height / pageSize.Height;
            }
            var rect = new System.util.RectangleJ(widthRatio * FieldRectangle.X,
                heightRatio * FieldRectangle.Y,
                widthRatio * FieldRectangle.Width,
                heightRatio * FieldRectangle.Height);
            rect.Y = pageSize.Height - (rect.Y + rect.Height);
            return new iTextSharp.text.Rectangle(rect);
        }
        [Browsable(false)]
        public int Page { get; set; }
        public Rectangle FieldRectangle { get; set; }
        [Browsable(false)]
        public SizeF PictureSize { get; set; }
        [Browsable(false)]
        public bool IsSelected { get; set; }
        public string FieldName { get; set; }
        public bool Multiline { get; set; }

        public AlignType Align { get; set; }
        public enum AlignType
        {
            Left,
            Center,
            Right
        }
    }
}
