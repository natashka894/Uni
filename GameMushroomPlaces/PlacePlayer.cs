using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMushroomPlaces
{
    public class PlacePlayer
    {
        public int[] masGdeIgrok = new int[3];
        public int[] masigrokKuda = new int[2];
        //private int countKt = 10;

        public int[] stepPlayers(int i, int j, int igroki12, int[] masGdeIgrok)
        {
            Random rand = new Random();
            if (masGdeIgrok[0] == i)
            {
                if (masGdeIgrok[1] < j)
                {
                    masigrokKuda[0] = masGdeIgrok[0];
                    masigrokKuda[1] = masGdeIgrok[1] + 1;
                }
                else
                {
                    masigrokKuda[0] = masGdeIgrok[0];
                    masigrokKuda[1] = masGdeIgrok[1] - 1;
                }
            }
            if (masGdeIgrok[1] == j)
            {
                if (masGdeIgrok[0] < i)
                {
                    masigrokKuda[0] = masGdeIgrok[0] + 1;
                    masigrokKuda[1] = masGdeIgrok[1];
                }
                else
                {
                    masigrokKuda[0] = masGdeIgrok[0] - 1;
                    masigrokKuda[1] = masGdeIgrok[1];
                }
            }
            if ((masGdeIgrok[1] != j && masGdeIgrok[0] != i))
            {
                if (rand.Next(0, 2) == 0)
                {
                    if (masGdeIgrok[1] < j)
                    {
                        masigrokKuda[0] = masGdeIgrok[0];
                        masigrokKuda[1] = masGdeIgrok[1] + 1;
                    }
                    else
                    {
                        masigrokKuda[0] = masGdeIgrok[0];
                        masigrokKuda[1] = masGdeIgrok[1] - 1;
                    }
                }
                else
                {
                    if (masGdeIgrok[0] < i)
                    {
                        masigrokKuda[0] = masGdeIgrok[0] + 1;
                        masigrokKuda[1] = masGdeIgrok[1];
                    }
                    else
                    {
                        masigrokKuda[0] = masGdeIgrok[0] - 1;
                        masigrokKuda[1] = masGdeIgrok[1];
                    }
                }
            }
            return masigrokKuda;
        }

        //определяет где игрок стоит и какое число, 1 , ...
        public int[] GdeIgrok(int g, int[,] masGamingLocationPlay)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (masGamingLocationPlay[i, j] == g)
                    {
                        masGdeIgrok[0] = i;
                        masGdeIgrok[1] = j;
                        masGdeIgrok[2] = g;
                        return masGdeIgrok;
                    }
                    if (masGamingLocationPlay[i, j] == (g + 5))
                    {
                        masGdeIgrok[0] = i;
                        masGdeIgrok[1] = j;
                        masGdeIgrok[2] = g + 5;
                        return masGdeIgrok;
                    }
                }
            }
            return masGdeIgrok;
        }

        public List<int[,]> igrokKyda(int i, int j, int igrok12, int[,] masGamingLocationPlay, int countKTblue, int countKTred,
            int ran, int compComp, bool flagKT, int countKT)
        {
            List<int[,]> returnElementsFromWhereAPlayer = new List<int[,]>();
            int[,] countKTBlueAndRed = new int[1, 2];
            int[,] countKTNew = new int[1, 1];
            //0 - пустые клетки
            //1 - 1 игрок
            //2 - 2 игрок
            //3 - КТ чистая
            //4 - КТ занятая 1
            //5 - КТ занятая 2
            //6 - на КТ стоит плохой
            //7 - на КТ стоит хороший
            if (masGamingLocationPlay[i, j] == 1 || masGamingLocationPlay[i, j] == 2 ||
                masGamingLocationPlay[i, j] == 6 || masGamingLocationPlay[i, j] == 7)
            {
                if (compComp == 1 || ran == 0)
                {
                    ran = 0;
                    int ii = i - masGdeIgrok[0];
                    if (ii == -1)//игрок пришел снизу
                    {
                        if (ran == 0) //идем влево
                        {
                            ii = masGdeIgrok[1] - 1;
                            if (ii == -1 || ii == 10) ran++;
                            else
                            {
                                compComp = 0;
                                returnElementsFromWhereAPlayer = igrokKyda(masGdeIgrok[0], masGdeIgrok[1] - 1, igrok12, masGamingLocationPlay, countKTblue, countKTred,
                                    ran, compComp, flagKT, countKT);
                                countKTBlueAndRed = returnElementsFromWhereAPlayer[0];
                                masGamingLocationPlay = returnElementsFromWhereAPlayer[1];
                                countKTblue = countKTBlueAndRed[0, 0];
                                countKTred = countKTBlueAndRed[0, 1];
                                ran = -1;
                            }
                        }
                        if (ran == 1) //идем вправо
                        {
                            ii = masGdeIgrok[1] + 1;
                            if (ii == -1 || ii == 10) ran++;
                            else
                            {
                                compComp = 0;
                                returnElementsFromWhereAPlayer = igrokKyda(masGdeIgrok[0], masGdeIgrok[1] + 1, igrok12, masGamingLocationPlay, countKTblue, countKTred,
                                    ran, compComp, flagKT, countKT);
                                countKTBlueAndRed = returnElementsFromWhereAPlayer[0];
                                masGamingLocationPlay = returnElementsFromWhereAPlayer[1];
                                countKTblue = countKTBlueAndRed[0, 0];
                                countKTred = countKTBlueAndRed[0, 1];
                                ran = -1;
                            }
                        }
                        if (ran == 2) //идем вниз
                        {
                            ii = masGdeIgrok[0] + 1;
                            if (ii == -1 || ii == 10) ran++;
                            else
                            {
                                compComp = 0;
                                returnElementsFromWhereAPlayer = igrokKyda(masGdeIgrok[0] + 1, masGdeIgrok[1], igrok12, masGamingLocationPlay, countKTblue, countKTred,
                                    ran, compComp, flagKT, countKT);
                                countKTBlueAndRed = returnElementsFromWhereAPlayer[0];
                                masGamingLocationPlay = returnElementsFromWhereAPlayer[1];
                                countKTblue = countKTBlueAndRed[0, 0];
                                countKTred = countKTBlueAndRed[0, 1];
                                ran = -1;
                            }
                        }
                    }
                    ii = i - masGdeIgrok[0];
                    if (ii == 1)//игрок пришел сверху
                    {
                        if (ran == 0) //идем влево
                        {
                            ii = masGdeIgrok[1] - 1;
                            if (ii == -1 || ii == 10) ran++;
                            else
                            {
                                compComp = 0;
                                returnElementsFromWhereAPlayer = igrokKyda(masGdeIgrok[0], masGdeIgrok[1] - 1, igrok12, masGamingLocationPlay, countKTblue, countKTred,
                                    ran, compComp, flagKT, countKT);
                                countKTBlueAndRed = returnElementsFromWhereAPlayer[0];
                                masGamingLocationPlay = returnElementsFromWhereAPlayer[1];
                                countKTblue = countKTBlueAndRed[0, 0];
                                countKTred = countKTBlueAndRed[0, 1];
                                ran = -1;
                            }
                        }
                        if (ran == 1) //идем впрво
                        {
                            ii = masGdeIgrok[1] + 1;
                            if (ii == -1 || ii == 10) ran++;
                            else
                            {
                                compComp = 0;
                                returnElementsFromWhereAPlayer = igrokKyda(masGdeIgrok[0], masGdeIgrok[1] + 1, igrok12, masGamingLocationPlay, countKTblue, countKTred,
                                    ran, compComp, flagKT, countKT);
                                countKTBlueAndRed = returnElementsFromWhereAPlayer[0];
                                masGamingLocationPlay = returnElementsFromWhereAPlayer[1];
                                countKTblue = countKTBlueAndRed[0, 0];
                                countKTred = countKTBlueAndRed[0, 1];
                                ran = -1;
                            }
                        }
                        if (ran == 2) //идем вверх
                        {
                            ii = masGdeIgrok[0] - 1;
                            if (ii == -1 || ii == 10) ran++;
                            else
                            {
                                compComp = 0;
                                returnElementsFromWhereAPlayer = igrokKyda(masGdeIgrok[0] - 1, masGdeIgrok[1], igrok12, masGamingLocationPlay, countKTblue, countKTred,
                                    ran, compComp, flagKT, countKT);
                                countKTBlueAndRed = returnElementsFromWhereAPlayer[0];
                                masGamingLocationPlay = returnElementsFromWhereAPlayer[1];
                                countKTblue = countKTBlueAndRed[0, 0];
                                countKTred = countKTBlueAndRed[0, 1];
                                ran = -1;
                            }
                        }
                    }
                    if (j - masGdeIgrok[1] == -1)//игрок пришел справа
                    {
                        if (ran == 0) //идем вверх
                        {
                            ii = masGdeIgrok[0] - 1;
                            if (ii == -1 || ii == 10) ran++;
                            else
                            {
                                compComp = 0;
                                returnElementsFromWhereAPlayer = igrokKyda(masGdeIgrok[0] - 1, masGdeIgrok[1], igrok12, masGamingLocationPlay, countKTblue, countKTred,
                                    ran, compComp, flagKT, countKT);
                                countKTBlueAndRed = returnElementsFromWhereAPlayer[0];
                                masGamingLocationPlay = returnElementsFromWhereAPlayer[1];
                                countKTblue = countKTBlueAndRed[0, 0];
                                countKTred = countKTBlueAndRed[0, 1];
                                ran = -1;
                            }
                        }
                        if (ran == 1) //идем вниз
                        {
                            ii = masGdeIgrok[0] + 1;
                            if (ii == -1 || ii == 10) ran++;
                            else
                            {
                                compComp = 0;
                                returnElementsFromWhereAPlayer = igrokKyda(masGdeIgrok[0] + 1, masGdeIgrok[1], igrok12, masGamingLocationPlay, countKTblue, countKTred,
                                    ran, compComp, flagKT, countKT);
                                countKTBlueAndRed = returnElementsFromWhereAPlayer[0];
                                masGamingLocationPlay = returnElementsFromWhereAPlayer[1];
                                countKTblue = countKTBlueAndRed[0, 0];
                                countKTred = countKTBlueAndRed[0, 1];
                                ran = -1;
                            }
                        }
                        if (ran == 2) //идем вправо
                        {
                            ii = masGdeIgrok[1] + 1;
                            if (ii == -1 || ii == 10) ran++;
                            else
                            {
                                compComp = 0;
                                returnElementsFromWhereAPlayer = igrokKyda(masGdeIgrok[0], masGdeIgrok[1] + 1, igrok12, masGamingLocationPlay, countKTblue, countKTred,
                                    ran, compComp, flagKT, countKT);
                                countKTBlueAndRed = returnElementsFromWhereAPlayer[0];
                                masGamingLocationPlay = returnElementsFromWhereAPlayer[1];
                                countKTblue = countKTBlueAndRed[0, 0];
                                countKTred = countKTBlueAndRed[0, 1];
                                ran = -1;
                            }
                        }
                    }
                    if (j - masGdeIgrok[1] == 1)//игрок пришел слева
                    {
                        if (ran == 0) //идем вверх
                        {
                            ii = masGdeIgrok[0] - 1;
                            if (ii == -1 || ii == 10) ran++;
                            else
                            {
                                compComp = 0;
                                returnElementsFromWhereAPlayer = igrokKyda(masGdeIgrok[0] - 1, masGdeIgrok[1], igrok12, masGamingLocationPlay, countKTblue, countKTred,
                                    ran, compComp, flagKT, countKT);
                                countKTBlueAndRed = returnElementsFromWhereAPlayer[0];
                                masGamingLocationPlay = returnElementsFromWhereAPlayer[1];
                                countKTblue = countKTBlueAndRed[0, 0];
                                countKTred = countKTBlueAndRed[0, 1];
                                ran = -1;
                            }
                        }
                        if (ran == 1) //идем вниз
                        {
                            ii = masGdeIgrok[0] + 1;
                            if (ii == -1 || ii == 10) ran++;
                            else
                            {
                                compComp = 0;
                                returnElementsFromWhereAPlayer = igrokKyda(masGdeIgrok[0] + 1, masGdeIgrok[1], igrok12, masGamingLocationPlay, countKTblue, countKTred,
                                    ran, compComp, flagKT, countKT);
                                countKTBlueAndRed = returnElementsFromWhereAPlayer[0];
                                masGamingLocationPlay = returnElementsFromWhereAPlayer[1];
                                countKTblue = countKTBlueAndRed[0, 0];
                                countKTred = countKTBlueAndRed[0, 1];
                                ran = -1;
                            }
                        }
                        if (ran == 2) //идем влево
                        {
                            ii = masGdeIgrok[1] - 1;
                            if (ii == -1 || ii == 10) ran++;
                            else
                            {
                                compComp = 0;
                                returnElementsFromWhereAPlayer = igrokKyda(masGdeIgrok[0], masGdeIgrok[1] - 1, igrok12, masGamingLocationPlay, countKTblue, countKTred,
                                    ran, compComp, flagKT, countKT);
                                countKTBlueAndRed = returnElementsFromWhereAPlayer[0];
                                masGamingLocationPlay = returnElementsFromWhereAPlayer[1];
                                countKTblue = countKTBlueAndRed[0, 0];
                                countKTred = countKTBlueAndRed[0, 1];
                                ran = -1;
                            }
                        }
                    }
                }
            }
            if (masGamingLocationPlay[i, j] == 0)
            {
                flagKT = true;
                masGamingLocationPlay[i, j] = igrok12;
                masGamingLocationPlay[masGdeIgrok[0], masGdeIgrok[1]] = igrokOtkyda(masGdeIgrok[0], masGdeIgrok[1]);
            }
            if (masGamingLocationPlay[i, j] == 3)
            {
                flagKT = true;
                masGamingLocationPlay[i, j] = igrok12 + 5;
                masGamingLocationPlay[masGdeIgrok[0], masGdeIgrok[1]] = igrokOtkyda(masGdeIgrok[0], masGdeIgrok[1]);
                countKT--;

                if (igrok12 == 1) countKTblue++;
                else countKTred++;
            }
            if (masGamingLocationPlay[i, j] == 4 && igrok12 == 1)
            {
                flagKT = true;
                //countKT--;
                masGamingLocationPlay[i, j] = 6;
                masGamingLocationPlay[masGdeIgrok[0], masGdeIgrok[1]] = igrokOtkyda(masGdeIgrok[0], masGdeIgrok[1]);
            }
            if (masGamingLocationPlay[i, j] == 4 && igrok12 == 2)
            {
                flagKT = true;
                masGamingLocationPlay[i, j] = 7;
                masGamingLocationPlay[masGdeIgrok[0], masGdeIgrok[1]] = igrokOtkyda(masGdeIgrok[0], masGdeIgrok[1]);
                countKTblue--;
                countKTred++;
            }
            if (masGamingLocationPlay[i, j] == 5 && igrok12 == 2)
            {
                flagKT = true;
                masGamingLocationPlay[i, j] = 7;
                masGamingLocationPlay[masGdeIgrok[0], masGdeIgrok[1]] = igrokOtkyda(masGdeIgrok[0], masGdeIgrok[1]);
            }
            if (masGamingLocationPlay[i, j] == 5 && igrok12 == 1)
            {
                flagKT = true;
                masGamingLocationPlay[i, j] = 6;
                masGamingLocationPlay[masGdeIgrok[0], masGdeIgrok[1]] = igrokOtkyda(masGdeIgrok[0], masGdeIgrok[1]);
                countKTblue++;
                countKTred--;
            }
            countKTBlueAndRed[0, 0] = countKTblue;
            countKTBlueAndRed[0, 1] = countKTred;
            countKTNew[0, 0] = countKT;
            returnElementsFromWhereAPlayer.Add(countKTBlueAndRed);
            returnElementsFromWhereAPlayer.Add(masGamingLocationPlay);
            returnElementsFromWhereAPlayer.Add(countKTNew);
            return returnElementsFromWhereAPlayer;
        }
        public int igrokOtkyda(int i, int j)
        {
            if (masGdeIgrok[2] == 1 || masGdeIgrok[2] == 2) return 0;
            if (masGdeIgrok[2] == 6) return 4;
            if (masGdeIgrok[2] == 7) return 5;
            return -1;
        }
        public bool proverkaNaXod(int i, int j, int igrok, int[,] masGamingLocationPlay)
        {
            GdeIgrok(igrok, masGamingLocationPlay);
            if (masGdeIgrok[0] == i && (masGdeIgrok[1] == j + 1 || masGdeIgrok[1] == j - 1)) return true;
            if (masGdeIgrok[1] == j && (masGdeIgrok[0] == i + 1 || masGdeIgrok[0] == i - 1)) return true;
            return false;
        }

    }
}
