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
        int seleccion;
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
            Console.WriteLine(" 1. Marcar Mina");
            Console.WriteLine(" 2. Introduzca coordenada xy");
            seleccion = Int32.Parse(Console.ReadLine());
            if (seleccion == 1)
            {
                Console.WriteLine(" 1. Introduzca coordenada xy");
                coordenada = Console.ReadLine();
                posX = Int32.Parse(coordenada) / 10;
                posY = Int32.Parse(coordenada) % 10;
                if (isMine())
                {
                    tableroJuego[posX, posY] = "$";                   
                    DidWon();
                }
                else
                {
                    tableroJuego[posX, posY] = "$";
                    MostarTablero();
                }

            }
            else if (seleccion == 2)
            {
                Console.WriteLine(" 2. Introduzca coordenada xy");
                coordenada = Console.ReadLine();
                posX = Int32.Parse(coordenada) / 10;
                posY = Int32.Parse(coordenada) % 10;

                if (!isMine())
                {
                    tableroJuego[posX, posY] = game.Tablero[posX, posY];
                    MostarTablero();
                }
                else {
                    gameOver();
                }
            }
          
        }
        private void gameOver() {
            game.show();
            Console.WriteLine("GAME OVER");
        }
        private Boolean isMine() {
            String value = game.Tablero[posX,posY].ToString();
            if (value.Equals("*"))
            {
                
                return true;
            }
            else {
                return false;
            }
            
        }
        public void DidWon() {
            game.Mina = game.Mina - 1;
            if (game.mina == 0)
            {
                Console.WriteLine("------------");
                Console.WriteLine("\nYOU WON\n");
                Console.WriteLine("------------");
            }
            else {
                MostarTablero();
            }

        }
        public void MostarTablero() {
            Console.WriteLine("   0 1 2 3 4 5 6 7 8 9");
            for (int i = 0; i < tableroJuego.GetLength(0); i++)
            {
                Console.Write(" "+i+ " ");
                for (int j = 0; j < tableroJuego.GetLength(0); j++)
                {
                    Console.Write(tableroJuego[i, j]+ " ");
                }
                Console.WriteLine();
            }
            //game.show();
            turno();
        }
    }


}
