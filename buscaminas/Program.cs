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
       
        Object[,] tableroJuego = new Object[10, 10]; // tablero que se muestra
        inincializarTablero game = new inincializarTablero();// Objecto q tiene el tablero solucion
        int posX = 0;//posicion x
        int posY = 0;//posicion y
        int seleccion;//1 para marcar una mina y 2 para descubrir posicion
        String coordenada;//concatenacionde PoX y poY
        int marcaMina;//numero de minas por marcar
        public void InicializarPartidaTablero() {

            game.setmines();
            marcaMina = game.Mina;
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
                marcaMina--;
                if (isMine())
                {
                    game.Mina = game.Mina - 1;
                    tableroJuego[posX, posY] = "$";                   
                    DidWin();
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
                    if (tableroJuego[posX, posY].ToString().Equals("$"))
                    {
                        marcaMina++;
                        Console.WriteLine("entro " + marcaMina + " " + game.Mina);
                        DidWin();
                    }

                    showZeros(posX, posY);
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
        public void DidWin() {
            

            if (game.Mina == 0 && marcaMina == game.Mina)
            {
                Console.WriteLine("------------");
                Console.WriteLine("\nYOU WON\n");
                Console.WriteLine("------------");
            }
            else {
                MostarTablero();
            }

        }
        public void showZeros(int poX, int poY) {//muestra los ceros( casillas sin minas alrededor)
            if (poX < 0 || poY <0 || poX == game.tablero.GetLength(0) || poY == game.tablero.GetLength(0))
            {
                return;
            }
            else if ((int)game.tablero[poX, poY] == 0 && tableroJuego[poX,poY].ToString().Equals("#"))//diferente a cero y no repetido
            {
                tableroJuego[poX, poY] = game.tablero[poX, poY];
                showZeros(poX - 1, poY);
                showZeros(poX + 1, poY);
                showZeros(poX, poY - 1);
                showZeros(poX, poY + 1);
            }
            else if (!int.TryParse(game.tablero[poX, poY].ToString(), out var n).Equals(n))
            {
                
                tableroJuego[poX, poY] = game.tablero[poX, poY];
                return;
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
