using System;
using System.Collections;
using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters;


namespace kod
{


    public partial class BitMatrix 
    {
        private BitArray data;
        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }
        public bool IsReadOnly => false;

        // tworzy prostokątną macierz bitową wypełnioną `defaultValue`
        public BitMatrix(int numberOfRows, int numberOfColumns, int defaultValue = 0)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            if (numberOfRows < 1 || numberOfColumns < 1)
                throw new ArgumentOutOfRangeException("Incorrect size of matrix");
            data = new BitArray(numberOfRows * numberOfColumns, BitToBool(defaultValue));

        }
        public BitMatrix(int numberOfRows, int numberOfColumns, params int[] bits)
        {


            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            if (numberOfRows < 1 || numberOfColumns < 1)
            {
                NumberOfRows = 0;
                NumberOfColumns = 0;
                data = new BitArray(0);
                return;
            }
            if (bits == null || bits.Length == 0)
            {
                data = new BitArray(numberOfRows * numberOfColumns, false);
            }
            else
            {

                bool[] tab = new bool[numberOfRows * numberOfColumns];

                for (int i = 0; i < Math.Min(bits.Length, numberOfRows * numberOfColumns); i++)
                {

                    if (bits[i] > 0 || bits[i] < 0)
                        tab[i] = true;
                    else
                        tab[i] = false;
                }



                data = new BitArray(tab);
            }
        }
        public BitMatrix(int[,] bits)
        {
            int a = 0;
            NumberOfRows = bits.GetLength(0);
            NumberOfColumns = bits.GetLength(1);
            if (bits == null)
                throw new NullReferenceException();
            if (bits.GetLength(0) < 1 || bits.GetLength(1) < 1)
                throw new ArgumentOutOfRangeException();
            bool[] tab = new bool[bits.GetLength(0) * bits.GetLength(1)];
            for (int i = 0; i < bits.GetLength(0); i++)
            {
                for (int j = 0; j < bits.GetLength(1); j++)
                {

                    if (bits[i, j] == 0)
                        tab[a] = false;
                    else
                        tab[a] = true;
                    a++;

                }


            }
            data = new BitArray(tab);
        }
        public BitMatrix(bool[,] bits)
        {
            NumberOfRows = bits.GetLength(0);
            NumberOfColumns = bits.GetLength(1);
            bool[] tab = new bool[NumberOfColumns * NumberOfRows];
            int a = 0;
            if (bits == null)
                throw new NullReferenceException();
            else if (NumberOfRows < 1 || NumberOfColumns < 1)
                throw new ArgumentOutOfRangeException();
            for (int i = 0; i < bits.GetLength(0); i++)
            {
                for (int j = 0; j < bits.GetLength(1); j++)
                {

                    if (bits[i, j] == false)
                        tab[a] = false;
                    else
                        tab[a] = true;
                    a++;

                }


            }
            data = new BitArray(tab);
        }


        public static int BoolToBit(bool boolValue) => boolValue ? 1 : 0;
        public static bool BitToBool(int bit) => bit != 0;


        public override bool Equals(object obj)
        {
            

            if(obj == null||obj.NumberOfRows!= NumberOfRows) 
                return false;
            else
            {
                if (pom.Length!=NumberOfColumns*NumberOfRows)
                {

                    return false;
                }
                else
                {
                   

                    for (int i = 0; i < data.Length; i++)
                    {
                        if (data[i] != a[i])
                            return false;
                    }
                }
               return true;
                    
                
              
            } 
        }

       
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + NumberOfRows.GetHashCode();
            hash = hash * 23 + NumberOfColumns.GetHashCode();

            for (int i = 0; i < data.Length; i++)
            {
                hash = hash * 23 + data[i].GetHashCode();
            }

            return hash;
        }

        public static bool operator ==(BitMatrix matrix1, BitMatrix matrix2)
        {
            if (ReferenceEquals(matrix1, matrix2))
                return true;

            if ((object)matrix1 == null||(object)matrix2 == null)
            return false;

            return matrix1.Equals(matrix2);
        }

        public static bool operator !=(BitMatrix matrix1, BitMatrix matrix2)
        {
            return !(matrix1 == matrix2);
        }
    
        public override string ToString()
        {
            string wynik = "";
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    wynik += BoolToBit(data[i * NumberOfColumns + j]);

                }
                wynik += "\n";

            }
            return wynik;
        }

        public static void Main(string[] args)
        {
            var m1 = new BitMatrix(2, 3, 1, 1, 1, 1, 1, 1);
            var m2 = new BitMatrix(2, 3, 1, 1, 1, 1, 1, 1);
            string j=m1.ToString();
            Console.WriteLine(j);
            Console.WriteLine(j.Length);
           

        }
    }
}