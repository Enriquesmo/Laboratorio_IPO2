using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Laboratorio_IPO2
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer dtTime;
        /************************************************************************************************/

        /*Inicializacion de la ventana MainWindow*/

        public MainPage()
        {
            this.InitializeComponent();
            dtTime = new DispatcherTimer();

        }
        /************************************************************************************************/

        /*Botones de la propia ventana ListaDeRutas*/

        private void Image_Pocion_De_Vida_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(10); // Esto lo he cambiado para que se vea más fluido, deberia ser 100 milisegundos
            dtTime.Tick += increaseHealth;
            dtTime.Start();
            this.Image_Pocion_De_Vida.Opacity = 0.5;
            
        }
        /************************************************************************************************/

        /*Metodos Auxiliares para todos los botones*/

        private void increaseHealth(object sender, object e)
        {
           this.ProgressBar_Vida.Value += 0.2;
           if (ProgressBar_Vida.Value >= 100)
           {
                this.dtTime.Stop();
                this.Image_Pocion_De_Vida.Opacity = 1;
           }
        }

        private void enfadarPupila(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Ellipse_Ojo_Derecho_Blanco.Resources["animarPupilaDerechaKey"];
            sb.Begin();

        }

        private void Pierna_Derecha_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            {
                DoubleAnimation da = new DoubleAnimation();
                Storyboard sb = new Storyboard();
                sb.Duration = new Duration(TimeSpan.FromMilliseconds(300));
                sb.Children.Add(da);
                sb.BeginTime = TimeSpan.FromSeconds(0);
                Cola.RenderTransform = (Transform)new ScaleTransform();
                Storyboard.SetTarget(da, Cola.RenderTransform);
                Storyboard.SetTargetProperty(da, "ScaleY");
                da.From = 1;
                da.To = 1.5;
                sb.AutoReverse = true;
                sb.RepeatBehavior = new RepeatBehavior(3);
                sb.Begin();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["ManitaDerecha"];
            sb.AutoReverse = true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();

            Storyboard sb2 = (Storyboard)this.Resources["Salto"];
            sb2.AutoReverse = true;
            sb2.RepeatBehavior = RepeatBehavior.Forever;
            sb2.Begin();
            //ManitaDerecha.Begin();
        }
    }
}
