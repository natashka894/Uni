using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMushroomPlaces.Model.PureStrategies
{
    public class NearestCleanKT
    {
        PlacePlayer whereThePlayer = new PlacePlayer();

        public int[] masGdeIgrok = new int[3];
        public int[] masigrokKuda = new int[2];

        int[,] ktCleaner;

        /// <summary>
        /// 0 - пустые клетки
        /// 1 - 1 игрок
        /// 2 - 2 игрок
        /// 3 - КТ чистая
        /// 4 - КТ занятая 1
        /// 5 - КТ занятая 2
        /// </summary>
        public List<int[,]> KTcleaner(int igrok12, int[,] masGamingLocationPlay, int countKTblue, int countKTred,
            int ran, int compComp, bool flagKT, int countKT)
        {
            List<int[,]> returnElementsFromWhereAPlayer = new List<int[,]>();

            Random rand = new Random();
            masGdeIgrok = whereThePlayer.GdeIgrok(igrok12, masGamingLocationPlay);
            ktCleaner = new int[countKT, 2];//массив чистых контрольных точек
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
                }
            }
            //значение для сравнения, с чистыми контрольными точками
            int ktCleaner_i, ktCleaner_j;
            ktCleaner_i = ktCleaner[0, 0];
            ktCleaner_j = ktCleaner[0, 1];
            int lenghtKT = Math.Abs(ktCleaner[0, 0] - masGdeIgrok[0]) + Math.Abs(ktCleaner[0, 1] - masGdeIgrok[1]);

            int o = 0;
            //найхождение ближайшей чистой кт
            for (int i = 0; i < countKT; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        o = Math.Abs(ktCleaner[i, j] - masGdeIgrok[0]);
                    }
                    if (j == 1)
                    {
                        o = o + Math.Abs(ktCleaner[i, j] - masGdeIgrok[1]);
                    }
                }
                if (o < lenghtKT)
                {
                    lenghtKT = o;
                    ktCleaner_i = ktCleaner[i, 0];
                    ktCleaner_j = ktCleaner[i, 1];
                }
            }
            //если игрок стоит в одной  строке с кт
            if (masGdeIgrok[0] == ktCleaner_i)
            {
                if (masGdeIgrok[1] < ktCleaner_j)
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
                //если игрок стоит в одном столбце с кт
                if (masGdeIgrok[1] == ktCleaner_j)
                {
                    if (masGdeIgrok[0] < ktCleaner_i)
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
                    //если игрок стоит ни в строчке ни в столбце с кт
                    if ((masGdeIgrok[1] != ktCleaner_j && masGdeIgrok[0] != ktCleaner_i))
                    {
                        if (rand.Next(0, 2) == 0)
                        {
                            if (masGdeIgrok[1] < ktCleaner_j)
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
                            if (masGdeIgrok[0] < ktCleaner_i)
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
