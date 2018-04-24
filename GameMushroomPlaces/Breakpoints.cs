using System;

namespace GameMushroomPlaces
{
    /// <summary>
    /// The class that works with the breakpoints.
    /// </summary>
    public class Breakpoints
    {
        private int[,] arrayAllKT;
        private int countPairsBreakpoints = 66;
        private int[,] arrayPairsKT;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countPairs">The number of pairs between all points.</param>
        /// <param name="player">Player id.</param>
        /// <returns></returns>
        public int GetArrayLeghtPairsKT(int countPairs, int player)
        {
            arrayPairsKT = new int[countPairs, 4];
            int arithmeticAverageLength = 0;
            int number = 0;
            int lenght = 0;
            int opponent = 0;
            if (player == 1) opponent = 2;
            else if (player == 0) opponent = 0;
            else opponent = 1;

            for (int i = 0; i < (arrayAllKT.Length / 4) - 1; i++)
            {
                if (arrayAllKT[i, 2] != opponent)
                {
                    
                    for (int j = i + 1; j < ( arrayAllKT.Length / 4) ; j++)
                    {
                        lenght = 0;
                        //расстояние между двумя точками
                        lenght += Math.Abs(arrayAllKT[i, 0] - arrayAllKT[j, 0]);
                        lenght += Math.Abs(arrayAllKT[i, 1] - arrayAllKT[j, 1]);
                        arrayPairsKT[number, 0] = i;
                        arrayPairsKT[number, 1] = j; //id из массива arrayAllKT
                        arrayPairsKT[number, 2] = lenght;
                        number++;
                        arithmeticAverageLength += lenght;
                    }
                    
                }
            }
            return arithmeticAverageLength;
        }

        /// <summary>
        /// The function determines the coordinates of all the dead breakpoints.
        /// </summary>
        /// <param name="arrayGamingLocation">Playing field.</param>
        /// <param name="countPairs">The number of pairs between all points.</param>
        /// <returns>The function returns an array with the coordinates of all the dead breakpoints.</returns>
        public int[,] ExistenceDeadBreakpoints(int[,] arrayGamingLocation, int countPairs)
        {
            int arithmetic = 0, countDeadKT = 0;
            int[,] arrayArithLenght = new int[12,3];

            GetArrayAllBreakpoints(arrayGamingLocation);
            int arithmeticAverageLength = GetArrayLeghtPairsKT(countPairs, 0);
            
            
            arithmetic = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(arithmeticAverageLength / countPairsBreakpoints)));
            
            for (int i = 0; i < arrayPairsKT.Length / 4; i++)
            {
                if (arrayPairsKT[i, 3] >= (2* arithmetic))
                {
                    arrayArithLenght[arrayPairsKT[i, 0], 2] += 1;
                    arrayArithLenght[arrayPairsKT[i, 1], 2] += 1;
                    if (arrayArithLenght[arrayPairsKT[i, 0], 2] == 10) countDeadKT++;
                    if (arrayArithLenght[arrayPairsKT[i, 1], 2] == 10) countDeadKT++;
                }
            }

            int[,] arrayDeadKT = new int[countDeadKT, 2];
            if (countDeadKT > 0)
            {
                for (int i = 0; i < arrayArithLenght.Length / 3; i++)
                {
                    if (arrayArithLenght[i, 3] == 10)
                    {
                        arrayDeadKT[i, 0] = arrayAllKT[arrayArithLenght[i, 0], 0];
                        arrayDeadKT[i, 1] = arrayAllKT[arrayArithLenght[i, 0], 1];
                    }
                }
            }
            return arrayDeadKT;
        }

        /// <summary>
        /// The function fills the array of coordinates and types point.
        /// </summary>
        /// <param name="arrayGamingLocation">Playing field.</param>
        public void GetArrayAllBreakpoints(int[,] arrayGamingLocation)
        {
            int _i = 0, _j = 0;
            arrayAllKT = new int[12, 4];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (arrayGamingLocation[i, j] == 1 || arrayGamingLocation[i, j] == 2 || 
                        arrayGamingLocation[i, j] == 3 || arrayGamingLocation[i, j] == 4 ||
                        arrayGamingLocation[i, j] == 5 || arrayGamingLocation[i, j] == 6 ||
                        arrayGamingLocation[i, j] == 7)
                    {
                        arrayAllKT[_i, 0] = i;
                        arrayAllKT[_i, 1] = j;
                        arrayAllKT[_i, 2] = arrayGamingLocation[i, j];
                        _i++;
                    }
                }
            }
        }

        public int[,] GetArrayAllKT()
        {
            return arrayAllKT;
        }

        public int[,] GetArrayPairsKT()
        {
            return arrayPairsKT;
        }
    }
}
