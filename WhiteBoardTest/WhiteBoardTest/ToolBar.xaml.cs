using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Windows.Ink;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;
using System.Windows.Interop;

namespace WhiteBoardTest
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class ToolBar : Window
    {
        static MainWindow mainWindow = new MainWindow();
        InkCanvas inkContent = mainWindow.WhiteBoardConvas;
        public ToolBar()
        {
            InitializeComponent();
            
        }

           

        # region
        //工具条Button1：保存为图片
        private void SaveDrwsing_Click(object sender, RoutedEventArgs e)
        {

            GetResultImage();

        }
        // 将内容截图成bmp
        private void GetResultImage()
        {

            Rect rect = inkContent.Strokes.GetBounds();
            if (!Double.IsPositiveInfinity(rect.X) && !Double.IsPositiveInfinity(rect.Y))
            {
                Rect r = new Rect() { X = rect.X - 5, Y = rect.Y - 5, Width = rect.Width + 10, Height = rect.Height + 10 };
                RectangleGeometry rg = new RectangleGeometry() { Rect = r };
                // inkContent.Clip = rg;  
                //UpdateLayout();  
                RenderTargetBitmap RT = CopyUIElementToClipboard(inkContent, r);
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = //"Ink Serialized Format (*.isf)|*.isf|" +
                             "Bitmap files (*.bmp)|*.bmp";
                if ((bool)dlg.ShowDialog(this))
                {
                    FileStream file = new FileStream(dlg.FileName,
                                                    FileMode.Create, FileAccess.Write);

                    BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(RT));
                    encoder.Save(file);
                    file.Close();

                    inkContent.Clip = null;
                }

            }
            else
            {
                MessageBox.Show("没有内容！");
            }
        }

        public RenderTargetBitmap CopyUIElementToClipboard(FrameworkElement ui, Rect rect)
        {

            double width = rect.Width;
            double height = rect.Height;
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)width,
                (int)height, 96, 96, PixelFormats.Default);
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(ui);
                dc.DrawRectangle(vb, null, new Rect(new Point(), new Size(width, height)));

            }
            bmp.Render(dv);
            Clipboard.SetImage(bmp);  //剪切板

            return bmp;
        }
        #endregion


        //撤销上一笔
        private void CancelOnec_Click(object sender, RoutedEventArgs e)
        {

            StrokeCollection s = inkContent.Strokes;
            if (s.Count > 0)
                s.Remove(s[s.Count - 1]);
        }

        //窗体可拖动
        private void BoardWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

    }
}