using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buscaminas
{
   
    class Program
    {

        static void Main(string[] args)
        {
            inincializarTablero c = new inincializarTablero();
            // c.setmines();

            jugarBuscaminas p = new jugarBuscaminas();
            p.InicializarPartidaTablero();
            p.MostarTablero();
            Console.ReadKey();
        }
    }
   

    class jugarBuscaminas {
       
        Object[,] tableroJuego = new Object[10, 10];
        inincializarTablero game = new inincializarTablero();
        int posX = 0;
        int posY = 0;
        String coordenada;
        public void InicializarPartidaTablero() {

            game.setmines();
            for (int i = 0; i < tableroJuego.GetLength(0); i++)
            {
                for (int j = 0; j < tableroJuego.GetLength(0); j++)
                {
                    tableroJuego[i,j] = "#";

                }
            }
        }
        public void turno() {

            Console.WriteLine("Introduzca coordenada xy");
            coordenada = Console.ReadLine();
            posX = Int32.Parse(coordenada) / 10;
            posY = Int32.Parse(coordenada) % 10;

            if (!isMine()) {
                tableroJuego[posX, posY] = game.Tablero[posX, posY];
                MostarTablero();
            }
        }
        private Boolean isMine() {
            String value = game.Tablero[posX,posY].ToString();
            if (value.Equals("*"))
            {
                Console.WriteLine("GAME OVER"); 
                return true;
            }
            else {
                return false;
            }
            
        }
        public void MostarTablero() {
            for (int i = 0; i < tableroJuego.GetLength(0); i++)
            {
                for (int j = 0; j < tableroJuego.GetLength(0); j++)
                {
                    Console.Write(tableroJuego[i, j]+ " ");
                }
                Console.WriteLine();
            }
            game.show();
            turno();
        }
    }


}
