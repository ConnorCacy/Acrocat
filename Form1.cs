using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Acrocat
{
    public partial class Form1 : Form
    {
        public string InitFile { get; set; }
        public PdfFile PdfFile { get; set; }
        public int CurrentPage { get; set; }
        public bool InCreateMode { get; private set; }

        public Form1(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0) InitFile = args[0];
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InitFile))
            {
                OpenFile(InitFile);
            }
        }

        private void OpenFile(string fileName)
        {
            PdfFile = new PdfFile(fileName);
            CurrentPage = 1;
            InitScreen();
        }

        private void InitScreen()
        {
            pictureBox1.Image = PdfFile.GetImage(CurrentPage);
            AutoSizePictureBox();
            PdfFile.LoadAcroFields(pictureBox1.Size);
            TogglePageButtons();
        }

        private void AutoSizePictureBox()
        {
            var pageSize = PdfFile.GetPageSize(CurrentPage);
            var trueWidth = pictureBox1.Height * pageSize.Width / pageSize.Height;
            splitContainer1.SplitterDistance = Convert.ToInt32(trueWidth);
        }

        private void OpenPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            OpenFile(openFileDialog1.FileName);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (PdfFile != null) PdfFile.Dispose();
        }



        private void NewFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InCreateMode = true;
            pictureBox1.Cursor = Cursors.Cross;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            PdfFile.Save(saveFileDialog1.FileName);
            Process.Start(saveFileDialog1.FileName);
        }

        private void PrevPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentPage == 1) return;
            CurrentPage--;
            pictureBox1.Image = PdfFile.GetImage(CurrentPage);
            TogglePageButtons();
        }

        private void NextPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentPage == PdfFile.PageCount) return;
            CurrentPage++;
            pictureBox1.Image = PdfFile.GetImage(CurrentPage);
            TogglePageButtons();
        }
        private void TogglePageButtons()
        {
            prevPageToolStripMenuItem.Enabled = CurrentPage != 1;
            nextPageToolStripMenuItem.Enabled = CurrentPage != PdfFile.PageCount; 
        }
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("> Create a pdf using Word and the 'Save-As Pdf' option\n" +
                "> Add fields using the 'Add Field' button\n" +
                "\t~ ShortCutkeys: Delete (delete), Left/Right/Up/Down + Shift\n" +
                "> Save to new pdf names {old name}_new.pdf", "Acrocat How-To");
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush semiTransparent1 = new SolidBrush(Color.FromArgb(128, 0, 0, 255));
            SolidBrush semiTransparent2 = new SolidBrush(Color.FromArgb(128, 0, 255, 255));
            if (PdfFile == null || PdfFile.Acrofields == null) return;
            foreach (var f in PdfFile.Acrofields.Where(f=>f.Page == CurrentPage))
            {
                e.Graphics.FillRectangle(
                    f.IsSelected ? semiTransparent2 : semiTransparent1,
                    f.FieldRectangle);
                var textLoc = f.FieldRectangle.Location;
                textLoc.Y += 2;
                var textLen = Convert.ToInt32(
                    e.Graphics.MeasureString(f.FieldName, SystemFonts.DefaultFont).Width);
                switch (f.Align)
                {
                    case Acrofield.AlignType.Center:
                        textLoc.X += (f.FieldRectangle.Width - textLen) / 2;
                        break;
                    case Acrofield.AlignType.Right:
                        textLoc.X += f.FieldRectangle.Width - textLen;
                        break;
                    default:
                        break;
                }
                e.Graphics.DrawString(f.FieldName, SystemFonts.DefaultFont, Brushes.Black, textLoc);
            }
        }

        private void PropertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            var localPoint = pictureBox1.PointToClient(Cursor.Position);
            if (InCreateMode)
            {
                PdfFile.Acrofields.Add(new Acrofield
                {
                    FieldName = Guid.NewGuid().ToString(),
                    FieldRectangle = new Rectangle(localPoint, new Size(150, 21)),
                    PictureSize = pictureBox1.Size,
                    Page = CurrentPage
                });
            }
            else
            {

                var selected = PdfFile?.Acrofields?.Where(r =>
                r.Page == CurrentPage && r.FieldRectangle.Contains(localPoint)).FirstOrDefault();
                PdfFile?.Acrofields?.ForEach(f => f.IsSelected = f == selected);
                propertyGrid1.SelectedObject = selected;
            }
            pictureBox1.Refresh();
            pictureBox1.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                InCreateMode = false;
                pictureBox1.Cursor = Cursors.Default;
            }
            var selected = PdfFile?.Acrofields?.FirstOrDefault(f => f.IsSelected);
            if (selected != null)
            {
                var rect = selected.FieldRectangle;
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        PdfFile.Acrofields.Remove(selected);
                        break;
                    case Keys.Left:
                        if (e.Shift)
                        {
                            rect.Width-=2;
                        }
                        else
                        {
                            rect.X-=2;
                        }
                        break;
                    case Keys.Right:
                        if (e.Shift)
                        {
                            rect.Width+=2;
                        }
                        else
                        {
                            rect.X+=2;
                        }
                        break;
                    case Keys.Up:
                        if (e.Shift)
                        {
                            rect.Height-=2;
                        }
                        else
                        {
                            rect.Y-=2;
                        }
                        break;
                    case Keys.Down:
                        if (e.Shift)
                        {
                            rect.Height+=2;
                        }
                        else
                        {
                            rect.Y+=2;
                        }
                        break;
                    default:
                        return;
                }
                selected.FieldRectangle = rect;
                pictureBox1.Refresh();
                pictureBox1.Focus();
            }
        }
    }
}
