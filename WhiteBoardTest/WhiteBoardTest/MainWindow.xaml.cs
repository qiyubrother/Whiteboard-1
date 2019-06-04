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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Point StartPoint = new Point();
        string ShapeSelcted="0";
        double DefalutSize = 5;
        Color DefalutColor = Colors.Black;
        System.Windows.Shapes.Path TempPath = new System.Windows.Shapes.Path();
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void BoardWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //默认颜色粗细
            DrawingAttributes drwAttr = new DrawingAttributes();
            drwAttr.Color = DefalutColor;
            drwAttr.Height = DefalutSize;
            drwAttr.Width = DefalutSize;
            drwAttr.StylusTip = StylusTip.Ellipse;
            inkContent.DefaultDrawingAttributes = drwAttr;

            //大背景玻璃效果
            this.Background = Brushes.Transparent;
            ExtendAeroGlass(this);
            ToolBar toolbar = new ToolBar(this);
            toolbar.Show();
        }

        // 将白板公开化
        public InkCanvas WhiteBoardConvas
        {
            get
            {
                return inkContent;
            }
            set
            {
                inkContent = value;
            }
        }

        //方形绘制
        private void PathCreateRectangle(Point startpoint, Point endpoint)
        {
            var pg = new RectangleGeometry();
            TempPath.Fill = Brushes.Transparent;
            TempPath.Stroke = new SolidColorBrush(DefalutColor);
            TempPath.StrokeThickness = DefalutSize;
            pg.Rect = new Rect(startpoint.X, startpoint.Y, Math.Abs(endpoint.X - startpoint.X), Math.Abs(endpoint.Y - startpoint.Y));
            TempPath.Data = pg;

        }

        //圆形绘制
        private void PathCreateEllipse(Point startpoint,Point endpoint)
        {     
            var pg = new EllipseGeometry();
            TempPath.Fill = Brushes.Transparent;
            TempPath.Stroke = new SolidColorBrush(DefalutColor);
            TempPath.StrokeThickness = DefalutSize;
            if (startpoint.X > endpoint.X && startpoint.Y < endpoint.Y)
            {
                pg.Center = new Point(startpoint.X - Math.Abs(endpoint.X - startpoint.X) / 2, startpoint.Y + Math.Abs(endpoint.Y - startpoint.Y) / 2);
            }
            if (startpoint.X > endpoint.X && startpoint.Y > endpoint.Y)
            {
                pg.Center = new Point(startpoint.X - Math.Abs(endpoint.X - startpoint.X) / 2, startpoint.Y - Math.Abs(endpoint.Y - startpoint.Y) / 2);
            }
            if (startpoint.X < endpoint.X && startpoint.Y > endpoint.Y)
            {
                pg.Center = new Point(startpoint.X + Math.Abs(endpoint.X - startpoint.X) / 2, startpoint.Y - Math.Abs(endpoint.Y - startpoint.Y) / 2);
            }
             if (startpoint.X < endpoint.X && startpoint.Y < endpoint.Y)
            {
                pg.Center = new Point(startpoint.X + Math.Abs(endpoint.X - startpoint.X) / 2, startpoint.Y + Math.Abs(endpoint.Y - startpoint.Y) / 2);
            }
            pg.RadiusX = Math.Abs(endpoint.X - startpoint.X) / 2;
            pg.RadiusY = Math.Abs(endpoint.Y - startpoint.Y)/2;
            TempPath.Data = pg;         
        }

        //线条绘制
        private void PathCreateLine(Point startpoint, Point endpoint)
        {
            TempPath.Fill = Brushes.Transparent;
            TempPath.Stroke = new SolidColorBrush(DefalutColor);
            TempPath.StrokeThickness = DefalutSize;
            var pg = new LineGeometry();
            pg.StartPoint = startpoint;
            pg.EndPoint = endpoint;
            TempPath.Data = pg;
        }

        //三角形绘制

        private System.Windows.Shapes.Path PathCreateTriangle(Point startpoint, Point endpoint)
        {
            inkContent.Children.Clear();
            var p = new System.Windows.Shapes.Path();
            p.Fill = Brushes.Transparent;
            p.Stroke = Brushes.Black;

            var pg = new PathGeometry();

            var pf = new PathFigure();
            pf.IsClosed = true;
            pf.StartPoint = startpoint;
            pg.Figures.Add(pf);
            var line1 = new LineSegment();
            var line2 = new LineSegment();
            line1.Point = endpoint;
            line2.Point = new Point(endpoint.X,endpoint.Y+50);
            pf.Segments.Add(line1);
            pf.Segments.Add(line2);
            p.Data = pg;
            return p;
        }

    

     

       #region 整个窗口透明化 
        private void ExtendAeroGlass(Window window)
        {
            try
            {
                // 为WPF程序获取窗口句柄
                IntPtr mainWindowPtr = new WindowInteropHelper(window).Handle;
                HwndSource mainWindowSrc = HwndSource.FromHwnd(mainWindowPtr);
                mainWindowSrc.CompositionTarget.BackgroundColor = Colors.Transparent;

                // 设置Margins
                MARGINS margins = new MARGINS();

                // 扩展Aero Glass
                margins.cxLeftWidth = -1;
                margins.cxRightWidth = -1;
                margins.cyTopHeight = -1;
                margins.cyBottomHeight = -1;

                int hr = DwmExtendFrameIntoClientArea(mainWindowSrc.Handle, ref margins);
                if (hr < 0)
                {
                    MessageBox.Show("DwmExtendFrameIntoClientArea Failed");
                }
            }
            catch (DllNotFoundException)
            {
                Application.Current.MainWindow.Background = Brushes.White;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
        };

        [DllImport("DwmApi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(
            IntPtr hwnd,
            ref MARGINS pMarInset);
       #endregion

       #region 拖动图片到程序
        private void ImageDrop(object sender, DragEventArgs e)
        {
            object o = e.Data.GetData(DataFormats.FileDrop);
            var files = o as string[];
            if (files != null && files.Length > 0)
            {
                var img = new Image();
                img.Source = new BitmapImage(new Uri(files[0], UriKind.Absolute));
                inkContent.Children.Add(img);
            }

        }

        private void ImageDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Move;
            else
                e.Effects = DragDropEffects.None;

        }

        #endregion

        private void image_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            // Set the container (used for coordinates.)
            e.ManipulationContainer = inkContent;

            // Choose what manipulations to allow.
            e.Mode = ManipulationModes.All;
        }

        private void image_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            // Get the image that's being manipulated.            
            FrameworkElement element = (FrameworkElement)e.Source;

            // Use the matrix to manipulate the element.
            Matrix matrix = ((MatrixTransform)element.RenderTransform).Matrix;

            var deltaManipulation = e.DeltaManipulation;
            // Find the old center, and apply the old manipulations.
            Point center = new Point(element.ActualWidth / 2, element.ActualHeight / 2);
            center = matrix.Transform(center);

            // Apply zoom manipulations.
            matrix.ScaleAt(deltaManipulation.Scale.X, deltaManipulation.Scale.Y, center.X, center.Y);

            // Apply rotation manipulations.
            matrix.RotateAt(e.DeltaManipulation.Rotation, center.X, center.Y);

            // Apply panning.
            matrix.Translate(e.DeltaManipulation.Translation.X, e.DeltaManipulation.Translation.Y);

            // Set the final matrix.
            ((MatrixTransform)element.RenderTransform).Matrix = matrix;

        }
    
       

        #region 事件处理
        //关闭白板
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("确定要关闭手写板？", "", MessageBoxButton.OKCancel);
            switch (result)
            {
                case MessageBoxResult.OK:
                    BoardWindow.Close();
                    break;
                case MessageBoxResult.Cancel:
                    // ...
                    break;
            }



        }

      

        //清除所有
        private void ClearOnec_Click(object sender, RoutedEventArgs e)
        {
         
            inkContent.Strokes.Clear();
            inkContent.Children.Clear();
        
        }


       
        //撤销上一笔
        private void CancelOnec_Click(object sender, RoutedEventArgs e)
        {

            StrokeCollection s = inkContent.Strokes;
            if (s.Count>0)
            s.Remove(s[s.Count-1]);
        }

        //颜色选取
        private void Color_2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            DrawingAttributes inkDA = new DrawingAttributes();
            inkDA.Color = ((SolidColorBrush)btn.Background).Color;
            inkDA.Width = this.inkContent.DefaultDrawingAttributes.Width;
            inkDA.Height = this.inkContent.DefaultDrawingAttributes.Height;
            inkDA.IsHighlighter = this.inkContent.DefaultDrawingAttributes.IsHighlighter;
            this.inkContent.DefaultDrawingAttributes = inkDA;
            DefalutColor = inkDA.Color;
            DefalutSize = inkDA.Width;
        }

        //粗细选取
        private void Size_2_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var obj = btn.Tag as string;
            DrawingAttributes inkDA = new DrawingAttributes();
            inkDA.Color = this.inkContent.DefaultDrawingAttributes.Color;
            inkDA.Width = Convert.ToDouble(obj);
            inkDA.Height = Convert.ToDouble(obj);
            inkDA.IsHighlighter = this.inkContent.DefaultDrawingAttributes.IsHighlighter;
            this.inkContent.DefaultDrawingAttributes = inkDA;
            DefalutColor = inkDA.Color;
            DefalutSize = inkDA.Width;
        }

       /*最大化和还原
        private void MaxWindow_Click(object sender, RoutedEventArgs e)
        {
            if (MaxWindow.Content.ToString() == "最大化")
            {
                MaxWindow.Content = "还原";
                this.BoardWindow.SizeToContent = SizeToContent.Manual;
                this.BoardWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                MaxWindow.Content = "最大化";
                this.BoardWindow.SizeToContent = SizeToContent.WidthAndHeight;
                this.BoardWindow.WindowState = WindowState.Normal;
            }
        }
        */

        //撤销图片和形状
        private void CancelImg_Click(object sender, RoutedEventArgs e)
        {  
            if (inkContent.Children.Count > 0)
            {
                inkContent.Children.Remove(inkContent.Children[inkContent.Children.Count - 1]);
            }
        }

        //翻转180
        int i = 1;
        private void RotateWindow_Click(object sender, RoutedEventArgs e)
        {
            
            RotateTransform rotateTransform = new RotateTransform(180.0 * i, this.ContentPanel.ActualWidth / 2, this.ContentPanel.ActualHeight / 2);
            this.ContentPanel.RenderTransform = rotateTransform;

            //RotateTransform PopUprotateTransform = new RotateTransform(180.0 * i, this.CounterPopUp.ActualWidth / 2, this.CounterPopUp.ActualHeight / 2);
            //this.CounterPopUp.RenderTransform = PopUprotateTransform;
            i++;
        }

        /*显示计算器
        private void CounterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (i % 2 == 0)
            {
                RotateTransform PopUprotateTransform = new RotateTransform(180.0, this.CounterCtr.ActualWidth / 2, this.CounterCtr.ActualHeight / 2);
                this.CounterCtr.RenderTransform = PopUprotateTransform;
               
            }
            else
            {
                RotateTransform PopUprotateTransform = new RotateTransform(0, this.CounterCtr.ActualWidth / 2, this.CounterCtr.ActualHeight / 2);
                this.CounterCtr.RenderTransform = PopUprotateTransform;
              
            }

            CounterPopUp.IsOpen = true;
            CounterPopUp.StaysOpen = false;

          

        }
        */
        /*
        //选中元素拖拉
        private void SelectedBtn_Click(object sender, RoutedEventArgs e)
        {

            if (SelectedBtn.Content.ToString() == "取消选中")
            {
                SelectedBtn.Content = "选中";
                inkContent.EditingMode = InkCanvasEditingMode.Ink;
            }
            else
            {
                SelectedBtn.Content = "取消选中";
                inkContent.EditingMode = InkCanvasEditingMode.Select;
            }
        }
        */

        //窗体可拖动
        private void BoardWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        

        //形状工具
        private void inkContent_StylusDown(object sender, StylusDownEventArgs e)
        {
            StartPoint = e.GetPosition(inkContent);

            System.Windows.Shapes.Path Precttangle = new System.Windows.Shapes.Path();
            TempPath = Precttangle;
            Precttangle.Name = "Rectangle" + StartPoint.X.ToString();
            if (ShapeSelcted == "0")
            {
                inkContent.Children.Add(Precttangle);
            }

            if (ShapeSelcted == "1")
            {
                inkContent.Children.Add(Precttangle);
            }

            if (ShapeSelcted == "2")
                inkContent.Children.Add(Precttangle);

            if (ShapeSelcted == "3")
                inkContent.Children.Add(Precttangle);

        }

        private void inkContent_StylusMove(object sender, StylusEventArgs e)
        {

            inkContent.EditingMode = InkCanvasEditingMode.None;
            Point MovePoint = e.GetPosition(inkContent);

            if (ShapeSelcted == "0")
            {
                PathCreateRectangle(StartPoint, MovePoint);
            }
            if (ShapeSelcted == "1")
            {
                PathCreateEllipse(StartPoint,MovePoint);
            }
            if (ShapeSelcted == "2")
            {
                PathCreateLine(StartPoint, MovePoint);
            }
        }

        private void inkContent_StylusUp(object sender, StylusEventArgs e)
        {
            inkContent.EditingMode = InkCanvasEditingMode.Ink;
            inkContent.StylusDown -= new StylusDownEventHandler(inkContent_StylusDown);
            inkContent.StylusMove -= new StylusEventHandler(inkContent_StylusMove);
            inkContent.StylusUp -= new StylusEventHandler(inkContent_StylusUp);
        }

       
        private void shape_Click(object sender, RoutedEventArgs e)
        {
            inkContent.StylusDown += new StylusDownEventHandler(inkContent_StylusDown);
            inkContent.StylusMove += new StylusEventHandler(inkContent_StylusMove);
            inkContent.StylusUp += new StylusEventHandler(inkContent_StylusUp);
            Button btn = sender as Button;
            var obj = btn.Tag as string;
            if (obj == "0")
            {
                ShapeSelcted = "0";
            }
            if (obj == "1")
            {
                ShapeSelcted = "1";
            }

            if (obj == "2")
            {
                ShapeSelcted = "2";
            }

            if (obj == "3")
            {
                ShapeSelcted = "3";
            }
        }




        //保存成ink并加载
        //private void Window_Initialized(object sender, EventArgs e)
        //{
        //    var f = new System.IO.FileStream("pic.ink", System.IO.FileMode.Open);
        //    if (System.IO.File.Exists("pic.ink")) ink.Strokes = new System.Windows.Ink.StrokeCollection(f);
        //    f.Close();
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //保存于debug目录下
        //    var f = new System.IO.FileStream("pic.ink", System.IO.FileMode.OpenOrCreate);
        //    ink.Strokes.Save(f);
        //    f.Close();
        //}
        #endregion

    }
}
