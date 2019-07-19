using System;
using System.Collections.Generic;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WhiteBoard
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class WhiteConvas : Window
    {
        bool isDown = false;
        double down_pX = 0;
        double down_pY = 0;
        bool isMoveSure = false;
        double oldX = 0;

        bool isInMove = false;
        object changeLock = new object();
        Storyboard sboard;

        Storyboard sboardLeftIamge, sboardRightIamge;

        public WhiteConvas()
        {
            InitializeComponent();
            LeftPage.Visibility = System.Windows.Visibility.Hidden;
            RightPage.Visibility = System.Windows.Visibility.Hidden;
            sboardLeftIamge = (Storyboard)this.FindResource("StoryboardLeftImage");
            sboardRightIamge = (Storyboard)this.FindResource("StoryboardRightImage");
        }

        private void BoardWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        //注意，如果不加动画，只是单纯切换画板，应从此开始注释代码
        //添加新画板
        public void addNewConvas(InkCanvas newInkConvas)
        {
            //WrapPanel rectangle = new WrapPanel();
            //rectangle.Width = ActualWidth;
            //rectangle.Height = ActualHeight;
            //rectangle.Children.Add(newInkConvas);
            //设置wrapPanelPages宽度
            ContentPanel.Width = MainConvas.ActualWidth * MainWindow.wholePageNum;
            Viewbox viewbox = new Viewbox();
            viewbox.Stretch = Stretch.Fill;
            viewbox.Width = MainConvas.ActualWidth;
            viewbox.Height = MainConvas.ActualHeight;
            viewbox.Child = newInkConvas;
            ContentPanel.Children.Add(viewbox);
            Canvas.SetLeft(ContentPanel, -MainConvas.ActualWidth * (MainWindow.currentPageNum - 1));
            Console.WriteLine("ContentPanel.Children:"+ContentPanel.Children.Count);
            //改变按钮状态
            pageBar.CreatePageEllipse(MainWindow.wholePageNum);
            pageBar.SelectPage(MainWindow.currentPageNum);
            pageBar.Visibility = System.Windows.Visibility.Visible;
            //改变右翻按钮状态
            if (MainWindow.currentPageNum == 1 && MainWindow.wholePageNum > 1)
            {
                RightPage.Visibility = System.Windows.Visibility.Visible;
            }
            


        }
        #region 手势移动
        private void touchGrid_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            MainWindow.touchGrid_ManipulationStarting(sender, e);
        }
        public void touchGrid_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            MainWindow.touchGrid_ManipulationDelta(sender, e);
        }
        public void touchGride_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            MainWindow.touchGride_ManipulationCompleted(sender, e);
        }
        #endregion

        #region 翻页实现
        /// <summary>
        /// 翻页实现
        /// </summary>
        /// <param name="page"></param>
        /// <param name="needAnimation"></param>
        private void ChangePage(bool isRight)
        {
            Console.WriteLine(MainWindow.currentPageNum);
            double pageWidth = InkCovasBorder.ActualWidth;
            lock (changeLock)
            {
                if (isInMove)
                    return;
                isInMove = true;
            }
            // 向右翻页
            if (isRight)
            {
                if (MainWindow.currentPageNum == MainWindow.wholePageNum)
                {
                    Console.WriteLine("Locked");
                    lock (changeLock)
                    {
                        isInMove = false;
                    }
                    return;
                }
                else
                {
                    // 在移动中
                    isInMove = true;
                    // 目前左边位置
                    double listLeft_now = Canvas.GetLeft(ContentPanel);
                    double listLeft_sur = -(MainWindow.currentPageNum - 1) * pageWidth;
                    double formX = listLeft_now + (MainWindow.currentPageNum - 1) * pageWidth;
                    double toX = -pageWidth;
                    double time = 1000 * Math.Abs(Math.Abs(toX) - Math.Abs(formX)) / pageWidth;
                    Console.WriteLine(listLeft_now + " " + formX + " " + toX);
                    sboardRightBegin(formX, toX, time);
                }
            }
            // 向左翻页
            else
            {
                if (MainWindow.currentPageNum == 1)
                {
                    lock (changeLock)
                    {
                        isInMove = false;
                    }
                    return;
                }
                else
                {
                    isInMove = true;
                    //我怀疑是这个地方出现了问题！
                    double listLeft_now = Canvas.GetLeft(ContentPanel);
                    //我没有用Canvas
                    double listLeft_sur = -(MainWindow.currentPageNum - 1) * pageWidth;
                    //启动左翻动画-翻页
                    double formX = listLeft_now + (MainWindow.currentPageNum - 1) * pageWidth;
                    double toX = pageWidth;
                    double time = 1000 * Math.Abs(Math.Abs(toX) - Math.Abs(formX)) / pageWidth;
                    Console.WriteLine(listLeft_now + " " + formX + " " + toX);
                    sboardLeftBegin(formX, toX, time);
                }
            }
        }
        #endregion

        #region 画板缩放
        private void ink_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            MainWindow.ink_MouseWheel(sender, e);
        }

        #endregion
        #region 改变当前画板页
        private void ChangeCurrentCanvas()
        {
            MainWindow.setCurrentCanvas();
        }

        #endregion

        #region 改变翻页按钮状态
        /// <summary>
        /// 改变翻页按钮状态
        /// </summary>
        private void ChangeButtonStatus()
        {
            Console.WriteLine("Current PageNum:" + MainWindow.currentPageNum + " " + MainWindow.wholePageNum);
            if (MainWindow.wholePageNum == 0)
            {
                return;
            }
            if (MainWindow.currentPageNum == 1 && MainWindow.wholePageNum == 1)
            {
                LeftPage.Visibility = System.Windows.Visibility.Hidden;
                RightPage.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (MainWindow.currentPageNum == 1 && MainWindow.wholePageNum > 1)
            {
                LeftPage.Visibility = System.Windows.Visibility.Hidden;
                RightPage.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                if (MainWindow.currentPageNum == MainWindow.wholePageNum)
                {
                    LeftPage.Visibility = System.Windows.Visibility.Visible;
                    RightPage.Visibility = System.Windows.Visibility.Hidden;
                }
                else
                {
                    LeftPage.Visibility = System.Windows.Visibility.Visible;
                    RightPage.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }
        #endregion

        #region 动画处理

        //左翻动画
        private void sboardLeftBegin(double formX, double toX, double time)
        {
            sboard = ShareClass.CeaterAnimation_Xmove(ContentPanel, formX, toX, time, 0);
            sboard.Completed += sboardLeft_Completed;
            sboard.Begin();
        }

        //右翻动画
        private void sboardRightBegin(double formX, double toX, double time)
        {
            sboard = ShareClass.CeaterAnimation_Xmove(ContentPanel, formX, toX, time, 0);
            sboard.Completed += sboardRight_Completed;
            sboard.Begin();
        }

        //翻页回滚结束
        private void sboardNoChange_Completed(object sender, EventArgs e)
        {
            lock (changeLock)
            {
                isInMove = false;
            }
        }

        //右翻页结束
        private void sboardRight_Completed(object sender, EventArgs e)
        {
            Console.WriteLine("右翻后：" + MainWindow.currentPageNum);
            MainWindow.currentPageNum++;
            pageBar.SelectPage(MainWindow.currentPageNum);
      
            sboard.Stop();

            ChangeButtonStatus();
            ChangeCurrentCanvas();
            Canvas.SetLeft(ContentPanel, -(MainWindow.currentPageNum - 1) * InkCovasBorder.ActualWidth);
            Console.WriteLine("右翻后SetLeft: " + -(MainWindow.currentPageNum - 1) * InkCovasBorder.ActualWidth);
            lock (changeLock)
            {
                isInMove = false;
            }
        }

        //左翻页结束
        private void sboardLeft_Completed(object sender, EventArgs e)
        {
            Console.WriteLine("左翻后：" + MainWindow.currentPageNum);
            MainWindow.currentPageNum--;
            pageBar.SelectPage(MainWindow.currentPageNum);
            sboard.Stop();
            ChangeButtonStatus();
            ChangeCurrentCanvas();
            Canvas.SetLeft(ContentPanel, -(MainWindow.currentPageNum - 1) * InkCovasBorder.ActualWidth);
            lock (changeLock)
            {
                isInMove = false;
            }
        }
        #endregion

        //鼠标移动到翻页按钮时的反应
        private void imageLeft_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            LeftPage.Effect = new DropShadowEffect();
        }

        private void imageLeft_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            LeftPage.Effect = null;
        }

        private void imageRight_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            RightPage.Effect = new DropShadowEffect();
        }

        private void imageRight_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            RightPage.Effect = null;
        }
        //鼠标点按左右侧切换页面按钮时反应
        private void imageLeft_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //翻页
            sboardLeftIamge.Begin();
            ChangePage(false);
        }
        private void imageRight_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //翻页
            sboardRightIamge.Begin();
            ChangePage(true);
        }
        //注释到此结束

    }
}
