using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMushroomPlaces.Model.PureStrategies
{
    public class ProtectYourKT
    {
        PlacePlayer whereThePlayer = new PlacePlayer();

        public int[] masGdeIgrok = new int[3];
        public int[] masGdeOpponent = new int[3];
        public int[] masigrokKuda = new int[2];

        int[,] ktCleaner;
        int[,] ktNotYourCleaner;

        /// <summary>
        /// 0 - пустые клетки
        /// 1 - 1 игрок
        /// 2 - 2 игрок
        /// 3 - КТ чистая
        /// 4 - КТ занятая 1
        /// 5 - КТ занятая 2
        /// </summary>
        public List<int[,]> Protect(int igrok12, int[,] masGamingLocationPlay, int countKTblue, int countKTred,
            int ran, int compComp, bool flagKT, int countKT)
        {
            List<int[,]> returnElementsFromWhereAPlayer = new List<int[,]>();
            //int[,] countKTBlueAndRed = new int[0, 1];

            Random rand = new Random();
            if (igrok12 == 1)
            {
                int[] arrayPointsOpponent = new int[3];
                arrayPointsOpponent = whereThePlayer.GdeIgrok(2, masGamingLocationPlay);
                for (int i = 0; i < arrayPointsOpponent.Length; i++)
                {
                    masGdeOpponent[i] = arrayPointsOpponent[i];
                }

                masGdeIgrok = whereThePlayer.GdeIgrok(igrok12, masGamingLocationPlay);
            }
            else
            {
                int[] arrayPointsOpponent = new int[3];
                arrayPointsOpponent = whereThePlayer.GdeIgrok(1, masGamingLocationPlay);
                for (int i = 0; i < arrayPointsOpponent.Length; i++)
                {
                    masGdeOpponent[i] = arrayPointsOpponent[i];
                }
                
                masGdeIgrok = whereThePlayer.GdeIgrok(igrok12, masGamingLocationPlay);
                
            }
            int colvoKT = 0;
            if (igrok12 == 1)
            {
                colvoKT = countKT + countKTblue;
                ktCleaner = new int[colvoKT, 2];
            }
            else
            {
                colvoKT = countKT + countKTred;
                ktCleaner = new int[colvoKT, 2];
            }

            int colvoNotYourKT = 0;
            if (igrok12 == 1)
            {
                colvoNotYourKT = countKT + countKTred;
                ktNotYourCleaner = new int[colvoNotYourKT, 2];
            }
            else
            {
                colvoNotYourKT = countKT + countKTblue;
                ktNotYourCleaner = new int[colvoNotYourKT, 2];
            }

            //определяем контрольные точки которые нам нужны
            int _i = 0, _j = 0;
            int[] typeKT = new int[colvoKT];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (masGamingLocationPlay[i, j] == 3)
                    {
                        typeKT[_i] = 3;
                        ktCleaner[_i, _j] = i;
                        _j++;
                        ktCleaner[_i, _j] = j;
                        _i++;
                        _j--;
                    }
                    if (masGamingLocationPlay[i, j] == 4 && igrok12 == 1)
                    {
                        typeKT[_i] = 4;
                        ktCleaner[_i, _j] = i;
                        _j++;
                        ktCleaner[_i, _j] = j;
                        _i++;
                        _j--;
                    }
                    if (masGamingLocationPlay[i, j] == 5 && igrok12 == 2)
                    {
                        typeKT[_i] = 5;
                        ktCleaner[_i, _j] = i;
                        _j++;
                        ktCleaner[_i, _j] = j;
                        _i++;
                        _j--;
                    }
                }
            }

            //определяем контрольные точки которые нам нужны
            int _in = 0, _jn = 0;
            int[] typeNotYourKT = new int[colvoNotYourKT];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (masGamingLocationPlay[i, j] == 3)
                    {
                        typeNotYourKT[_in] = 3;
                        ktNotYourCleaner[_in, _jn] = i;
                        _jn++;
                        ktNotYourCleaner[_in, _jn] = j;
                        _in++;
                        _jn--;
                    }
                    if (masGamingLocationPlay[i, j] == 5 && igrok12 == 1)
                    {
                        typeNotYourKT[_in] = 5;
                        ktNotYourCleaner[_in, _jn] = i;
                        _jn++;
                        ktNotYourCleaner[_in, _jn] = j;
                        _in++;
                        _jn--;
                    }
                    if (masGamingLocationPlay[i, j] == 4 && igrok12 == 2)
                    {
                        typeNotYourKT[_in] = 4;
                        ktNotYourCleaner[_in, _jn] = i;
                        _jn++;
                        ktNotYourCleaner[_in, _jn] = j;
                        _in++;
                        _jn--;
                    }
                }
            }




            int lenghtPlayerOpponent = Math.Abs(masGdeOpponent[0] - masGdeIgrok[0]);
            lenghtPlayerOpponent = lenghtPlayerOpponent + Math.Abs(masGdeOpponent[1] - masGdeIgrok[1]);
            int nearestKT_i = 0, nearestKT_j = 0;

            if (lenghtPlayerOpponent > 4)
            {
                //Определяем точки которые входят в область между игроком и  противником
                int[,] arrayKTField = new int[10, 2];
                int[] koordinatyKT = new int[2];
                int index = 0;
                for (int i = 0; i < ktCleaner.Length / 2; i++)
                {
                    if (masGdeOpponent[0] <= masGdeIgrok[0] && masGdeOpponent[1] <= masGdeIgrok[1])
                    {
                        if (masGdeOpponent[0] <= ktCleaner[i, 0] && ktCleaner[i, 0] <= masGdeIgrok[0] && masGdeOpponent[1] <= ktCleaner[i, 1] && ktCleaner[i, 1] <= masGdeIgrok[1])
                        {
                            arrayKTField[index, 0] = ktCleaner[i, 0];
                            arrayKTField[index, 1] = ktCleaner[i, 1];
                            
                        }
                    }
                    if (masGdeOpponent[0] <= masGdeIgrok[0] && masGdeOpponent[1] >= masGdeIgrok[1])
                    {
                        if (masGdeOpponent[0] <= ktCleaner[i, 0] && ktCleaner[i, 0] <= masGdeIgrok[0] && masGdeOpponent[1] >= ktCleaner[i, 1] && ktCleaner[i, 1] >= masGdeIgrok[1])
                        {
                            arrayKTField[index, 0] = ktCleaner[i, 0];
                            arrayKTField[index, 1] = ktCleaner[i, 1];
                        }
                    }
                    if (masGdeOpponent[0] >= masGdeIgrok[0] && masGdeOpponent[1] <= masGdeIgrok[1])
                    {
                        if (masGdeOpponent[0] >= ktCleaner[i, 0] && ktCleaner[i, 0] >= masGdeIgrok[0] && masGdeOpponent[1] <= ktCleaner[i, 1] && ktCleaner[i, 1] <= masGdeIgrok[1])
                        {
                            arrayKTField[index, 0] = ktCleaner[i, 0];
                            arrayKTField[index, 1] = ktCleaner[i, 1];
                        }
                    }
                    if (masGdeOpponent[0] >= masGdeIgrok[0] && masGdeOpponent[1] >= masGdeIgrok[1])
                    {
                        if (masGdeOpponent[0] >= ktCleaner[i, 0] && ktCleaner[i, 0] >= masGdeIgrok[0] && masGdeOpponent[1] >= ktCleaner[i, 1] && ktCleaner[i, 1] >= masGdeIgrok[1])
                        {
                            arrayKTField[index, 0] = ktCleaner[i, 0];
                            arrayKTField[index, 1] = ktCleaner[i, 1];
                        }
                    }
                    index++;
                }

                //Определяем ближайшую точку к себе
               
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
                    nearestKT_i = masGdeOpponent[0];
                    nearestKT_j = masGdeOpponent[1];
                }
            }
            else
            {
                int lenghtKT = 20;
                if (igrok12 == 2)
                {
                    
                    int o = 0;
                    for (int i = 0; i < ktNotYourCleaner.Length / 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (j == 0)
                            {
                                o = Math.Abs(ktNotYourCleaner[i, 0] - masGdeIgrok[0]);
                            }
                            if (j == 1)
                            {
                                o = o + Math.Abs(ktNotYourCleaner[i, 1] - masGdeIgrok[1]);
                            }
                        }
                        if (o < lenghtKT)
                        {
                            lenghtKT = o;
                            nearestKT_i = ktNotYourCleaner[i, 0];
                            nearestKT_j = ktNotYourCleaner[i, 1];
                        }
                    }
                }
                if (lenghtKT != 1)
                {
                    int countKTFirstPlace = 0, countKTSecondPlace = 0, numberPlace = 0;
                    for (int i = 0; i < ktCleaner.Length / 2; i++)
                    {
                        if (masGdeOpponent[0] < masGdeIgrok[0] && masGdeOpponent[1] < masGdeIgrok[1])
                        {
                            numberPlace = 1;
                            if (ktCleaner[i, 0] <= masGdeIgrok[0] && ktCleaner[i, 1] >= masGdeIgrok[0])
                            {
                                countKTFirstPlace++; //Уменьшаем i
                            }
                            if (ktCleaner[i, 0] >= masGdeIgrok[0] && ktCleaner[i, 1] <= masGdeIgrok[0])
                            {
                                countKTSecondPlace++; //Уменьшаем j
                            }
                        }
                        if (masGdeOpponent[0] < masGdeIgrok[0] && masGdeOpponent[1] > masGdeIgrok[1])
                        {
                            numberPlace = 2;
                            if (ktCleaner[i, 0] <= masGdeIgrok[0] && ktCleaner[i, 1] <= masGdeIgrok[0])
                            {
                                countKTFirstPlace++; //Уменьшаем i
                            }
                            if (ktCleaner[i, 0] >= masGdeIgrok[0] && ktCleaner[i, 1] >= masGdeIgrok[0])
                            {
                                countKTSecondPlace++; //Увеличиваем j
                            }
                        }
                        if (masGdeOpponent[0] > masGdeIgrok[0] && masGdeOpponent[1] < masGdeIgrok[1])
                        {
                            numberPlace = 3;
                            if (ktCleaner[i, 0] <= masGdeIgrok[0] && ktCleaner[i, 1] <= masGdeIgrok[0])
                            {
                                countKTSecondPlace++; //Уменьшаем j
                            }
                            if (ktCleaner[i, 0] >= masGdeIgrok[0] && ktCleaner[i, 1] >= masGdeIgrok[0])
                            {
                                countKTFirstPlace++; //Увеличиваем i
                            }
                        }
                        if (masGdeOpponent[0] > masGdeIgrok[0] && masGdeOpponent[1] > masGdeIgrok[1])
                        {
                            numberPlace = 4;
                            if (ktCleaner[i, 0] <= masGdeIgrok[0] && ktCleaner[i, 1] >= masGdeIgrok[0])
                            {
                                countKTSecondPlace++; //Увеличиваем j
                            }
                            if (ktCleaner[i, 0] >= masGdeIgrok[0] && ktCleaner[i, 1] <= masGdeIgrok[0])
                            {
                                countKTFirstPlace++; //Увеличиваем i
                            }
                        }
                        if (masGdeOpponent[0] == masGdeIgrok[0])
                        {
                            if (masGdeOpponent[1] > masGdeIgrok[1])
                            {
                                nearestKT_i = masGdeIgrok[0];
                                nearestKT_j = masGdeOpponent[1] + 1;
                            }
                            else
                            {
                                nearestKT_i = masGdeIgrok[0];
                                nearestKT_j = masGdeOpponent[1] - 1;
                            }
                            break;
                        }
                        if (masGdeOpponent[1] == masGdeIgrok[1])
                        {
                            if (masGdeOpponent[0] > masGdeIgrok[0])
                            {
                                nearestKT_i = masGdeIgrok[0] + 1;
                                nearestKT_j = masGdeOpponent[1];
                            }
                            else
                            {
                                nearestKT_i = masGdeIgrok[0] - 1;
                                nearestKT_j = masGdeOpponent[1];
                            }
                            break;
                        }
                    }

                    if (countKTFirstPlace == countKTSecondPlace)
                    {
                        for (int i = 0; i < ktCleaner.Length / 2; i++)
                        {
                            if (typeKT[i] == 4 || typeKT[i] == 5)
                            {
                                switch (numberPlace)
                                {
                                    case 1:
                                        if (ktCleaner[i, 0] <= masGdeIgrok[0] && ktCleaner[i, 1] >= masGdeIgrok[0])
                                        {
                                            countKTFirstPlace++; //Уменьшаем i
                                        }
                                        if (ktCleaner[i, 0] >= masGdeIgrok[0] && ktCleaner[i, 1] <= masGdeIgrok[0])
                                        {
                                            countKTSecondPlace++; //Уменьшаем j
                                        }
                                        break;
                                    case 2:
                                        if (ktCleaner[i, 0] <= masGdeIgrok[0] && ktCleaner[i, 1] <= masGdeIgrok[0])
                                        {
                                            countKTFirstPlace++; //Уменьшаем i
                                        }
                                        if (ktCleaner[i, 0] >= masGdeIgrok[0] && ktCleaner[i, 1] >= masGdeIgrok[0])
                                        {
                                            countKTSecondPlace++; //Увеличиваем j
                                        }
                                        break;
                                    case 3:
                                        if (ktCleaner[i, 0] <= masGdeIgrok[0] && ktCleaner[i, 1] <= masGdeIgrok[0])
                                        {
                                            countKTSecondPlace++; //Уменьшаем j
                                        }
                                        if (ktCleaner[i, 0] >= masGdeIgrok[0] && ktCleaner[i, 1] >= masGdeIgrok[0])
                                        {
                                            countKTFirstPlace++; //Увеличиваем i
                                        }
                                        break;
                                    case 4:
                                        if (ktCleaner[i, 0] <= masGdeIgrok[0] && ktCleaner[i, 1] >= masGdeIgrok[0])
                                        {
                                            countKTSecondPlace++; //Увеличиваем j
                                        }
                                        if (ktCleaner[i, 0] >= masGdeIgrok[0] && ktCleaner[i, 1] <= masGdeIgrok[0])
                                        {
                                            countKTFirstPlace++; //Увеличиваем i
                                        }
                                        break;
                                }
                            }
                        }
                        switch (numberPlace)
                        {
                            case 1:
                                if (countKTFirstPlace > countKTSecondPlace)
                                {
                                    nearestKT_i = masGdeIgrok[0] - 1;
                                    nearestKT_j = masGdeOpponent[1];
                                }
                                else
                                {
                                    nearestKT_i = masGdeIgrok[0];
                                    nearestKT_j = masGdeOpponent[1] - 1;
                                }
                                break;
                            case 2:
                                if (countKTFirstPlace > countKTSecondPlace)
                                {
                                    nearestKT_i = masGdeIgrok[0] - 1;
                                    nearestKT_j = masGdeOpponent[1];
                                }
                                else
                                {
                                    nearestKT_i = masGdeIgrok[0];
                                    nearestKT_j = masGdeOpponent[1] + 1;
                                }
                                break;
                            case 3:
                                if (countKTFirstPlace > countKTSecondPlace)
                                {
                                    nearestKT_i = masGdeIgrok[0] + 1;
                                    nearestKT_j = masGdeOpponent[1];
                                }
                                else
                                {
                                    nearestKT_i = masGdeIgrok[0];
                                    nearestKT_j = masGdeOpponent[1] - 1;
                                }
                                break;
                            case 4:
                                if (countKTFirstPlace > countKTSecondPlace)
                                {
                                    nearestKT_i = masGdeIgrok[0] + 1;
                                    nearestKT_j = masGdeOpponent[1];
                                }
                                else
                                {
                                    nearestKT_i = masGdeIgrok[0];
                                    nearestKT_j = masGdeOpponent[1] + 1;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (numberPlace)
                        {
                            case 1:
                                if (countKTFirstPlace > countKTSecondPlace)
                                {
                                    nearestKT_i = masGdeIgrok[0] - 1;
                                    nearestKT_j = masGdeOpponent[1];
                                }
                                else
                                {
                                    nearestKT_i = masGdeIgrok[0];
                                    nearestKT_j = masGdeOpponent[1] - 1;
                                }
                                break;
                            case 2:
                                if (countKTFirstPlace > countKTSecondPlace)
                                {
                                    nearestKT_i = masGdeIgrok[0] - 1;
                                    nearestKT_j = masGdeOpponent[1];
                                }
                                else
                                {
                                    nearestKT_i = masGdeIgrok[0];
                                    nearestKT_j = masGdeOpponent[1] + 1;
                                }
                                break;
                            case 3:
                                if (countKTFirstPlace > countKTSecondPlace)
                                {
                                    nearestKT_i = masGdeIgrok[0] + 1;
                                    nearestKT_j = masGdeOpponent[1];
                                }
                                else
                                {
                                    nearestKT_i = masGdeIgrok[0];
                                    nearestKT_j = masGdeOpponent[1] - 1;
                                }
                                break;
                            case 4:
                                if (countKTFirstPlace > countKTSecondPlace)
                                {
                                    nearestKT_i = masGdeIgrok[0] + 1;
                                    nearestKT_j = masGdeOpponent[1];
                                }
                                else
                                {
                                    nearestKT_i = masGdeIgrok[0];
                                    nearestKT_j = masGdeOpponent[1] + 1;
                                }
                                break;
                        }
                    }
                }


                
            }







            ////Определяем есть ли точки охраняемые игроком
            ////int nearestKT_i = 0, nearestKT_j = 0;
            //int countProtectKT = 0;
            //for (int i = 0; i < ktCleaner.Length/2; i++)
            //{
            //    if (masGdeOpponent[0] < masGdeIgrok[0] && masGdeOpponent[1] < masGdeIgrok[1])
            //    {
            //        if (masGdeIgrok[0] <= ktCleaner[i, 0] && masGdeIgrok[0] <= ktCleaner[i, 1])
            //        {
            //            countProtectKT++;
            //        }
            //    }
            //    if (masGdeOpponent[0] < masGdeIgrok[0] && masGdeOpponent[1] > masGdeIgrok[1])
            //    {
            //        if (masGdeIgrok[0] <= ktCleaner[i, 0] && masGdeIgrok[0] >= ktCleaner[i, 1])
            //        {
            //            countProtectKT++;
            //        }
            //    }
            //    if (masGdeOpponent[0] > masGdeIgrok[0] && masGdeOpponent[1] < masGdeIgrok[1])
            //    {
            //        if (masGdeIgrok[0] >= ktCleaner[i, 0] && masGdeIgrok[0] <= ktCleaner[i, 1])
            //        {
            //            countProtectKT++;
            //        }
            //    }
            //    if (masGdeOpponent[0] > masGdeIgrok[0] && masGdeOpponent[1] > masGdeIgrok[1])
            //    {
            //        if (masGdeIgrok[0] >= ktCleaner[i, 0] && masGdeIgrok[0] >= ktCleaner[i, 1])
            //        {
            //            countProtectKT++;
            //        }
            //    }
            //    if (masGdeOpponent[0] == masGdeIgrok[0] && masGdeOpponent[1] < masGdeIgrok[1])
            //    {
            //        if (masGdeIgrok[1] <= ktCleaner[i, 1])
            //        {
            //            countProtectKT++;
            //        }
            //    }
            //    if (masGdeOpponent[0] == masGdeIgrok[0] && masGdeOpponent[1] > masGdeIgrok[1])
            //    {
            //        if (masGdeIgrok[1] >= ktCleaner[i, 1])
            //        {
            //            countProtectKT++;
            //        }
            //    }
            //    if (masGdeOpponent[0] < masGdeIgrok[0] && masGdeOpponent[1] == masGdeIgrok[1])
            //    {
            //        if (masGdeIgrok[0] <= ktCleaner[i, 0])
            //        {
            //            countProtectKT++;
            //        }
            //    }
            //    if (masGdeOpponent[0] > masGdeIgrok[0] && masGdeOpponent[1] == masGdeIgrok[1])
            //    {
            //        if (masGdeIgrok[0] >= ktCleaner[i, 0])
            //        {
            //            countProtectKT++;
            //        }
            //    }
            //}

            //int lenghtPlayerOpponent = Math.Abs(masGdeOpponent[0] - masGdeIgrok[0]);
            //lenghtPlayerOpponent = lenghtPlayerOpponent + Math.Abs(masGdeOpponent[1] - masGdeIgrok[1]);

            //if (countProtectKT == 0 || lenghtPlayerOpponent > 4)
            //{
            //    nearestKT_i = masGdeOpponent[0];
            //    nearestKT_j = masGdeOpponent[1];
            //}
            //else
            //{
            //    int countKTFirstPlace = 0, countKTSecondPlace = 0, numberPlace = 0;
            //    for (int i = 0; i < ktCleaner.Length / 2; i++)
            //    {
            //        if (masGdeOpponent[0] < masGdeIgrok[0] && masGdeOpponent[1] < masGdeIgrok[1])
            //        {
            //            numberPlace = 1;
            //            if (ktCleaner[i, 0] <= masGdeIgrok[0] && ktCleaner[i, 1] >= masGdeIgrok[0])
            //            {
            //                countKTFirstPlace++; //Уменьшаем i
            //            }
            //            if (ktCleaner[i, 0] >= masGdeIgrok[0] && ktCleaner[i, 1] <= masGdeIgrok[0])
            //            {
            //                countKTSecondPlace++; //Уменьшаем j
            //            }
            //        }
            //        if (masGdeOpponent[0] < masGdeIgrok[0] && masGdeOpponent[1] > masGdeIgrok[1])
            //        {
            //            numberPlace = 2;
            //            if (ktCleaner[i, 0] <= masGdeIgrok[0] && ktCleaner[i, 1] <= masGdeIgrok[0])
            //            {
            //                countKTFirstPlace++; //Уменьшаем i
            //            }
            //            if (ktCleaner[i, 0] >= masGdeIgrok[0] && ktCleaner[i, 1] >= masGdeIgrok[0])
            //            {
            //                countKTSecondPlace++; //Увеличиваем j
            //            }
            //        }
            //        if (masGdeOpponent[0] > masGdeIgrok[0] && masGdeOpponent[1] < masGdeIgrok[1])
            //        {
            //            numberPlace = 3;
            //            if (ktCleaner[i, 0] <= masGdeIgrok[0] && ktCleaner[i, 1] <= masGdeIgrok[0])
            //            {
            //                countKTSecondPlace++; //Уменьшаем j
            //            }
            //            if (ktCleaner[i, 0] >= masGdeIgrok[0] && ktCleaner[i, 1] >= masGdeIgrok[0])
            //            {
            //                countKTFirstPlace++; //Увеличиваем i
            //            }
            //        }
            //        if (masGdeOpponent[0] > masGdeIgrok[0] && masGdeOpponent[1] > masGdeIgrok[1])
            //        {
            //            numberPlace = 4;
            //            if (ktCleaner[i, 0] <= masGdeIgrok[0] && ktCleaner[i, 1] >= masGdeIgrok[0])
            //            {
            //                countKTSecondPlace++; //Увеличиваем j
            //            }
            //            if (ktCleaner[i, 0] >= masGdeIgrok[0] && ktCleaner[i, 1] <= masGdeIgrok[0])
            //            {
            //                countKTFirstPlace++; //Увеличиваем i
            //            }
            //        }
            //        if (masGdeOpponent[0] == masGdeIgrok[0])
            //        {
            //            if (masGdeOpponent[1] > masGdeIgrok[1])
            //            {
            //                nearestKT_i = masGdeIgrok[0];
            //                nearestKT_j = masGdeOpponent[1] + 1;
            //            }
            //            else
            //            {
            //                nearestKT_i = masGdeIgrok[0];
            //                nearestKT_j = masGdeOpponent[1] - 1;
            //            }
            //            break;
            //        }
            //        if (masGdeOpponent[1] == masGdeIgrok[1])
            //        {
            //            if (masGdeOpponent[0] > masGdeIgrok[0])
            //            {
            //                nearestKT_i = masGdeIgrok[0] + 1;
            //                nearestKT_j = masGdeOpponent[1];
            //            }
            //            else
            //            {
            //                nearestKT_i = masGdeIgrok[0] - 1;
            //                nearestKT_j = masGdeOpponent[1];
            //            }
            //            break;
            //        }
            //    }

            //    if (countKTFirstPlace == countKTSecondPlace)
            //    {
            //        for (int i = 0; i < ktCleaner.Length/2; i++)
            //        {
            //            if (typeKT[i] == 4 || typeKT[i] == 5)
            //            {
            //                switch (numberPlace)
            //                {
            //                    case 1:
            //                        if (ktCleaner[i, 0] <= masGdeIgrok[0] && ktCleaner[i, 1] >= masGdeIgrok[0])
            //                        {
            //                            countKTFirstPlace++; //Уменьшаем i
            //                        }
            //                        if (ktCleaner[i, 0] >= masGdeIgrok[0] && ktCleaner[i, 1] <= masGdeIgrok[0])
            //                        {
            //                            countKTSecondPlace++; //Уменьшаем j
            //                        }
            //                        break;
            //                    case 2:
            //                        if (ktCleaner[i, 0] <= masGdeIgrok[0] && ktCleaner[i, 1] <= masGdeIgrok[0])
            //                        {
            //                            countKTFirstPlace++; //Уменьшаем i
            //                        }
            //                        if (ktCleaner[i, 0] >= masGdeIgrok[0] && ktCleaner[i, 1] >= masGdeIgrok[0])
            //                        {
            //                            countKTSecondPlace++; //Увеличиваем j
            //                        }
            //                        break;
            //                    case 3:
            //                        if (ktCleaner[i, 0] <= masGdeIgrok[0] && ktCleaner[i, 1] <= masGdeIgrok[0])
            //                        {
            //                            countKTSecondPlace++; //Уменьшаем j
            //                        }
            //                        if (ktCleaner[i, 0] >= masGdeIgrok[0] && ktCleaner[i, 1] >= masGdeIgrok[0])
            //                        {
            //                            countKTFirstPlace++; //Увеличиваем i
            //                        }
            //                        break;
            //                    case 4:
            //                        if (ktCleaner[i, 0] <= masGdeIgrok[0] && ktCleaner[i, 1] >= masGdeIgrok[0])
            //                        {
            //                            countKTSecondPlace++; //Увеличиваем j
            //                        }
            //                        if (ktCleaner[i, 0] >= masGdeIgrok[0] && ktCleaner[i, 1] <= masGdeIgrok[0])
            //                        {
            //                            countKTFirstPlace++; //Увеличиваем i
            //                        }
            //                        break;
            //                }
            //            }
            //        }
            //        switch (numberPlace)
            //        {
            //            case 1:
            //                if (countKTFirstPlace > countKTSecondPlace)
            //                {
            //                    nearestKT_i = masGdeIgrok[0] - 1;
            //                    nearestKT_j = masGdeOpponent[1];
            //                }
            //                else
            //                {
            //                    nearestKT_i = masGdeIgrok[0];
            //                    nearestKT_j = masGdeOpponent[1] - 1;
            //                }
            //                break;
            //            case 2:
            //                if (countKTFirstPlace > countKTSecondPlace)
            //                {
            //                    nearestKT_i = masGdeIgrok[0] - 1;
            //                    nearestKT_j = masGdeOpponent[1];
            //                }
            //                else
            //                {
            //                    nearestKT_i = masGdeIgrok[0];
            //                    nearestKT_j = masGdeOpponent[1] + 1;
            //                }
            //                break;
            //            case 3:
            //                if (countKTFirstPlace > countKTSecondPlace)
            //                {
            //                    nearestKT_i = masGdeIgrok[0] + 1;
            //                    nearestKT_j = masGdeOpponent[1];
            //                }
            //                else
            //                {
            //                    nearestKT_i = masGdeIgrok[0];
            //                    nearestKT_j = masGdeOpponent[1] - 1;
            //                }
            //                break;
            //            case 4:
            //                if (countKTFirstPlace > countKTSecondPlace)
            //                {
            //                    nearestKT_i = masGdeIgrok[0] + 1;
            //                    nearestKT_j = masGdeOpponent[1];
            //                }
            //                else
            //                {
            //                    nearestKT_i = masGdeIgrok[0];
            //                    nearestKT_j = masGdeOpponent[1] + 1;
            //                }
            //                break;
            //        }
            //    }
            //    else
            //    {
            //        switch (numberPlace)
            //        {
            //            case 1:
            //                if (countKTFirstPlace > countKTSecondPlace)
            //                {
            //                    nearestKT_i = masGdeIgrok[0] - 1;
            //                    nearestKT_j = masGdeOpponent[1];
            //                }
            //                else
            //                {
            //                    nearestKT_i = masGdeIgrok[0];
            //                    nearestKT_j = masGdeOpponent[1] - 1;
            //                }
            //                break;
            //            case 2:
            //                if (countKTFirstPlace > countKTSecondPlace)
            //                {
            //                    nearestKT_i = masGdeIgrok[0] - 1;
            //                    nearestKT_j = masGdeOpponent[1];
            //                }
            //                else
            //                {
            //                    nearestKT_i = masGdeIgrok[0];
            //                    nearestKT_j = masGdeOpponent[1] + 1;
            //                }
            //                break;
            //            case 3:
            //                if (countKTFirstPlace > countKTSecondPlace)
            //                {
            //                    nearestKT_i = masGdeIgrok[0] + 1;
            //                    nearestKT_j = masGdeOpponent[1];
            //                }
            //                else
            //                {
            //                    nearestKT_i = masGdeIgrok[0];
            //                    nearestKT_j = masGdeOpponent[1] - 1;
            //                }
            //                break;
            //            case 4:
            //                if (countKTFirstPlace > countKTSecondPlace)
            //                {
            //                    nearestKT_i = masGdeIgrok[0] + 1;
            //                    nearestKT_j = masGdeOpponent[1];
            //                }
            //                else
            //                {
            //                    nearestKT_i = masGdeIgrok[0];
            //                    nearestKT_j = masGdeOpponent[1] + 1;
            //                }
            //                break;
            //        }
            //    }
            //}

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
                            if (masGdeIgrok[0] <= nearestKT_i )
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
