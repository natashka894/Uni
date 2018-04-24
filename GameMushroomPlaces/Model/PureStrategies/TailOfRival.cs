
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMushroomPlaces.Model.PureStrategies
{
    public class TailOfRival
    {
        PlacePlayer whereThePlayer = new PlacePlayer();

        int[] path1 = new int[2];
        int[] path2 = new int[2];

        public int[] masGdeIgrok = new int[3];
        public int[] masigrokKuda = new int[2];

        int[,] ktCleaner;

        public List<int[,]> Tail(int igrok12, int[,] masGamingLocationPlay, int countKTblue, int countKTred,
            int ran, int compComp, bool flagKT, int countKT)
        {
            List<int[,]> returnElementsFromWhereAPlayer = new List<int[,]>();
            //int[,] countKTBlueAndRed = new int[0, 1];

            Random rand = new Random();
            int i_Soper = 0, j_Soper = 0;
            int colvoKT = 0;
            //Координаты соперника
            if (igrok12 == 1)
            {
                //2 игрок соперник
                masGdeIgrok = whereThePlayer.GdeIgrok(2, masGamingLocationPlay);
                i_Soper = masGdeIgrok[0];
                j_Soper = masGdeIgrok[1];
                colvoKT = countKT + countKTred;
                ktCleaner = new int[colvoKT, 2];
            }
            else
            {
                //1 игрок соперник
                masGdeIgrok = whereThePlayer.GdeIgrok(1, masGamingLocationPlay);
                i_Soper = masGdeIgrok[0];
                j_Soper = masGdeIgrok[1];
                colvoKT = countKT + countKTblue;
                ktCleaner = new int[colvoKT, 2];
            }
            //координаты игрока, куда пойдет УДАЛИТЬ
            masGdeIgrok = whereThePlayer.GdeIgrok(igrok12, masGamingLocationPlay);
            if (igrok12 == 1)
            {
                masigrokKuda = whereThePlayer.stepPlayers(i_Soper, j_Soper, 1, masGdeIgrok);
                path1[0] = masigrokKuda[0];
                path1[1] = masigrokKuda[1];
            }
            if (igrok12 == 2)
            {
                masigrokKuda = whereThePlayer.stepPlayers(i_Soper, j_Soper, 2, masGdeIgrok);
                path2[0] = masigrokKuda[0];
                path2[1] = masigrokKuda[1];
            }


            //координаты контрольных точек, которые надо захватить
            int _i = 0, _j = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (masGamingLocationPlay[i, j] == 3)
                    {
                        ktCleaner[_i, _j] = i;
                        _j++;
                        ktCleaner[_i, _j] = j;
                        _i++;
                        _j--;
                    }
                    if (masGamingLocationPlay[i, j] == 4 && igrok12 == 2)
                    {
                        ktCleaner[_i, _j] = i;
                        _j++;
                        ktCleaner[_i, _j] = j;
                        _i++;
                        _j--;
                    }
                    if (masGamingLocationPlay[i, j] == 5 && igrok12 == 1)
                    {
                        ktCleaner[_i, _j] = i;
                        _j++;
                        ktCleaner[_i, _j] = j;
                        _i++;
                        _j--;
                    }
                }
            }

            //Определяем точки которые входят в область между игроком и  противником
            int[,] arrayKTField = new int[10,2];
            int[] koordinatyKT = new int[2];
            int index = 0;
            for (int i = 0; i < ktCleaner.Length / 2; i++)
            {
                if (i_Soper <= masGdeIgrok[0] && j_Soper <= masGdeIgrok[1])
                {
                    if (i_Soper <= ktCleaner[i, 0] && ktCleaner[i, 0] <= masGdeIgrok[0] && j_Soper <= ktCleaner[i, 1] && ktCleaner[i, 1] <= masGdeIgrok[1])
                    {
                        arrayKTField[index,0] = ktCleaner[i, 0];
                        arrayKTField[index, 1] = ktCleaner[i, 1];
                        
                    }
                }
                if (i_Soper <= masGdeIgrok[0] && j_Soper >= masGdeIgrok[1])
                {
                    if (i_Soper <= ktCleaner[i, 0] && ktCleaner[i, 0] <= masGdeIgrok[0] && j_Soper >= ktCleaner[i, 1] && ktCleaner[i, 1] >= masGdeIgrok[1])
                    {
                        arrayKTField[index, 0] = ktCleaner[i, 0];
                        arrayKTField[index, 1] = ktCleaner[i, 1];
                    }
                }
                if (i_Soper >= masGdeIgrok[0] && j_Soper <= masGdeIgrok[1])
                {
                    if (i_Soper >= ktCleaner[i, 0] && ktCleaner[i, 0] >= masGdeIgrok[0] && j_Soper <= ktCleaner[i, 1] && ktCleaner[i, 1] <= masGdeIgrok[1])
                    {
                        arrayKTField[index, 0] = ktCleaner[i, 0];
                        arrayKTField[index, 1] = ktCleaner[i, 1];
                    }
                }
                if (i_Soper >= masGdeIgrok[0] && j_Soper >= masGdeIgrok[1])
                {
                    if (i_Soper >= ktCleaner[i, 0] && ktCleaner[i, 0] >= masGdeIgrok[0] && j_Soper >= ktCleaner[i, 1] && ktCleaner[i, 1] >= masGdeIgrok[1])
                    {
                        arrayKTField[index, 0] = ktCleaner[i, 0];
                        arrayKTField[index, 1] = ktCleaner[i, 1];
                    }
                }
                index++;
            }

            //Определяем ближайшую точку к себе
            int nearestKT_i = 0, nearestKT_j = 0;
            if (index != 0)
            {
                int lenghtKT = 20;
                int o = 0;
                for (int i = 0; i < index; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 0)
                        {
                            o = Math.Abs(arrayKTField[i, 0] - masGdeIgrok[0]);
                        }
                        if (j == 1)
                        {
                            o = o + Math.Abs(arrayKTField[i, 1] - masGdeIgrok[1]);
                        }
                    }
                    if (o < lenghtKT)
                    {
                        lenghtKT = o;
                        nearestKT_i = arrayKTField[i, 0];
                        nearestKT_j = arrayKTField[i, 1];
                    }
                }
            }
            else
            {
                nearestKT_i = i_Soper;
                nearestKT_j = j_Soper;
            }

            //определеяем направление
            if (masGdeIgrok[0] == nearestKT_i)
            {
                if (masGdeIgrok[1] <= nearestKT_j)
                {
                    returnElementsFromWhereAPlayer = whereThePlayer.igrokKyda(masGdeIgrok[0], masGdeIgrok[1] + 1,
                        igrok12, masGamingLocationPlay,
                        countKTblue, countKTred, ran, compComp, flagKT, countKT);
                }
                else
                {
                    returnElementsFromWhereAPlayer = whereThePlayer.igrokKyda(masGdeIgrok[0], masGdeIgrok[1] - 1,
                        igrok12, masGamingLocationPlay,
                        countKTblue, countKTred, ran, compComp, flagKT, countKT);
                }
            }
            else
            {
                if (masGdeIgrok[1] == nearestKT_j)
                {
                    if (masGdeIgrok[0] <= nearestKT_i)
                    {

                        returnElementsFromWhereAPlayer = whereThePlayer.igrokKyda(masGdeIgrok[0] + 1, masGdeIgrok[1],
                            igrok12, masGamingLocationPlay,
                            countKTblue, countKTred, ran, compComp, flagKT, countKT);
                    }
                    else
                    {

                        returnElementsFromWhereAPlayer = whereThePlayer.igrokKyda(masGdeIgrok[0] - 1, masGdeIgrok[1],
                            igrok12, masGamingLocationPlay,
                            countKTblue, countKTred, ran, compComp, flagKT, countKT);
                    }
                }
                else
                {
                    if ((masGdeIgrok[1] != nearestKT_j && masGdeIgrok[0] != nearestKT_i))
                    {
                        if (rand.Next(0, 2) == 0)
                        {
                            if (masGdeIgrok[1] <= nearestKT_j)
                            {
                                returnElementsFromWhereAPlayer = whereThePlayer.igrokKyda(masGdeIgrok[0], masGdeIgrok[1] + 1, igrok12, masGamingLocationPlay,
                                countKTblue, countKTred, ran, compComp, flagKT, countKT);
                            }
                            else
                            {
                                returnElementsFromWhereAPlayer = whereThePlayer.igrokKyda(masGdeIgrok[0], masGdeIgrok[1] - 1, igrok12, masGamingLocationPlay,
                                countKTblue, countKTred, ran, compComp, flagKT, countKT);
                            }
                        }
                        else
                        {
                            if (masGdeIgrok[0] <= nearestKT_i)
                            {
                                returnElementsFromWhereAPlayer = whereThePlayer.igrokKyda(masGdeIgrok[0] + 1, masGdeIgrok[1], igrok12, masGamingLocationPlay,
                                countKTblue, countKTred, ran, compComp, flagKT, countKT);
                            }
                            else
                            {
                                returnElementsFromWhereAPlayer = whereThePlayer.igrokKyda(masGdeIgrok[0] - 1, masGdeIgrok[1], igrok12, masGamingLocationPlay,
                                countKTblue, countKTred, ran, compComp, flagKT, countKT);
                            }
                        }
                    }
                }
                
            }
            
            return returnElementsFromWhereAPlayer;
        }
    }
}
