using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMushroomPlaces.Model.PureStrategies
{
    public class NotYourKT
    {
        PlacePlayer whereThePlayer = new PlacePlayer();

        public int[] masGdeIgrok = new int[3];
        public int[] masigrokKuda = new int[2];

        int[,] ktCleaner;

        public List<int[,]> KTcleanerANDalien(int igrok12, int[,] masGamingLocationPlay, int countKTblue, int countKTred,
            int ran, int compComp, bool flagKT, int countKT)
        {
            List<int[,]> returnElementsFromWhereAPlayer = new List<int[,]>();
            //int[,] countKTBlueAndRed = new int[0, 1];

            Random rand = new Random();
            masGdeIgrok = whereThePlayer.GdeIgrok(igrok12, masGamingLocationPlay);
            int colvoKT = 0;
            if (igrok12 == 1)
            {
                colvoKT = countKT + countKTred;
                ktCleaner = new int[colvoKT, 2];
            }
            else
            {
                colvoKT = countKT + countKTblue;
                ktCleaner = new int[colvoKT, 2];
            }
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
            int ktCleaner_i = 0, ktCleaner_j = 0;
            int lenghtKT = 20;
            int o = 0;
            for (int i = 0; i < colvoKT; i++)
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
            if (masGdeIgrok[0] == ktCleaner_i)
            {
                if (masGdeIgrok[1] <= ktCleaner_j)
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
                if (masGdeIgrok[1] == ktCleaner_j)
                {
                    if (masGdeIgrok[0] <= ktCleaner_i)
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
                    if ((masGdeIgrok[1] != ktCleaner_j && masGdeIgrok[0] != ktCleaner_i))
                    {
                        if (rand.Next(0, 2) == 0)
                        {
                            if (masGdeIgrok[1] <= ktCleaner_j)
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
                            if (masGdeIgrok[0] <= ktCleaner_i)
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
