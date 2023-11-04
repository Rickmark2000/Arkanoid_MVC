﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using System.Windows.Threading;

namespace Arkanoid_MVC
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool goLeft;
        bool goRight;
        bool isGameOver;
        private DispatcherTimer timer;
        private double posicionX, posicionY;
        double altoPantalla;
        double anchoPantalla, velocidadX = 2, velocidadY = 2;
        private
            double posX = 0;
        Rectangle s;
        int score;
        Rectangle[] rect = new Rectangle[8];

        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            setupGame();
        }



        private void setupGame()
        {
            score = 0;


            anchoPantalla = SystemParameters.PrimaryScreenWidth;
            altoPantalla = SystemParameters.PrimaryScreenHeight;

            posicionY = Canvas.GetTop(ball);
            posicionX = Canvas.GetLeft(ball);


            CanvasJuego.Width = anchoPantalla;
            CanvasJuego.Height = altoPantalla;

            posicionX = Canvas.GetTop(ball);

            posX = Canvas.GetLeft(plataforma);

            for (int i = 0; i < rect.Length; i++)
            {
                rect[i] = (Rectangle)FindName("bloque" + (i + 1));
                rect[i].Fill = new SolidColorBrush(Colors.Red);

            }


            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(6);
            if (!isGameOver)
            {

                timer.Tick += Timer_Tick;

                timer.Start();
            }
            else
            {
                timer.Stop();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            double limiteIzquierdo = 0, limiteDerecho = 0;
            bool eslimiteDerecho = false, eslimiteIzquierdo = false;
            label.Content = goLeft;
            Canvas.SetTop(ball, this.posicionY += velocidadY);
            Canvas.SetLeft(ball, this.posicionX += velocidadX);
            s = (Rectangle)FindName("plataforma");
            Canvas.SetLeft(s, anchoPantalla / 2 - s.Width / 2);
            limiteIzquierdo = 0;
            limiteDerecho = CanvasJuego.ActualWidth - s.Width;
            Canvas.SetLeft(s, posX);
            double posicionX = Canvas.GetLeft(s);
            double posicionPlataforma = Canvas.GetLeft(s);
            Canvas.GetTop(s);
            txtScore.Content = "Score: " + score;

            if (Canvas.GetTop(ball) + ball.Height >= (Math.Abs(CanvasJuego.Height - ball.Height)))
            {


                isGameOver = true;

            }

            if (Canvas.GetTop(ball) < 0)
            {

                velocidadY *= -1;
            }
            if (Canvas.GetLeft(ball) + ball.Width > CanvasJuego.Width || Canvas.GetLeft(ball) < 0)
            {

                velocidadX *= -1;

            }

            Rect sd = new Rect(Canvas.GetLeft(s), Canvas.GetTop(s), s.Width, s.Height);
            Rect SD2 = new Rect(Canvas.GetLeft(ball), Canvas.GetTop(ball), ball.Width, ball.Height);



            if (sd.IntersectsWith(SD2))
            {
                double ballCenterX = Canvas.GetLeft(ball) + ball.Width / 2;
                double platformCenterX = Canvas.GetLeft(s) + s.Width / 2;
                velocidadY *= -1;


            }

            for (int i = 0; i < rect.Length; i++)
            {
                Rect eas = new Rect();
                if (rect[i] != null)
                {
                    eas = new Rect(Canvas.GetLeft(rect[i]), Canvas.GetTop(rect[i]), rect[i].Width, rect[i].Height);
                }

                if (eas.IntersectsWith(SD2))
                {
                    velocidadY *= -1;
                    CanvasJuego.Children.Remove(rect[i]);
                    score++;
                    rect[i] = null;
                }
            }
            if (Canvas.GetLeft(s) < limiteIzquierdo)
            {
                eslimiteIzquierdo = true;
            }
            else
            {
                eslimiteIzquierdo = false;
            }

            if (Canvas.GetLeft(s) > limiteDerecho)
            {
                eslimiteDerecho = true;
            }
            else
            {
                eslimiteDerecho = false;
            }


            if (goLeft && !eslimiteIzquierdo)
            {

                posX -= 4;
            }
            if (goRight && !eslimiteDerecho)
            {
                posX += 4;
            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isGameOver)
            {
                if (e.Key == Key.Left)
                {
                    goLeft = true;
                }
                else if (e.Key == Key.Right) { goRight = true; }
            }

        }

        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (!isGameOver)
            {

                if (e.Key == Key.Left)
                {
                    goLeft = false;
                }
                else if (e.Key == Key.Right) { goRight = false; }
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CanvasJuego.Width = e.NewSize.Width;
            CanvasJuego.Height = e.NewSize.Height;

        }
    }
}
