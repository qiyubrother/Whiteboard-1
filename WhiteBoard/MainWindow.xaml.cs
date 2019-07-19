using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WhiteBoard
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //初始化白板窗口   
        static WhiteConvas convasWindow = new WhiteConvas();
        //暂定最多5个convas
        public static List<InkCanvas> allConvas = new List<InkCanvas>(5);
        //白板数目
        public static int wholePageNum;
        //当前白板的序号
        public static int currentPageNum;
        //当前白板
        static InkCanvas currentConvas = new InkCanvas();
        //白板初始化时的画笔的颜色与大小
        public Color DefalutColor { get; private set; }
        public double DefalutSize { get; private set; }

        private static InkCanvas ink;
        //记录触摸设备ID
        private static List<int> dec = new List<int>();
        //中心点
        static Point centerPoint;
        public MainWindow()
        {
            InitializeComponent();
            convasWindow.Show();
            currentPageNum = 1;
            wholePageNum = 1;

            // 为currentCanvas添加缩放事件
            currentConvas.MouseWheel += new MouseWheelEventHandler(ink_MouseWheel);
            currentConvas.IsManipulationEnabled = true;
            currentConvas.PreviewTouchDown += new EventHandler<TouchEventArgs>(ink_PreviewTouchDown);
            currentConvas.PreviewTouchUp += new EventHandler<TouchEventArgs>(ink_PreviewTouchUp);
            
            allConvas.Add(currentConvas);
            convasWindow.addNewConvas(currentConvas);
        }

        public static void setCurrentCanvas()
        {
            currentConvas = allConvas[currentPageNum - 1];
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
            Rect rect = currentConvas.Strokes.GetBounds();
            if (!Double.IsPositiveInfinity(rect.X) && !Double.IsPositiveInfinity(rect.Y))
            {
                Rect r = new Rect() { X = rect.X - 5, Y = rect.Y - 5, Width = rect.Width + 10, Height = rect.Height + 10 };
                RectangleGeometry rg = new RectangleGeometry() { Rect = r };
                // inkContent.Clip = rg;  
                //UpdateLayout();  
                RenderTargetBitmap RT = CopyUIElementToClipboard(currentConvas, r);
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

                    currentConvas.Clip = null;
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
            if (currentConvas.EditingMode == InkCanvasEditingMode.Ink)
            {
                currentConvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
            }
            else
            {
                currentConvas.EditingMode = InkCanvasEditingMode.Ink;
            }
        }

        // 清除所有
        private void ClearOnec_Click(object sender, RoutedEventArgs e)
        {
            StrokeCollection s = currentConvas.Strokes;
            s.Clear();
        }
        //撤销上一笔
        private void CancelOnec_Click(object sender, RoutedEventArgs e)
        {

            StrokeCollection s = currentConvas.Strokes;
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
                    convasWindow.Close();
                    ToolBarWindow.Close();
                    break;
                case MessageBoxResult.Cancel:
                    // ...
                    break;
            }
        }
        //改变大小
        private void Size_2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var obj = btn.Tag as string;
            DrawingAttributes inkDA = new DrawingAttributes();
            inkDA.Color = currentConvas.DefaultDrawingAttributes.Color;
            inkDA.Width = Convert.ToDouble(obj);
            inkDA.Height = Convert.ToDouble(obj);
            inkDA.IsHighlighter = currentConvas.DefaultDrawingAttributes.IsHighlighter;
            currentConvas.DefaultDrawingAttributes = inkDA;
            DefalutColor = inkDA.Color;
            DefalutSize = inkDA.Width;
        }
        //颜色选取
        private void Color_2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            DrawingAttributes inkDA = new DrawingAttributes();
            inkDA.Color = ((SolidColorBrush)btn.Background).Color;
            inkDA.Width = currentConvas.DefaultDrawingAttributes.Width;
            inkDA.Height = currentConvas.DefaultDrawingAttributes.Height;
            inkDA.IsHighlighter = currentConvas.DefaultDrawingAttributes.IsHighlighter;
            currentConvas.DefaultDrawingAttributes = inkDA;
            DefalutColor = inkDA.Color;
            DefalutSize = inkDA.Width;
        }

        #region 缩放画板

        // 鼠标滚轮缩放
        public static void ink_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            ink = allConvas[currentPageNum-1];
            if (e.Delta < 0)
            {
                foreach (Stroke stroke in ink.Strokes)
                {
                    Matrix matrix = new Matrix();
                    //缩小     小于1为缩小,大于1为放大,此为缩小0.8倍
                    matrix.ScaleAt(0.8, 0.8, Mouse.GetPosition(ink).X, Mouse.GetPosition(ink).Y);
                    //X轴移动  正数为右,负数为左,此为右移1.2倍   斜着移动设置两个值
                    matrix.Translate(1.2, 0);
                    stroke.Transform(matrix, false);
                }
            }
            else
            {
                foreach (Stroke stroke in ink.Strokes)
                {
                    Matrix matrix = new Matrix();
                    //放大     此为放大1.25倍
                    matrix.ScaleAt(1.25, 1.25, Mouse.GetPosition(ink).X, Mouse.GetPosition(ink).Y);
                    //Y轴移动 此为左移1.2倍
                    matrix.Translate(0, 1.2);
                    stroke.Transform(matrix, false);
                }
            }
        }

        //手动缩放
        private static void ink_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ink = allConvas[currentPageNum - 1];
            dec.Add(e.TouchDevice.Id);
            //1个手指或触屏设备的时候，记录中心点
            if (dec.Count == 1)
            {
                TouchPoint touchPoint = e.GetTouchPoint(ink);
                centerPoint = touchPoint.Position;
            }
            //两个及两个以上，将画笔功能关闭
            if (dec.Count > 1)
            {
                if (ink.EditingMode != InkCanvasEditingMode.None)
                {
                    ink.EditingMode = InkCanvasEditingMode.None;
                }
            }
        }
        private static void ink_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            ink = allConvas[currentPageNum - 1];
            //手势完成后切回之前的状态
            if (dec.Count > 1)
            {
                if (ink.EditingMode == InkCanvasEditingMode.None)
                {
                    ink.EditingMode = InkCanvasEditingMode.Ink;
                }
            }
            dec.Remove(e.TouchDevice.Id);
        }

        public static void touchGrid_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            ink = allConvas[currentPageNum - 1];
            e.ManipulationContainer = ink;
            e.Mode = ManipulationModes.All;
        }
        public static void touchGrid_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            ink = allConvas[currentPageNum - 1];
            //小于两指 不触发事件
            if (dec.Count < 2) return;
            //两指缩放
            if (dec.Count == 2)
            {
                foreach (Stroke stroke in ink.Strokes)
                {
                    Matrix matrix = new Matrix();
                    matrix.ScaleAt(e.DeltaManipulation.Scale.X, e.DeltaManipulation.Scale.Y, centerPoint.X, centerPoint.Y);
                    stroke.Transform(matrix, false);
                }
            }
            //三指滑动
            if (dec.Count == 3)
            {
                foreach (Stroke stroke in ink.Strokes)
                {
                    Matrix matrix = new Matrix();
                    matrix.Translate(e.DeltaManipulation.Translation.X, e.DeltaManipulation.Translation.Y);
                    stroke.Transform(matrix, false);
                }
            }
        }
        public static void touchGride_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            ink = allConvas[currentPageNum - 1];
            // TODO 缩放手势结束
        }
        #endregion

        private void AddNewPage(object sender, RoutedEventArgs e)
        {
            InkCanvas newInkConvas = new InkCanvas();
            // 为newInkConvas添加缩放事件
            newInkConvas.IsManipulationEnabled = true;
            newInkConvas.PreviewTouchDown += new EventHandler<TouchEventArgs>(ink_PreviewTouchDown);
            newInkConvas.PreviewTouchUp += new EventHandler<TouchEventArgs>(ink_PreviewTouchUp);
            newInkConvas.MouseWheel += new MouseWheelEventHandler(ink_MouseWheel);

            allConvas.Add(newInkConvas);
            wholePageNum++;
            convasWindow.addNewConvas(newInkConvas);
        }

        
    }
}
