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
using System.Windows.Media.Media3D;
using System.IO;
using HelixToolkit.Wpf;

namespace nem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<GyongyikeNeni> gyongyineniBevasarloListaja;
        int index = 1;
        Point3D elso;
        public MainWindow()
        {
            
            List<string> comboLista = new List<string>() { "gyongyok.txt", "3D-G101-HátulÉrtékesek.txt", "3D-G154-P850-Sarkok.txt", "3D-G200-P865-ÉlSűrű.txt" };
            InitializeComponent();


            combo.ItemsSource = comboLista;
            combo.SelectedIndex = comboLista.Count-1;
            ter.MouseDown += Ter_MouseDown;
            Rajzol();
            broforece();


        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rajzol();   
        }
        private void Rajzol()
        {
            
            gyongyineniBevasarloListaja = File.ReadAllLines($"{combo.SelectedItem}").Skip(1).Select(x => new GyongyikeNeni(x)).ToList();
            ter.Children.Clear();

            foreach (var listaelem in gyongyineniBevasarloListaja)
            {
                EllipsoidVisual3D gyongyineni3Dben = new EllipsoidVisual3D();
                gyongyineni3Dben.RadiusX = listaelem.E;
                gyongyineni3Dben.RadiusY = listaelem.E;
                gyongyineni3Dben.RadiusZ = listaelem.E;
                gyongyineni3Dben.Center = new Point3D(listaelem.X * 5, listaelem.Y * 5, listaelem.Z * 5);
                gyongyineni3Dben.Fill = new SolidColorBrush(Colors.LimeGreen);


                ter.Children.Add(gyongyineni3Dben);

            }
        }

        private void Ter_MouseDown(object sender, MouseEventArgs e)
        {
            //Point mousePosition = e.GetPosition(ter);
            //HitTestResult hitTestResult = VisualTreeHelper.HitTest(ter, mousePosition);
            //if (hitTestResult != null && hitTestResult.VisualHit is EllipsoidVisual3D)
            //{
            //    EllipsoidVisual3D clickedBolygo = (EllipsoidVisual3D)hitTestResult.VisualHit;

            //    // ACTION
            //    elso = clickedBolygo.Center;


                Point mousePosition = e.GetPosition(ter);
                HitTestResult hitTestResult = VisualTreeHelper.HitTest(ter, mousePosition);
                if (hitTestResult != null && hitTestResult.VisualHit is EllipsoidVisual3D)
                {
                    EllipsoidVisual3D clickedBolygo = (EllipsoidVisual3D)hitTestResult.VisualHit;

                    // ACTION

                    if (index == 1)
                    {
                        elso = clickedBolygo.Center;
                        index++;
                    }
                    else if (index == 2)
                    {
                        var line = new LinesVisual3D
                        {
                            Points = new Point3DCollection { clickedBolygo.Center, elso },
                            Thickness = 3,
                            Color = Colors.Blue
                        };
                        ter.Children.Add(line);
                        elso = clickedBolygo.Center;
                    }


                }
            //}
        }

        private void broforece()
        {
            List<GyongyikeNeni> gyongyineniBevasarloListaja2 = gyongyineniBevasarloListaja;
            double d = 0;
            double legjobb = 0;
            GyongyikeNeni bolygo;
            foreach (GyongyikeNeni item in gyongyineniBevasarloListaja)
            {
                double dx = item.X - elso.X;
                double dy = item.Y - elso.Y;
                double dz = item.Z - elso.Z;
                d = Math.Sqrt(dx * dx + dy * dy + dz * dz);
                //elso.X = item.X; elso.Y = item.Y; elso.Z = item.Z;
                //MessageBox.Show(d.ToString());
            }



        }

    }
}


