using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameMushroomPlaces.Model;

namespace GameMushroomPlaces
{
    /// <summary>
    /// 
    /// </summary>
    public class Controller
    {
        private Model.Model model = new Model.Model();
        private View view = new View();

        public string pictureName = String.Empty;
        public bool pictureClick = false;

        #region Singleton
        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if (instance == null) instance = new Controller();

                return instance;
            }
        }
        #endregion

        List<int[,]> returnElementsFromWhereAPlayer = new List<int[,]>();

        private List<int[,]> locations = new List<int[,]>();

        public int[,] masGamingLocationCompare = new int[10, 10];
        public int[,] masGamingLocationPlay = new int[10, 10];

        bool flagKT = false;
        int compComp = 0;
        int ran = 0;

        public int countKT = 10;
        public int countKTblue = 0;
        public int countKTred = 0;
        public bool[] flagStrategyBlue = new bool[5];
        public bool[] flagStrategyRed = new bool[5];
        private bool[] flagLocation = new bool[16];
        private bool[] flagTypeGame;

        public int[,] mas1;
        public int[,] mas2;
        public int[,] mas3;
        public int[,] mas4;
        public int[,] mas5;
        public int[,] mas6;
        public int[,] mas7;
        public int[,] mas8;
        public int[,] mas9;
        public int[,] mas10;
        public int[,] mas11;
        public int[,] mas12;
        public int[,] mas13;
        public int[,] mas14;
        public int[,] mas15;
        public int[,] mas16;

        

        int[,] countKTBlueAndRed = new int[1, 2];

        public Controller()
        {
            flagTypeGame = new bool[3];
            #region Locations

            mas1 = new int[10, 10]
            {
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {3, 0, 0, 0, 0, 0, 0, 3, 0, 0},
                {0, 0, 0, 3, 0, 3, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                {0, 3, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 3, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {3, 0, 0, 0, 0, 0, 0, 3, 0, 2}
            };
            mas2 = new int[10, 10]
            {
                {1, 0, 0, 0, 3, 0, 0, 3, 0, 0},
                {0, 0, 3, 0, 0, 0, 0, 0, 0, 0},
                {3, 0, 0, 0, 3, 0, 0, 0, 0, 0},
                {0, 3, 3, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {3, 0, 3, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {3, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 2}
            };
            mas3 = new int[10, 10]
            {
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 3, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 3, 0, 0},
                {0, 0, 0, 0, 3, 0, 0, 0, 0, 3},
                {0, 0, 0, 0, 0, 0, 0, 3, 3, 0},
                {0, 0, 0, 3, 0, 3, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 3, 0, 3, 2}
            };
            mas4 = new int[10, 10]
            {
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 2}
            };
            mas5 = new int[10, 10]
            {
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 2}
            };
            mas6 = new int[10, 10]
            {
                {1, 0, 0, 0, 0, 0, 0, 3, 0, 3},
                {0, 0, 0, 0, 0, 0, 0, 0, 3, 0},
                {0, 0, 0, 0, 0, 0, 0, 3, 0, 3},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {3, 0, 3, 0, 0, 0, 0, 0, 0, 0},
                {0, 3, 0, 0, 0, 0, 0, 0, 0, 0},
                {3, 0, 3, 0, 0, 0, 0, 0, 0, 2}
            };
            mas7 = new int[10, 10]
            {
                {1, 3, 0, 0, 0, 0, 0, 0, 0, 0},
                {3, 3, 3, 0, 0, 0, 0, 0, 0, 0},
                {0, 3, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 3, 0},
                {0, 0, 0, 0, 0, 0, 0, 3, 3, 3},
                {0, 0, 0, 0, 0, 0, 0, 0, 3, 2}
            };
            mas8 = new int[10, 10]
            {
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {3, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 3, 0, 0, 0, 0, 0, 0, 0},
                {3, 0, 3, 3, 0, 0, 0, 0, 0, 0},
                {0, 3, 0, 0, 0, 0, 0, 0, 0, 0},
                {3, 0, 3, 0, 3, 0, 0, 0, 0, 2}
            };
            mas9 = new int[10, 10]
            {
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 3, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 3, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                {0, 0, 0, 0, 3, 3, 0, 3, 0, 0},
                {0, 0, 0, 3, 0, 0, 0, 0, 3, 0},
                {0, 0, 0, 0, 0, 3, 0, 3, 0, 2}
            };
            mas10 = new int[10, 10]
            {
                {1, 3, 0, 3, 3, 0, 0, 0, 0, 0},
                {0, 3, 0, 3, 0, 0, 0, 0, 0, 0},
                {3, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 3, 0, 3, 0, 0, 0, 0, 0},
                {3, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 3, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 2}
            };
            mas11 = new int[10, 10]
            {
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                {0, 0, 0, 0, 0, 0, 0, 0, 3, 0},
                {0, 0, 0, 0, 0, 0, 0, 3, 0, 0},
                {0, 0, 0, 0, 0, 0, 3, 0, 0, 0},
                {0, 0, 0, 0, 0, 3, 0, 0, 0, 0},
                {0, 0, 0, 0, 3, 0, 0, 0, 0, 0},
                {0, 0, 0, 3, 0, 0, 0, 0, 0, 0},
                {0, 0, 3, 0, 0, 0, 0, 0, 0, 0},
                {0, 3, 0, 0, 0, 0, 0, 0, 0, 0},
                {3, 0, 0, 0, 0, 0, 0, 0, 0, 2}
            };
            mas12 = new int[10, 10]
            {
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 3},
                {0, 3, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 3, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 3, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 3, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 3, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 3, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 3, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 3, 0},
                {3, 0, 0, 0, 0, 0, 0, 0, 0, 2}
            };
            mas13 = new int[10, 10]
            {
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {3, 0, 0, 0, 0, 0, 0, 0, 0, 2}
            };
            mas14 = new int[10, 10]
            {
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 3, 0, 0, 0},
                {0, 0, 0, 3, 3, 3, 0, 0, 0, 0},
                {0, 0, 0, 3, 3, 3, 0, 0, 0, 0},
                {0, 0, 0, 3, 3, 3, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 2}
            };
            mas15 = new int[10, 10]
            {
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 3, 0, 3, 0, 0, 0, 0},
                {0, 0, 3, 0, 3, 0, 3, 0, 0, 0},
                {0, 0, 0, 3, 0, 3, 0, 3, 0, 0},
                {0, 0, 0, 0, 3, 0, 3, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 2}
            };
            mas16 = new int[10, 10]
            {
                {1, 3, 0, 0, 0, 0, 0, 0, 0, 0},
                {3, 3, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 3, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 3, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 3, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 3, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 3, 3},
                {0, 0, 0, 0, 0, 0, 0, 0, 3, 2}
            };
            locations.Add(mas1);
            locations.Add(mas2);
            locations.Add(mas3);
            locations.Add(mas4);
            locations.Add(mas5);
            locations.Add(mas6);
            locations.Add(mas7);
            locations.Add(mas8);
            locations.Add(mas9);
            locations.Add(mas10);
            locations.Add(mas11);
            locations.Add(mas12);
            locations.Add(mas12);
            locations.Add(mas14);
            locations.Add(mas15);
            locations.Add(mas16);

            #endregion
        }

        #region MenuC
        public void ChoosingTypeGame(int idTypeGame)
        {
            ResetAllData();
            flagTypeGame[idTypeGame] = true;
            
        }

        public int[,] GetArrayGamingLocationPlay()
        {
            return masGamingLocationPlay;
        }

        public void ResetAllData()
        {
            for (int i = 0; i < 3; i++)
            {
                flagTypeGame[i] = false;
            }
            for (int i = 0; i < 16; i++)
            {
                flagLocation[i] = false;
            }
            for (int i = 0; i < 5; i++)
            {
                flagStrategyBlue[i] = false;
                flagStrategyRed[i] = false;
            }
            countKT = 10;
            countKTblue = 0;
            countKTred = 0;
        }

        private void FullArrayLocations(int idLocation)
        {
            int[,] masChooseLocation = locations[idLocation];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    masGamingLocationCompare[i, j] = masChooseLocation[i, j];
                    masGamingLocationPlay[i, j] = masChooseLocation[i, j];
                }
            }
        }

        public int[,] GetLocation(int idLocation)
        {
            FullArrayLocations(idLocation);

            flagLocation[idLocation] = true;

            if (idLocation == 0) return mas1;
            if (idLocation == 1) return mas2;
            if (idLocation == 2) return mas3;
            if (idLocation == 3) return mas4;
            if (idLocation == 4) return mas5;
            if (idLocation == 5) return mas6;
            if (idLocation == 6) return mas7;
            if (idLocation == 7) return mas8;
            if (idLocation == 8) return mas9;
            if (idLocation == 9) return mas10;
            if (idLocation == 10) return mas11;
            if (idLocation == 11) return mas12;
            if (idLocation == 12) return mas13;
            if (idLocation == 13) return mas14;
            if (idLocation == 14) return mas15;
            else return mas16;
        }

        public void DetermineStrategy(int i, List<int> listIdStrategy)
        {
            for (int j = 0; j < listIdStrategy.Count; j++)
            {
                if(i == 1) flagStrategyBlue[listIdStrategy[j]] = true;
                else flagStrategyRed[listIdStrategy[j]] = true;
            }
        }

        #endregion

        public int GetTypeGame()
        {
            if (flagTypeGame[0] == true)
            {
                return 0;
            }
            else if (flagTypeGame[1] == true)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public List<int[,]> DefinitionTypeStartegy(int countStrategies, bool[] flagStrategyBlueOrRed, int igrokBlueOrRed, int[,] masGamingLocationPlay,
            int countKTblue, int countKTred, int ran, int compComp, bool flagKT, int countKT)
        {
            List<int[,]> resultExecutionStrategy = new List<int[,]>();
            //проверка количества стратегий
            if (countStrategies > 1)
            {
                //смешанные стратегии
                //resultExecutionStrategy = 
                return model.SelectCountMixedStrategy(countStrategies, flagStrategyBlueOrRed, igrokBlueOrRed, masGamingLocationPlay,
                    countKTblue, countKTred, ran, compComp, flagKT, countKT);
            }
            else
            {
                //чистые стратегии
                if (igrokBlueOrRed == 1)
                {
                    resultExecutionStrategy = DefinitionPureStrategies(igrokBlueOrRed, flagStrategyBlueOrRed, masGamingLocationPlay, countKTblue, countKTred,
                        ran, compComp, flagKT, countKT);
                }
                else
                {
                    resultExecutionStrategy = DefinitionPureStrategies(igrokBlueOrRed, flagStrategyBlueOrRed, masGamingLocationPlay, countKTblue, countKTred,
                        ran, compComp, flagKT, countKT);
                }
                return resultExecutionStrategy;
            }
        }

        private List<int[,]> DefinitionPureStrategies(int igrokBlueOrRed, bool[] flagStrategy, 
            int[,] masGamingLocationPlay, int countKTblue, int countKTred, int ran, int compComp, bool flagKT,
            int countKT)
        {
            List<int[,]> resultPureStrategy = new List<int[,]>();


            if (flagStrategy[0] == true)
                resultPureStrategy = model.SelectPureStrategies(igrokBlueOrRed, 0, masGamingLocationPlay, countKTblue, countKTred,
                    ran, compComp, flagKT, countKT);
            if (flagStrategy[1] == true)
                resultPureStrategy = model.SelectPureStrategies(igrokBlueOrRed, 1, masGamingLocationPlay, countKTblue, countKTred,
                    ran, compComp, flagKT, countKT);
            if (flagStrategy[2] == true)
                resultPureStrategy = model.SelectPureStrategies(igrokBlueOrRed, 2, masGamingLocationPlay, countKTblue, countKTred,
                    ran, compComp, flagKT, countKT);
            if (flagStrategy[3] == true)
                resultPureStrategy = model.SelectPureStrategies(igrokBlueOrRed, 3, masGamingLocationPlay, countKTblue, countKTred,
                    ran, compComp, flagKT, countKT);
            if (flagStrategy[4] == true)
                resultPureStrategy = model.SelectPureStrategies(igrokBlueOrRed, 4, masGamingLocationPlay, countKTblue, countKTred,
                    ran, compComp, flagKT, countKT);
            return resultPureStrategy;
        }

        public int[] GetCountKT()
        {
            int[] arrayCountKT = new int[3];
            arrayCountKT[0] = countKT;
            arrayCountKT[1] = countKTblue;
            arrayCountKT[2] = countKTred;

            return arrayCountKT;
        }

        public int[] GetCountStrategiesBlueAndRed()
        {
            int[] arrayCountStrategies = new int[2];
            arrayCountStrategies[0] = model.DefinitionCountStartegy(flagStrategyBlue);
            arrayCountStrategies[1] = model.DefinitionCountStartegy(flagStrategyRed);
            return arrayCountStrategies;
        }

        public int StepBlue(int countStrategiesBlue)
        {
            compComp = 0;
            flagKT = false;

            //Определение стратегии
            returnElementsFromWhereAPlayer = DefinitionTypeStartegy(countStrategiesBlue, flagStrategyBlue, 1,
                masGamingLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);

            countKTBlueAndRed = returnElementsFromWhereAPlayer[0];
            masGamingLocationPlay = returnElementsFromWhereAPlayer[1];
            countKT = returnElementsFromWhereAPlayer[2][0, 0];
            countKTblue = countKTBlueAndRed[0, 0];
            countKTred = countKTBlueAndRed[0, 1];

            ran = 0;
            flagKT = false;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    masGamingLocationCompare[i, j] = masGamingLocationPlay[i, j];
                }
            }
            return countKT;
        }

        //public int NeuronRed(int countStrategiesRed)
        //{
        //    compComp = 0;

        //    //Определение стратегии
        //    returnElementsFromWhereAPlayer = DefinitionTypeStartegy(countStrategiesRed, flagStrategyRed, 2,
        //        masGamingLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);

        //    countKTBlueAndRed = returnElementsFromWhereAPlayer[0];
        //    masGamingLocationPlay = returnElementsFromWhereAPlayer[1];
        //    countKT = returnElementsFromWhereAPlayer[2][0, 0];
        //    countKTblue = countKTBlueAndRed[0, 0];
        //    countKTred = countKTBlueAndRed[0, 1];

        //    ran = 0;
        //    for (int i = 0; i < 10; i++)
        //    {
        //        for (int j = 0; j < 10; j++)
        //        {
        //            masGamingLocationCompare[i, j] = masGamingLocationPlay[i, j];
        //        }
        //    }
        //    return countKT;
        //}

        public int StepRed(int countStrategiesRed)
        {
            compComp = 0;

            //Определение стратегии
            returnElementsFromWhereAPlayer = DefinitionTypeStartegy(countStrategiesRed, flagStrategyRed, 2,
                masGamingLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);

            countKTBlueAndRed = returnElementsFromWhereAPlayer[0];
            masGamingLocationPlay = returnElementsFromWhereAPlayer[1];
            countKT = returnElementsFromWhereAPlayer[2][0, 0];
            countKTblue = countKTBlueAndRed[0, 0];
            countKTred = countKTBlueAndRed[0, 1];

            ran = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    masGamingLocationCompare[i, j] = masGamingLocationPlay[i, j];
                }
            }
            return countKT;
        }

        public int StepPeople()
        {
            // ПЕРВЫЙ
            int pI = 0, pJ = 0;
            char ss;
            ss = pictureName[7];
            pI = (int)Char.GetNumericValue(ss);
            ss = pictureName[8];
            pJ = (int)Char.GetNumericValue(ss);
            if (model.CheckPlayerMovement(pI, pJ, 2, masGamingLocationPlay) == false)
            {
                pictureName = "";
                return -1;
            }
            returnElementsFromWhereAPlayer = model.PlayerMovement(pI, pJ, 2, masGamingLocationPlay, countKTblue, countKTred,
                ran, compComp, flagKT, countKT);
            countKTBlueAndRed = returnElementsFromWhereAPlayer[0];
            masGamingLocationPlay = returnElementsFromWhereAPlayer[1];
            countKT = returnElementsFromWhereAPlayer[2][0, 0];
            countKTblue = countKTBlueAndRed[0, 0];
            countKTred = countKTBlueAndRed[0, 1];

            int k = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (masGamingLocationCompare[i, j] == masGamingLocationPlay[i, j])
                    {
                        k++;
                    }
                }
            }
            if (k == 100)
            {
                pictureName = "";
                pictureClick = false;
                return -1;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        masGamingLocationCompare[i, j] = masGamingLocationPlay[i, j];
                    }
                }
                return countKT;
            }
        }
        
    }
}
