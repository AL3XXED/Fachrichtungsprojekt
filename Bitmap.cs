using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueColorConsole;

namespace Haustier_Tamagotchi
{
    internal class Bitmap
    {
       
        //internal static void MyIMG(string img_name) //hier wird der Name ünergeben zb. Bild.png
        //{
        //    string gdir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        //    //gdir = gdir.Remove(gdir.Length - 10, 10);
        //    gdir += @"\ressource\" + img_name;
        //    int res_x = 192;
        //    int res_y = 108;


        //    Bitmap image = new Bitmap(new Bitmap(gdir), new Size(res_x, res_y));
        //    //Für res_x habe ich ein Feld mit int 240 und bei res_y ein int mit 100. Für die Bilder sollten ebenfalls die DIMENSIONEN 240px x 100px haben

        //    VTConsole.Enable();

        //    for (int y = 0; y <= res_y - 1; y = y + 2)
        //    {
        //        for (int x = 0; x <= res_x - 1; x++)
        //        {
        //            Color color = image.GetPixel(x, y);

        //            VTConsole.Write(((char)'\u2588').ToString(), Color.FromArgb(color.R, color.G, color.B));
        //            //Achtung hier wird die Nuget Bibliothek True Color Console


        //            Console.ForegroundColor = ConsoleColor.White;
        //        }
        //        Console.WriteLine();

        //        VTConsole.Disable();



        //    }
        //}
    }
}
