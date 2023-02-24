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
    /// Página dedicada al primer trabajo del laboratorio de IPO2
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /************************************************************************************************/

        /*Inicializacion de las variables globales*/

        DispatcherTimer dtTimeVida;
        DispatcherTimer dtTimeEnergia;

        /************************************************************************************************/

        /*Inicializacion de la pagina MainPage*/

        public MainPage()
        {
            this.InitializeComponent();
            dtTimeVida = new DispatcherTimer();
            dtTimeEnergia = new DispatcherTimer();

            /*Storyboard sb = (Storyboard)this.Resources["ManitaDerecha"];
            sb.AutoReverse = true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();

            Storyboard sb2 = (Storyboard)this.Resources["Salto"];
            sb2.AutoReverse = true;
            sb2.RepeatBehavior = RepeatBehavior.Forever;
            sb2.Begin();
            */
        }

        /************************************************************************************************/

        /*Botones de la propia ventana ListaDeRutas*/

        private void Image_Pocion_De_Vida_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            dtTimeVida = new DispatcherTimer();
            dtTimeVida.Interval = TimeSpan.FromMilliseconds(10); // Esto lo he cambiado para que se vea más fluido, deberia ser 100 milisegundos
            dtTimeVida.Tick += increaseHealth;
            dtTimeVida.Start();
            this.Image_Pocion_De_Vida.Opacity = 0.5;
        }

        private void Image_Pocion_De_Energia_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            dtTimeEnergia = new DispatcherTimer();
            dtTimeEnergia.Interval = TimeSpan.FromMilliseconds(10); // Esto lo he cambiado para que se vea más fluido, deberia ser 100 milisegundos
            dtTimeEnergia.Tick += increaseEnergy;
            dtTimeEnergia.Start();
            this.Image_Pocion_De_Energia.Opacity = 0.5;
        }

        private void btn_PrimerAtaque_Click(object sender, RoutedEventArgs e)
        {
            restarBarraEnergia(20);
        }

        private void btn_SegundoAtaque_Click(object sender, RoutedEventArgs e)
        {
            restarBarraEnergia(10);
        }

        private void btn_TercerAtaque_Click(object sender, RoutedEventArgs e)
        {
            restarBarraEnergia(25);
        }

        private void btn_CuartoAtaque_Click(object sender, RoutedEventArgs e)
        {
            restarBarraEnergia(40);
        }

        private void btn_Herir_Click(object sender, RoutedEventArgs e)
        {
            restarBarraVida(25);
        }

        /************************************************************************************************/

        /*Metodos Auxiliares para los botones e imagenes*/

        private void increaseHealth(object sender, object e)
        {
           this.ProgressBar_Vida.Value += 0.2;
           if (ProgressBar_Vida.Value >= 100)
           {
                this.dtTimeVida.Stop();
                this.Image_Pocion_De_Vida.Opacity = 1;
           }
        }

        private void increaseEnergy(object sender, object e)
        {
            this.ProgressBar_Energia.Value += 0.2;
            if (ProgressBar_Energia.Value >= 100)
            {
                this.dtTimeEnergia.Stop();
                this.Image_Pocion_De_Energia.Opacity = 1;
            }
        }

        private void restarBarraEnergia(int valorARestar)
        {
            this.ProgressBar_Energia.Value -= valorARestar;
            dtTimeEnergia.Stop();
            this.Image_Pocion_De_Energia.Opacity = 1;
        }

        private void restarBarraVida(int valorARestar)
        {
            this.ProgressBar_Vida.Value -= valorARestar;
            dtTimeVida.Stop();
            this.Image_Pocion_De_Vida.Opacity = 1;
        }
    }
}
