using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameMushroomPlaces.Properties;


namespace GameMushroomPlaces
{
    /// <summary>
    /// 
    /// </summary>
    public partial class View : Form
    {

        private List<int[,]> locations = new List<int[,]>();

        int[,] mas1;
        int[,] mas2;
        int[,] mas3;
        int[,] mas4;
        int[,] mas5;
        int[,] mas6;
        int[,] mas7;
        int[,] mas8;
        int[,] mas9;
        int[,] mas10;
        int[,] mas11;
        int[,] mas12;
        int[,] mas13;
        int[,] mas14;
        int[,] mas15;
        int[,] mas16;
        int k = 0;

        private PictureBox[,] listPictureField = new PictureBox[10, 10];

        /// <summary>
        /// 0 - пустые клетки
        /// 1 - 1 игрок
        /// 2 - 2 игрок
        /// 3 - КТ чистая
        /// 4 - КТ занятая 1
        /// 5 - КТ занятая 2
        /// </summary>

        List<string> comparisonListBlue = new List<string>();
        List<string> comparisonListRed = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        public View()
        {
            InitializeComponent();

            #region Locations
            mas1 = new int[10, 10]{
            {1,0,0,0,0,0,0,0,0,3},
            {0,0,0,0,0,0,0,0,0,0},
            {3,0,0,0,0,0,0,3,0,0},
            {0,0,0,3,0,3,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,3},
            {0,3,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,3,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {3,0,0,0,0,0,0,3,0,2}
            };
            mas2 = new int[10, 10]{
            {1,0,0,0,3,0,0,3,0,0},
            {0,0,3,0,0,0,0,0,0,0},
            {3,0,0,0,3,0,0,0,0,0},
            {0,3,3,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {3,0,3,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {3,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,2}
            };
            mas3 = new int[10, 10]{
            {1,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,3,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,3,0,0},
            {0,0,0,0,3,0,0,0,0,3},
            {0,0,0,0,0,0,0,3,3,0},
            {0,0,0,3,0,3,0,0,0,0},
            {0,0,0,0,0,0,3,0,3,2}
            };
            mas4 = new int[10, 10]{
            {1,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {3,3,3,3,3,3,3,3,3,3},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,2}
            };
            mas5 = new int[10, 10]{
            {1,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {3,3,3,3,3,3,3,3,3,3},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,2}
            };
            mas6 = new int[10, 10]{
            {1,0,0,0,0,0,0,3,0,3},
            {0,0,0,0,0,0,0,0,3,0},
            {0,0,0,0,0,0,0,3,0,3},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {3,0,3,0,0,0,0,0,0,0},
            {0,3,0,0,0,0,0,0,0,0},
            {3,0,3,0,0,0,0,0,0,2}
            };
            mas7 = new int[10, 10]{
            {1,3,0,0,0,0,0,0,0,0},
            {3,3,3,0,0,0,0,0,0,0},
            {0,3,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,3,0},
            {0,0,0,0,0,0,0,3,3,3},
            {0,0,0,0,0,0,0,0,3,2}
            };
            mas8 = new int[10, 10]{
            {1,0,0,0,0,0,0,0,0,3},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {3,0,0,0,0,0,0,0,0,0},
            {0,0,3,0,0,0,0,0,0,0},
            {3,0,3,3,0,0,0,0,0,0},
            {0,3,0,0,0,0,0,0,0,0},
            {3,0,3,0,3,0,0,0,0,2}
            };
            mas9 = new int[10, 10]{
            {1,0,0,0,0,0,0,0,0,0},
            {0,3,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,3,0,0,0},
            {0,0,0,0,0,0,0,0,0,3},
            {0,0,0,0,3,3,0,3,0,0},
            {0,0,0,3,0,0,0,0,3,0},
            {0,0,0,0,0,3,0,3,0,2}
            };
            mas10 = new int[10, 10]{
            {1,3,0,3,3,0,0,0,0,0},
            {0,3,0,3,0,0,0,0,0,0},
            {3,0,0,0,0,0,0,0,0,0},
            {0,0,3,0,3,0,0,0,0,0},
            {3,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,3,0},
            {0,0,0,0,0,0,0,0,0,2}
            };
            mas11 = new int[10, 10]{
            {1,0,0,0,0,0,0,0,0,3},
            {0,0,0,0,0,0,0,0,3,0},
            {0,0,0,0,0,0,0,3,0,0},
            {0,0,0,0,0,0,3,0,0,0},
            {0,0,0,0,0,3,0,0,0,0},
            {0,0,0,0,3,0,0,0,0,0},
            {0,0,0,3,0,0,0,0,0,0},
            {0,0,3,0,0,0,0,0,0,0},
            {0,3,0,0,0,0,0,0,0,0},
            {3,0,0,0,0,0,0,0,0,2}
            };
            mas12 = new int[10, 10]{
            {1,0,0,0,0,0,0,0,0,3},
            {0,3,0,0,0,0,0,0,0,0},
            {0,0,3,0,0,0,0,0,0,0},
            {0,0,0,3,0,0,0,0,0,0},
            {0,0,0,0,3,0,0,0,0,0},
            {0,0,0,0,0,3,0,0,0,0},
            {0,0,0,0,0,0,3,0,0,0},
            {0,0,0,0,0,0,0,3,0,0},
            {0,0,0,0,0,0,0,0,3,0},
            {3,0,0,0,0,0,0,0,0,2}
            };
            mas13 = new int[10, 10]{
            {1,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,3,3,3,3,3,3,3,3,3},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {3,0,0,0,0,0,0,0,0,2}
            };
            mas14 = new int[10, 10]{
            {1,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,3,0,0,0},
            {0,0,0,3,3,3,0,0,0,0},
            {0,0,0,3,3,3,0,0,0,0},
            {0,0,0,3,3,3,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,2}
            };
            mas15 = new int[10, 10]{
            {1,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,3,0,3,0,0,0,0},
            {0,0,3,0,3,0,3,0,0,0},
            {0,0,0,3,0,3,0,3,0,0},
            {0,0,0,0,3,0,3,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,2}
            };
            mas16 = new int[10, 10]{
            {1,3,0,0,0,0,0,0,0,0},
            {3,3,0,0,0,0,0,0,0,0},
            {0,3,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,3,0,0,0,0,0},
            {0,0,0,0,0,3,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,3,0},
            {0,0,0,0,0,0,0,0,3,3},
            {0,0,0,0,0,0,0,0,3,2}
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
            #region List object field
            listPictureField[0, 0] = picture00;
            listPictureField[0, 1] = picture01;
            listPictureField[0, 2] = picture02;
            listPictureField[0, 3] = picture03;
            listPictureField[0, 4] = picture04;
            listPictureField[0, 5] = picture05;
            listPictureField[0, 6] = picture06;
            listPictureField[0, 7] = picture07;
            listPictureField[0, 8] = picture08;
            listPictureField[0, 9] = picture09;

            listPictureField[1, 0] = picture10;
            listPictureField[1, 1] = picture11;
            listPictureField[1, 2] = picture12;
            listPictureField[1, 3] = picture13;
            listPictureField[1, 4] = picture14;
            listPictureField[1, 5] = picture15;
            listPictureField[1, 6] = picture16;
            listPictureField[1, 7] = picture17;
            listPictureField[1, 8] = picture18;
            listPictureField[1, 9] = picture19;

            listPictureField[2, 0] = picture20;
            listPictureField[2, 1] = picture21;
            listPictureField[2, 2] = picture22;
            listPictureField[2, 3] = picture23;
            listPictureField[2, 4] = picture24;
            listPictureField[2, 5] = picture25;
            listPictureField[2, 6] = picture26;
            listPictureField[2, 7] = picture27;
            listPictureField[2, 8] = picture28;
            listPictureField[2, 9] = picture29;

            listPictureField[3, 0] = picture30;
            listPictureField[3, 1] = picture31;
            listPictureField[3, 2] = picture32;
            listPictureField[3, 3] = picture33;
            listPictureField[3, 4] = picture34;
            listPictureField[3, 5] = picture35;
            listPictureField[3, 6] = picture36;
            listPictureField[3, 7] = picture37;
            listPictureField[3, 8] = picture38;
            listPictureField[3, 9] = picture39;

            listPictureField[4, 0] = picture40;
            listPictureField[4, 1] = picture41;
            listPictureField[4, 2] = picture42;
            listPictureField[4, 3] = picture43;
            listPictureField[4, 4] = picture44;
            listPictureField[4, 5] = picture45;
            listPictureField[4, 6] = picture46;
            listPictureField[4, 7] = picture47;
            listPictureField[4, 8] = picture48;
            listPictureField[4, 9] = picture49;

            listPictureField[5, 0] = picture50;
            listPictureField[5, 1] = picture51;
            listPictureField[5, 2] = picture52;
            listPictureField[5, 3] = picture53;
            listPictureField[5, 4] = picture54;
            listPictureField[5, 5] = picture55;
            listPictureField[5, 6] = picture56;
            listPictureField[5, 7] = picture57;
            listPictureField[5, 8] = picture58;
            listPictureField[5, 9] = picture59;

            listPictureField[6, 0] = picture60;
            listPictureField[6, 1] = picture61;
            listPictureField[6, 2] = picture62;
            listPictureField[6, 3] = picture63;
            listPictureField[6, 4] = picture64;
            listPictureField[6, 5] = picture65;
            listPictureField[6, 6] = picture66;
            listPictureField[6, 7] = picture67;
            listPictureField[6, 8] = picture68;
            listPictureField[6, 9] = picture69;

            listPictureField[7, 0] = picture70;
            listPictureField[7, 1] = picture71;
            listPictureField[7, 2] = picture72;
            listPictureField[7, 3] = picture73;
            listPictureField[7, 4] = picture74;
            listPictureField[7, 5] = picture75;
            listPictureField[7, 6] = picture76;
            listPictureField[7, 7] = picture77;
            listPictureField[7, 8] = picture78;
            listPictureField[7, 9] = picture79;

            listPictureField[8, 0] = picture80;
            listPictureField[8, 1] = picture81;
            listPictureField[8, 2] = picture82;
            listPictureField[8, 3] = picture83;
            listPictureField[8, 4] = picture84;
            listPictureField[8, 5] = picture85;
            listPictureField[8, 6] = picture86;
            listPictureField[8, 7] = picture87;
            listPictureField[8, 8] = picture88;
            listPictureField[8, 9] = picture89;

            listPictureField[9, 0] = picture90;
            listPictureField[9, 1] = picture91;
            listPictureField[9, 2] = picture92;
            listPictureField[9, 3] = picture93;
            listPictureField[9, 4] = picture94;
            listPictureField[9, 5] = picture95;
            listPictureField[9, 6] = picture96;
            listPictureField[9, 7] = picture97;
            listPictureField[9, 8] = picture98;
            listPictureField[9, 9] = picture99;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    listPictureField[i, j].Enabled = false;
                }
            }
            #endregion
            #region Lists for disply in the program
            typeGame.Items.Add("Computer + computer");
            typeGame.Items.Add("Computer + people");
            typeGame.Items.Add("Computer + neuron");
            listLocation.Items.Add("KT randomly arranged");
            listLocation.Items.Add("KT close to 1 player");
            listLocation.Items.Add("KT close to 2 player");
            listLocation.Items.Add("KT a line closer to 2");
            listLocation.Items.Add("KT a line closer to 1");
            listLocation.Items.Add("KT on the edges of the work on the flank 2");
            listLocation.Items.Add("KT the players, the work on the flank 2");
            listLocation.Items.Add("The outcome of the game decided 1 detached КТ");
            listLocation.Items.Add("1 detached from KT 1 player");
            listLocation.Items.Add("1 detached from KT 2 player");
            listLocation.Items.Add("KT stand in the middle, on the diagonal");
            listLocation.Items.Add("KT between players, 2 debarred");
            listLocation.Items.Add("KT in line 1 detached KT");
            listLocation.Items.Add("KT along the middle");
            listLocation.Items.Add("KT in the middle checkered");
            listLocation.Items.Add("2 KT debarred the middle");
            #endregion

            pictureHeadBand.Image = new Bitmap(Resources.fonMenu);
            pictureResultBlue.Image = new Bitmap(Resources.bed);
            pictureResultRed.Image = new Bitmap(Resources.good);
            pictureScoreBlue.Image = new Bitmap(Resources.bed);
            pictureScoreRed.Image = new Bitmap(Resources.good);

            comparisonListBlue.Add("Go to the nearest clean KT");
            comparisonListBlue.Add("Go to the nearest not his KT");
            comparisonListBlue.Add("Going tail 2");
            comparisonListBlue.Add("Attack KT 2");
            comparisonListBlue.Add("Security");

            comparisonListRed.Add("Go to the nearest clean KT");
            comparisonListRed.Add("Go to the nearest not his KT");
            comparisonListRed.Add("Going tail 1");
            comparisonListRed.Add("Attack KT 1");
            comparisonListRed.Add("Security");
        }

        #region Menu
        private void SelectedTypeGame(object sender, EventArgs e)
        {
            int idChooseTypeGame = typeGame.SelectedIndex;
            Controller.Instance.ChoosingTypeGame(idChooseTypeGame);

            listLocation.Visible = false;
            checkedListStrategyBlue.Visible = false;
            checkedListStrategyRed.Visible = false;
            labelSelectStrategyBlue.Visible = false;
            labelSelectStrategyRed.Visible = false;
            buttonPlay.Visible = false;
            listLocation.Visible = true;
            labelSelectLocation.Visible = true;
        }

        private void SelectedLocation(object sender, EventArgs e)
        {
            int[,] arrayLocation = Controller.Instance.GetLocation(listLocation.SelectedIndex);

            UpdateView(arrayLocation);

            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    listPictureField[i, j].Visible = true;
                }
            }
            pictureHeadBand.Visible = false;
            if (Controller.Instance.GetTypeGame() == 0 || Controller.Instance.GetTypeGame() == 1)
            {
                checkedListStrategyBlue.Visible = true;
                labelSelectStrategyBlue.Visible = true;
            }
        }

        private void SelectedStrategyBlue(object sender, EventArgs e)
        {
            if (Controller.Instance.GetTypeGame() == 0)
            {
                checkedListStrategyRed.Visible = true;
                labelSelectStrategyRed.Visible = true;
            }
            else
            {
                buttonPlay.Visible = true;
                buttonAnew.Visible = true;
            }
        }

        private void SelectedStrategyRed(object sender, EventArgs e)
        {
            buttonPlay.Visible = true;
            buttonAnew.Visible = true;
        }

        private void СlickButtonPlay(object sender, EventArgs e)
        {
            
            //BLUE
            List<int> listIdStrategyBlue = new List<int>();
            for (int i = 0; i < checkedListStrategyBlue.CheckedItems.Count; i++)
            {
                for (int j = 0; j < comparisonListBlue.Count; j++)
                {
                    if (checkedListStrategyBlue.CheckedItems[i] == comparisonListBlue[j])
                    {
                        listIdStrategyBlue.Add(j);
                    }
                }
            }
            //RED
            List<int> listIdStrategyRed = new List<int>();
            for (int i = 0; i < checkedListStrategyRed.CheckedItems.Count; i++)
            {
                for (int j = 0; j < comparisonListRed.Count; j++)
                {
                    if (checkedListStrategyRed.CheckedItems[i] == comparisonListRed[j])
                    {
                        listIdStrategyRed.Add(j);
                    }
                }
            }

            if (listIdStrategyBlue.Count == 0 || listIdStrategyRed.Count == 0 && Controller.Instance.GetTypeGame() == 0)
            {
                listHistory.Items.Add("Strategies were not selected!");
                listHistory.ForeColor = Color.Red;
            }
            else
            {
                if (listIdStrategyBlue.Count == 0 && Controller.Instance.GetTypeGame() == 1)
                {
                    listHistory.Items.Add("Strategies were not selected!");
                    listHistory.ForeColor = Color.Red;
                }
                else
                {
                    Controller.Instance.DetermineStrategy(2, listIdStrategyRed); //Enum!!!!!!!!!!!!!!!!!!
                    Controller.Instance.DetermineStrategy(1, listIdStrategyBlue); //Enum!!!!!!!!!!!!!!!!!!

                    pictureScoreBlue.Visible = true;
                    pictureScoreRed.Visible = true;
                    labelResult.Visible = true;
                    labelScoreBlue.Visible = true;
                    labelScoreRed.Visible = true;
                    pictureResultBlue.Visible = true;
                    pictureResultRed.Visible = true;
                    typeGame.Enabled = false;
                    listLocation.Enabled = false;
                    checkedListStrategyBlue.Enabled = false;
                    checkedListStrategyRed.Enabled = false;
                    buttonPlay.Enabled = false;
                    buttonAnew.Enabled = true;
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            listPictureField[i, j].Enabled = true;
                        }
                    }

                    switch (Controller.Instance.GetTypeGame())
                    {
                        case 0:
                            GameComputerComputerView();
                            break;
                        case 1:
                            GameComputerPeopleView();
                            break;
                        //case 2:
                        //    GameComputerNeuronView();
                    }
                    if (Controller.Instance.GetTypeGame() == 0)
                    {
                        GameComputerComputerView();
                    }
                    else
                    {
                        GameComputerPeopleView();
                    }
                }
            }
        }

        private void ClickButtonAnew(object sender, EventArgs e)
        {
            Controller.Instance.ResetAllData();

            for (int i = 0; i < 5; i++)
            {
                checkedListStrategyBlue.SetItemChecked(i, false);
                checkedListStrategyRed.SetItemChecked(i, false);
            }
            

            typeGame.Enabled = true;
            listLocation.Enabled = true;
            checkedListStrategyBlue.Enabled = true;
            checkedListStrategyRed.Enabled = true;
            buttonPlay.Enabled = true;
            pictureHeadBand.Visible = true;
            buttonMore.Visible = false;
            listLocation.Visible = false;
            checkedListStrategyBlue.Visible = false;
            checkedListStrategyRed.Visible = false;
            buttonPlay.Visible = false;
            labelSelectLocation.Visible = false;
            labelSelectStrategyBlue.Visible = false;
            labelSelectStrategyRed.Visible = false;
            labelScoreBlue.Text = "- 0";
            labelScoreRed.Text = "- 0";
            labelResult.Text = "? : ?";
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    listPictureField[i, j].Visible = false;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    listPictureField[i, j].Enabled = false;
                }
            }
        }

        public void SummaryEndGame()
        {
            int[] arrayCountKT = Controller.Instance.GetCountKT();
            int countKTblue = arrayCountKT[1];
            int countKTred = arrayCountKT[2];

            if (countKTblue == countKTred)
            {
                listHistory.Items.Add("Draw!");
            }
            if (countKTblue < countKTred)
            {
                listHistory.Items.Add("Red have won: " + countKTred + ":" + countKTblue);
                listHistory.ForeColor = Color.Red;
            }
            if (countKTblue > countKTred)
            {
                listHistory.Items.Add("Blue have won: " + countKTblue + ":" + countKTred);
                listHistory.ForeColor = Color.Blue;
            }
            labelResult.Text = countKTblue + " : " + countKTred;
            buttonMore.Visible = true;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    listPictureField[i, j].Enabled = false;
                }
            }
        }

        private void ClickButtonMore(object sender, EventArgs e)
        {
            Controller.Instance.ResetAllData();

            for (int i = 0; i < 5; i++)
            {
                checkedListStrategyBlue.SetItemChecked(i, false);
                checkedListStrategyRed.SetItemChecked(i, false);
            }

            typeGame.Enabled = true;
            listLocation.Enabled = true;
            checkedListStrategyBlue.Enabled = true;
            checkedListStrategyRed.Enabled = true;
            buttonPlay.Enabled = true;
            buttonAnew.Visible = false;
            pictureHeadBand.Visible = true;
            buttonMore.Visible = false;
            listLocation.Visible = false;
            checkedListStrategyBlue.Visible = false;
            checkedListStrategyRed.Visible = false;
            buttonPlay.Visible = false;
            labelSelectLocation.Visible = false;
            labelSelectStrategyBlue.Visible = false;
            labelSelectStrategyRed.Visible = false;
            labelScoreBlue.Text = "- 0";
            labelScoreRed.Text = "- 0";
            labelResult.Text = "? : ?";

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    listPictureField[i, j].Visible = false;
                    listPictureField[i, j].Enabled = false;
                }
            }
        }

        #endregion

        public void GameComputerComputerView()
        {
            int[] arrayCountStrategies = new int[2];
            arrayCountStrategies = Controller.Instance.GetCountStrategiesBlueAndRed();

            while (Controller.Instance.countKT != 0)
            {
                System.Threading.Thread.Sleep(100);
                Controller.Instance.countKT = Controller.Instance.StepBlue(arrayCountStrategies[0]);

                UpdateView(Controller.Instance.masGamingLocationPlay);
                if (Controller.Instance.countKT == 0)
                {
                    SummaryEndGame();
                    break;
                }
                
                System.Threading.Thread.Sleep(100);
                Controller.Instance.countKT = Controller.Instance.StepRed(arrayCountStrategies[1]);

                UpdateView(Controller.Instance.masGamingLocationPlay);
                if (Controller.Instance.countKT == 0)
                {
                    SummaryEndGame();
                    break;
                }
            }
        }

        //public void GameComputerNeuronView()
        //{
        //    int[] arrayCountStrategies = new int[2];
        //    arrayCountStrategies = Controller.Instance.GetCountStrategiesBlueAndRed();

        //    while (Controller.Instance.countKT != 0)
        //    {
        //        System.Threading.Thread.Sleep(100);
        //        Controller.Instance.countKT = Controller.Instance.NeuronRed(arrayCountStrategies[1]);
                

        //        UpdateView(Controller.Instance.masGamingLocationPlay);
        //        if (Controller.Instance.countKT == 0)
        //        {
        //            SummaryEndGame();
        //            break;
        //        }

        //        System.Threading.Thread.Sleep(100);

        //        // nano: Neuron                
        //        Controller.Instance.countKT = Controller.Instance.StepRed(arrayCountStrategies[1]);

        //        UpdateView(Controller.Instance.masGamingLocationPlay);
        //        if (Controller.Instance.countKT == 0)
        //        {
        //            SummaryEndGame();
        //            break;
        //        }
        //    }
        //}

        public void GameComputerPeopleView()
        {
            int[] arrayCountStrategies = new int[2];
            arrayCountStrategies = Controller.Instance.GetCountStrategiesBlueAndRed();

            while (Controller.Instance.pictureClick == true)
            {
                if (Controller.Instance.pictureName != "")
                {
                    Controller.Instance.countKT = Controller.Instance.StepPeople();

                    UpdateView(Controller.Instance.masGamingLocationPlay);

                    //ВТОРОЙ
                    System.Threading.Thread.Sleep(200);
                    Controller.Instance.countKT = Controller.Instance.StepBlue(arrayCountStrategies[0]);


                    UpdateView(Controller.Instance.masGamingLocationPlay);
                    if (Controller.Instance.countKT == 0)
                    {
                        //игра окончена
                        SummaryEndGame();
                        break;
                    }


                    Controller.Instance.pictureName = "";
                    Controller.Instance.pictureClick = false;
                }
                if (Controller.Instance.countKT == 0)
                {
                    SummaryEndGame();
                    break;
                }
            }
        }


        private void Click_Picture(object sender, EventArgs e)
        {
            Controller.Instance.pictureName = ((PictureBox)sender).Name;
            Controller.Instance.pictureClick = true;
            GameComputerPeopleView();
        }

        private void UpdateView(int[,] mas)
        {
            int[] arrayCountKT = Controller.Instance.GetCountKT();
            labelScoreBlue.Text = "- " + Convert.ToString(arrayCountKT[1]);
            labelScoreRed.Text = "- " + Convert.ToString(arrayCountKT[2]);
            labelScoreBlue.Update();
            labelScoreRed.Update();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    listPictureField[i, j].Image = new Bitmap(Resources.bed);
                    //0 - пустые клетки
                    //1 - 1 игрок
                    //2 - 2 игрок
                    //3 - КТ чистая
                    //4 - КТ занятая 1
                    //5 - КТ занятая 2
                    //6 - на КТ стоит плохой
                    //7 - на КТ стоит хороший
                    if (mas[i, j] == 0)
                    {
                        listPictureField[i, j].Image = new Bitmap(Resources.pole);
                    }
                    if (mas[i, j] == 1)
                    {
                        listPictureField[i, j].Image = new Bitmap(Resources.bed);
                    }
                    if (mas[i, j] == 2)
                    {
                        listPictureField[i, j].Image = new Bitmap(Resources.good);
                    }
                    if (mas[i, j] == 3)
                    {
                        listPictureField[i, j].Image = new Bitmap(Resources.poleKT);
                    }
                    if (mas[i, j] == 4)
                    {
                        listPictureField[i, j].Image = new Bitmap(Resources.poleKT1);
                    }
                    if (mas[i, j] == 5)
                    {
                        listPictureField[i, j].Image = new Bitmap(Resources.poleKT2);
                    }
                    if (mas[i, j] == 6)
                    {
                        listPictureField[i, j].Image = new Bitmap(Resources.poleKTbed);
                    }
                    if (mas[i, j] == 7)
                    {
                        listPictureField[i, j].Image = new Bitmap(Resources.poleKTgood);
                    }
                    listPictureField[i, j].Update();
                }
            }
        }
    }
}
