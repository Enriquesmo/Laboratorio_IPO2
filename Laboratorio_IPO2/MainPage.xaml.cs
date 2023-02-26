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
            movimientoEstandar();
            ocultarElementosExtras();
        }

        /************************************************************************************************/

        /*Botones de la propia ventana ListaDeRutas*/

        private void Image_Pocion_De_Vida_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (ProgressBar_Vida.Value > 0)
            {
                dtTimeVida = new DispatcherTimer();
                dtTimeVida.Interval = TimeSpan.FromMilliseconds(10); // Esto lo he cambiado para que se vea más fluido, deberia ser 100 milisegundos
                dtTimeVida.Tick += increaseHealth;
                dtTimeVida.Start();
                this.Image_Pocion_De_Vida.Opacity = 0.5;
            }
        }
        private void Image_Pocion_De_Energia_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (ProgressBar_Vida.Value > 0)
            {
                dtTimeEnergia = new DispatcherTimer();
                dtTimeEnergia.Interval = TimeSpan.FromMilliseconds(10); // Esto lo he cambiado para que se vea más fluido, deberia ser 100 milisegundos
                dtTimeEnergia.Tick += increaseEnergy;
                dtTimeEnergia.Start();
                this.Image_Pocion_De_Energia.Opacity = 0.5;
            }
        }
        private void btn_PrimerAtaque_Click(object sender, RoutedEventArgs e)
        {
            restarBarraEnergia(20);
            Storyboard sb = (Storyboard)this.Resources["Ataque1_Arañazo"];
            sb.Begin();
            Ataque1_ImagenArañazo.Visibility = Visibility.Visible;
            movimientoEstandar();

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
        private void btn_SegundoAtaque_Click(object sender, RoutedEventArgs e)
        {
            restarBarraEnergia(10);
            Storyboard sb = (Storyboard)this.Resources["Ataque2_AtaqueArena"];
            sb.Begin();
            movimientoEstandar();
        }
        private void btn_TercerAtaque_Click(object sender, RoutedEventArgs e)
        {
            restarBarraEnergia(25);
            Storyboard sb = (Storyboard)this.Resources["Ataque3_GolpeCabeza"];
            sb.Begin();
            movimientoEstandar();
        }
        private void btn_CuartoAtaque_Click(object sender, RoutedEventArgs e)
        {
            restarBarraEnergia(40);
            Storyboard sb = (Storyboard)this.Resources["Ataque4_Terremoto"];
            sb.Begin();
            movimientoEstandar();
        }
        private void btn_Herir_Click(object sender, RoutedEventArgs e)
        {
            restarBarraVida(25);
            if (this.ProgressBar_Vida.Value <= 50 && this.ProgressBar_Vida.Value > 25)
            {
                Vida50.Visibility = Visibility.Visible;
            } else if (this.ProgressBar_Vida.Value <= 25 && this.ProgressBar_Vida.Value > 0)
            {
                Vida25.Visibility = Visibility.Visible;
            } else if (this.ProgressBar_Vida.Value <= 0)
            {
                animacionVida0();
            }
        }

        /************************************************************************************************/

        /*Metodos Auxiliares para los botones e imagenes*/

        private void movimientoEstandar()
        {
            Storyboard sb = (Storyboard)this.Resources["MovimientoEstandar"];
            sb.Begin();
        }
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
            if (ProgressBar_Energia.Value >= valorARestar)
            {
                this.ProgressBar_Energia.Value -= valorARestar;
                dtTimeEnergia.Stop();
                this.Image_Pocion_De_Energia.Opacity = 1;
            }
        }
        private void restarBarraVida(int valorARestar)
        {
            this.ProgressBar_Vida.Value -= valorARestar;
            dtTimeVida.Stop();
            this.Image_Pocion_De_Vida.Opacity = 1;
        }
        private void animacionVida0()
        {
            Vida0.Visibility = Visibility.Visible;
            Ojo_Derecho.Visibility = Visibility.Collapsed;
            Ojo_Izquierdo.Visibility = Visibility.Collapsed;
            Storyboard sb = (Storyboard)this.Resources["vida0"];
            sb.Begin();
            estadoBotones(false);
        }
        private void ocultarElementosExtras()
        {
            Vida50.Visibility = Visibility.Collapsed;
            Vida25.Visibility = Visibility.Collapsed;
            Vida0.Visibility = Visibility.Collapsed;
            Ataque1_ImagenArañazo.Visibility = Visibility.Collapsed;
        }
        private void estadoBotones(Boolean estado)
        {
            btn_PrimerAtaque.IsEnabled = estado;
            btn_SegundoAtaque.IsEnabled = estado;
            btn_TercerAtaque.IsEnabled = estado;
            btn_CuartoAtaque.IsEnabled = estado;
            btn_Herir.IsEnabled = estado;
        }
    }
}
