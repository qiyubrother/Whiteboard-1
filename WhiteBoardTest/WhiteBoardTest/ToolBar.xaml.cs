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
        static Window BoardWindow;
        static InkCanvas inkContent;

        public Color DefalutColor { get; private set; }
        public double DefalutSize { get; private set; }

        public ToolBar(MainWindow mainWindow)
        {
            BoardWindow = mainWindow;
            inkContent = mainWindow.WhiteBoardConvas;
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Left = 1000;
            this.Top = 700;
        }
        #region
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

        // 橡皮擦
        private void Rubber_Click(object sender, RoutedEventArgs e)
        {
            if (inkContent.EditingMode == InkCanvasEditingMode.Ink)
            {
                inkContent.EditingMode = InkCanvasEditingMode.EraseByPoint;
            }
            else
            {
                inkContent.EditingMode = InkCanvasEditingMode.Ink;
            }
        }

        // 清除所有
        private void ClearOnec_Click(object sender, RoutedEventArgs e)
        {
            StrokeCollection s = inkContent.Strokes;
            s.Clear();
        }
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }


        //关闭白板
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("确定要关闭手写板？", "", MessageBoxButton.OKCancel);
            switch (result)
            {
                case MessageBoxResult.OK:
                    BoardWindow.Close();
                    ToolBarWindow.Close();
                    break;
                case MessageBoxResult.Cancel:
                    // ...
                    break;
            }



        }

        private void Size_2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var obj = btn.Tag as string;
            DrawingAttributes inkDA = new DrawingAttributes();
            inkDA.Color = inkContent.DefaultDrawingAttributes.Color;
            inkDA.Width = Convert.ToDouble(obj);
            inkDA.Height = Convert.ToDouble(obj);
            inkDA.IsHighlighter = inkContent.DefaultDrawingAttributes.IsHighlighter;
            inkContent.DefaultDrawingAttributes = inkDA;
            DefalutColor = inkDA.Color;
            DefalutSize = inkDA.Width;
        }
        //颜色选取
        private void Color_2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            DrawingAttributes inkDA = new DrawingAttributes();
            inkDA.Color = ((SolidColorBrush)btn.Background).Color;
            inkDA.Width = inkContent.DefaultDrawingAttributes.Width;
            inkDA.Height = inkContent.DefaultDrawingAttributes.Height;
            inkDA.IsHighlighter = inkContent.DefaultDrawingAttributes.IsHighlighter;
            inkContent.DefaultDrawingAttributes = inkDA;
            DefalutColor = inkDA.Color;
            DefalutSize = inkDA.Width;
        }

        private void Sldstyle_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sld = sender as Slider;
            inkContent.Background.Opacity = sld.Value;
            //SolidColorBrush brush = new SolidColorBrush();
            //brush.Opacity = sld.Value;
            //inkContent.Background = brush;
        }
    }
}