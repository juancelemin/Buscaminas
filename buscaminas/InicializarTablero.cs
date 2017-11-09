using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buscaminas
{
    class inincializarTablero
    {

        public Object[,] tablero = new Object[10, 10];
        public int mina = 10;
        public int minalugarx = 0;
        public int minalugary = 0;
        Random p = new Random();

        public Object[,] Tablero {
            get { return tablero; }
            set { tablero = value; }
        }

        public int Mina
        {
            get { return mina; }
            set { mina = value; }
        }

        private void inicializar()
        {

            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(0); j++)
                {
                    tablero[i, j] = 0;

                }


            }

        }
        public void show()
        {
            Console.WriteLine("   0 1 2 3 4 5 6 7 8 9");
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                Console.Write(" " + i + " ");
                for (int j = 0; j < tablero.GetLength(0); j++)
                {

                    Console.Write(tablero[i, j] + " ");
                }
                Console.WriteLine();

            }

        }
        public void setmines()
        {
            inicializar();
            while (mina != 0)
            {
                minalugarx = p.Next(0, 9);
                minalugary = p.Next(0, 9);

                if (tablero[minalugarx, minalugary].ToString().Equals("*") == false)
                {

                    tablero[minalugarx, minalugary] = "*";
                    mina--;
                }
                else
                {

                }
            }
            mina = 10;
            setnumbers();
           /// show();
        }

        public void setnumbers()
        {
            for (int k = 0; k < tablero.GetLength(0); k++)
            {
                for (int j = 0; j < tablero.GetLength(0); j++)
                {
                    if (tablero[k, j].ToString().Equals("*") == false)
                    {
                        setnumeroIzq(k, j);
                        setnumeroDer(k, j);
                        setnumeroArriba(k, j);
                        setnumeroAbajo(k, j);
                        setnumeroArribaIzq(k, j);
                        setnumeroArribaDer(k, j);
                        setnumeroAbajoIzq(k, j);
                        setnumeroAbajoDer(k, j);
                    }
                }


            }
        }
        private void setnumeroIzq(int i, int j)
        {
            if (j > 0)
            {
                if (tablero[i, j - 1].ToString().Equals("*"))
                {
                    tablero[i, j] = (int)tablero[i, j] + 1;
                }
            }
        }
        private void setnumeroDer(int i, int j)
        {
            if (j + 1 < tablero.GetLength(0))
            {
                if (tablero[i, j + 1].ToString().Equals("*"))
                {
                    tablero[i, j] = (int)tablero[i, j] + 1;
                }
            }
        }
        private void setnumeroArriba(int i, int j)
        {
            if (i > 0)
            {
                if (tablero[i - 1, j].ToString().Equals("*"))
                {
                    tablero[i, j] = (int)tablero[i, j] + 1;
                }
            }
        }
        private void setnumeroAbajo(int i, int j)
        {
            if (i + 1 < tablero.GetLength(0))
            {
                if (tablero[i + 1, j].ToString().Equals("*"))
                {
                    tablero[i, j] = (int)tablero[i, j] + 1;
                }
            }
        }
        private void setnumeroArribaIzq(int i, int j)
        {
            if (i > 0 && j > 0)
            {
                if (tablero[i - 1, j - 1].ToString().Equals("*"))
                {
                    tablero[i, j] = (int)tablero[i, j] + 1;
                }
            }
        }
        private void setnumeroArribaDer(int i, int j)
        {
            if (i > 0 && j + 1 < tablero.GetLength(0))
            {
                if (tablero[i - 1, j + 1].ToString().Equals("*"))
                {
                    tablero[i, j] = (int)tablero[i, j] + 1;
                }
            }
        }
        private void setnumeroAbajoIzq(int i, int j)
        {
            if (i + 1 < tablero.GetLength(0) && j > 0)
            {
                if (tablero[i + 1, j - 1].ToString().Equals("*"))
                {
                    tablero[i, j] = (int)tablero[i, j] + 1;
                }
            }
        }
        private void setnumeroAbajoDer(int i, int j)
        {
            if (i + 1 < tablero.GetLength(0) && j + 1 < tablero.GetLength(0))
            {
                if (tablero[i + 1, j + 1].ToString().Equals("*"))
                {
                    tablero[i, j] = (int)tablero[i, j] + 1;
                }
            }
        }
    }
}
