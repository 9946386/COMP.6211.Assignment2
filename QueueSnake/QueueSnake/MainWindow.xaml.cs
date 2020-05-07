using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QueueSnake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Adding a queue of Snake Cells
        Queue<SnakeCell> positionQueue = new Queue<SnakeCell>();

        SnakeCell tempStart = null;
        SnakeCell tempEnd = null;

        #region Move the snake

        // Global variables to make the Snake move

        // The depth between each new cell / speed
        int DEPTH = 11;
        // The time between movement changes
        int DIRECTION_TIME = 12;

        // Counter used for direction change
        long counter = 0;
        // Test for the random direction
        double randomDirection = 0;

        // Random number generator
        Random movePosition = new Random(DateTime.Now.Millisecond);

        #endregion

        #region Change the look of the Snake

        // The opacity value of the SnakeCell in the Queue
        double snakeOpacity = 1.00;
        // The position of the image in the Z order
        int snakeZindex = 1;

        #endregion

        public MainWindow()
        {
            InitializeComponent();

            #region Queue of SnakeCells

            // Adding 40 elements to the SnakeCell Queue 

            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image1 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image2 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image3 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image4 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image5 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image6 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image7 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image8 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image9 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image10 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image11 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image12 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image13 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image14 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image15 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image16 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image17 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image18 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image19 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image20 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image21 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image22 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image23 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image24 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image25 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image26 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image27 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image28 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image29 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image30 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image31 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image32 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image33 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image34 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image35 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image36 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image37 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image38 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image39 });
            positionQueue.Enqueue(new SnakeCell() { Xposition = 100, Yposition = 120, anyImage = Image40 });

            #endregion

            #region Game Loop Timer

            System.Windows.Threading.DispatcherTimer dispatcherTimer =
            new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(10000);
            dispatcherTimer.Start();

            #endregion
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            counter++;

            // Setting the snakeOpacity variable to 0
            snakeOpacity = 0;
            // Setting the snakeZindex variable to 0
            snakeZindex = 0;

            // Processing the SnakeCell Queue
            foreach (SnakeCell location in positionQueue)
            {
                location.anyImage.Margin = new Thickness(location.Xposition, location.Yposition, 0, 0);
                tempEnd = location;

                snakeOpacity += 0.025;
                location.anyImage.Opacity = snakeOpacity;

                snakeZindex++;
                location.anyImage.SetValue(Canvas.ZIndexProperty, snakeZindex);
            }

            tempStart = positionQueue.Dequeue();

            #region Movement and Boundary Collision

            if ((counter % DIRECTION_TIME) == 0)
            {
                randomDirection = movePosition.Next(1, 5);
            }

            if (randomDirection == 1)
            {
                if ((tempEnd.Xposition + DEPTH + tempEnd.anyImage.Width) >= SnakeGrid.Width) 
                { 
                    positionQueue.Enqueue(new SnakeCell() { Xposition = (SnakeGrid.Width - tempEnd.anyImage.Width), Yposition = tempEnd.Yposition, anyImage = tempStart.anyImage }); 
                }
                else
                {
                    positionQueue.Enqueue(new SnakeCell() { Xposition = (tempEnd.Xposition + DEPTH), Yposition = tempEnd.Yposition, anyImage = tempStart.anyImage });
                }
            }
            else if (randomDirection == 2)
            {
                if ((tempEnd.Xposition - DEPTH) <= 0)
                {
                    positionQueue.Enqueue(new SnakeCell() { Xposition = 0, Yposition = tempEnd.Yposition, anyImage = tempStart.anyImage });
                }
                else
                {
                    positionQueue.Enqueue(new SnakeCell() { Xposition = (tempEnd.Xposition - DEPTH), Yposition = tempEnd.Yposition, anyImage = tempStart.anyImage });
                }
            }
            else if (randomDirection == 3)
            {
                if ((tempEnd.Yposition + DEPTH + tempEnd.anyImage.Height) >= SnakeGrid.Height)
                {
                    positionQueue.Enqueue(new SnakeCell()
                    {
                        Xposition = tempEnd.Xposition,
                        Yposition = (SnakeGrid.Height - tempEnd.anyImage.Height),
                        anyImage = tempStart.anyImage
                    });
                }
                else
                {
                    positionQueue.Enqueue(new SnakeCell() { Xposition = tempEnd.Xposition, Yposition = (tempEnd.Yposition + DEPTH), anyImage = tempStart.anyImage });
                }
            }
            else
            {
                if ((tempEnd.Yposition - DEPTH) <= 0)
                {
                    positionQueue.Enqueue(new SnakeCell() { Xposition = tempEnd.Xposition, Yposition = 0, anyImage = tempStart.anyImage });
                }
                else
                {
                    positionQueue.Enqueue(new SnakeCell() { Xposition = tempEnd.Xposition,Yposition = (tempEnd.Yposition - DEPTH), anyImage = tempStart.anyImage
                    });
                }
            }

            #endregion

        }

        private void SnakeWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SnakeGrid.Width = SnakeWindow.Width - 30;
            SnakeGrid.Height = SnakeWindow.Height - 50;
        }

        private void SliderDepth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            DEPTH = (int)e.NewValue;
        }

        private void SliderDirection_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            DIRECTION_TIME = (int)e.NewValue;
        }
    }
}
