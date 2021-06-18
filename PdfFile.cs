using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acrocat
{
    public class PdfFile : IDisposable
    {
        public string FilePath { get; set; }
        public int PageCount { get; set; }
        public List<Acrofield> Acrofields { get; set; }
        private List<string> TempImageFiles { get; set; }
        private List<SizeF> PdfPageSizes { get; set; }
        public PdfFile(string filePath)
        {
            FilePath = filePath;
            TempImageFiles = Ghostscript.ConvertToJpgs(filePath).ToList();
            var reader = new PdfReader(FilePath);
            PdfPageSizes = new List<SizeF>();
            PageCount = reader.NumberOfPages;
            for (int i = 0; i < PageCount; i++)
            {
                var pageSize = reader.GetPageSize(i+1);
                PdfPageSizes.Add(new SizeF(pageSize.Width, pageSize.Height));
            }
            reader.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="displaySize">Size of the panel or picturebox used</param>
        public void LoadAcroFields(SizeF displaySize)
        {
            var reader = new PdfReader(FilePath);
            var acroFields = reader.AcroFields;
            Acrofields = new List<Acrofield>();
            var fieldNames = acroFields.Fields.Keys;
            foreach (var fieldName in fieldNames)
            {
                var merged = acroFields.Fields[fieldName].GetMerged(0);
                int fieldFlags = 0;
                if (merged.Contains(PdfName.FF))
                {
                    fieldFlags = merged.GetAsNumber(PdfName.FF).IntValue;
                }
                var isMultiline = ((fieldFlags & BaseField.MULTILINE) > 0);
                Acrofield.AlignType align = Acrofield.AlignType.Left;
                if (merged.Keys.Contains(PdfName.Q))
                {
                    var alignFlags = merged.GetAsNumber(PdfName.Q).IntValue;
                    if ((alignFlags & PdfFormField.Q_CENTER) > 0)
                    {
                        align = Acrofield.AlignType.Center;
                    }
                    else if ((alignFlags & PdfFormField.Q_RIGHT) > 0)
                    {
                        align = Acrofield.AlignType.Right;
                    }
                }
                foreach (var f in acroFields.GetFieldPositions(fieldName))
                {
                    var pageSize = GetPageSize(f.page);
                    float heightRatio = displaySize.Height / pageSize.Height;
                    float widthRatio = displaySize.Width / pageSize.Width;
                    RectangleF rect = new RectangleF(
                        f.position.Left * widthRatio,
                        ((pageSize.Height - f.position.Top) * heightRatio),
                        f.position.Width * widthRatio,
                        f.position.Height * heightRatio
                        );
                    Acrofield acrofield = new Acrofield()
                    {
                        Multiline = isMultiline,
                        Align = align,
                        FieldName = fieldName,
                        Page = f.page,
                        PictureSize = displaySize,
                        FieldRectangle = Rectangle.Round(rect)
                    };
                    Acrofields.Add(acrofield);
                }
            }
            reader.Close();
        }

        internal void Save(string fileName)
        {
            var reader = new PdfReader(FilePath);
            var output = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            var stamp = new PdfStamper(reader, output);
            foreach(var oldField in stamp.AcroFields.Fields.Keys.ToList())
            {
                stamp.AcroFields.RemoveField(oldField);
            }
            foreach(var f in Acrofields)
            {
               
               var field = new TextField(stamp.Writer, 
                   f.GetPdfRectangle(GetPageSize(f.Page)),
                   f.FieldName);
                if (f.Multiline)
                {
                    field.Options = TextField.MULTILINE;
                }
                switch (f.Align)
                {
                    case Acrofield.AlignType.Left:
                        field.Alignment = PdfFormField.Q_LEFT;
                        break;
                    case Acrofield.AlignType.Center:
                        field.Alignment = PdfFormField.Q_CENTER;
                        break;
                    case Acrofield.AlignType.Right:
                        field.Alignment = PdfFormField.Q_RIGHT;
                        break;
                }
                stamp.AddAnnotation(field.GetTextField(), 1);
            }
            stamp.Close();
        }

        public SizeF GetPageSize(int page)
        {
            return PdfPageSizes[page - 1];
        }
        public Image GetImage(int page)
        {
            if (TempImageFiles.Count < page || page <= 0) throw new Exception("Invalid Page");
            return Image.FromFile(TempImageFiles[page -1]);
        }
 
        public void Dispose()
        {
            foreach (var file in TempImageFiles)
            {
                try
                {
                    File.Delete(file);
                }
                catch
                {

                }
            }
        }
    }
}
