using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using GameMushroomPlaces.Model.PureStrategies;
using GameMushroomPlaces.Model.MixedStrategies;

namespace GameMushroomPlaces.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Model
    {
        MixedStrategies.MixedStrategies mixedStrategies = new MixedStrategies.MixedStrategies();
        PlacePlayer placePlayer = new PlacePlayer();

        NearestCleanKT cleanKT = new NearestCleanKT();
        NotYourKT notYourKt = new NotYourKT();
        TailOfRival tailRival = new TailOfRival();
        AttackKTRival attack = new AttackKTRival();
        ProtectYourKT protectYourKT = new ProtectYourKT();

        List<int[,]> resultPureStrategy = new List<int[,]>();

        public int DefinitionCountStartegy(bool[] flagStrategyBlueOrRed)
        {
            int countStrategiesBlueOrRed = 0;
            for (int i = 0; i < flagStrategyBlueOrRed.Count(); i++)
            {
                if (flagStrategyBlueOrRed[i] == true)
                {
                    countStrategiesBlueOrRed++;
                }
            }

            return countStrategiesBlueOrRed;
        }

        public List<int[,]> SelectCountMixedStrategy(int countStrategies, bool[] flagStrategyBlueOrRed, int igrokBlueOrRed, int[,] masGamingLocationPlay,
            int countKTblue, int countKTred, int ran, int compComp, bool flagKT, int countKT)
        {
            return mixedStrategies.DefinitionTypeSelectStartegy(countStrategies, flagStrategyBlueOrRed, igrokBlueOrRed, masGamingLocationPlay,
                    countKTblue, countKTred, ran, compComp, flagKT, countKT);
        }

        public List<int[,]> SelectPureStrategies(int igrokBlueOrRed, int flagStrategy,
            int[,] masGamingLocationPlay, int countKTblue, int countKTred, int ran, int compComp, bool flagKT,
            int countKT)
        {
            switch (flagStrategy)
            {
                case 0:
                    resultPureStrategy = cleanKT.KTcleaner(igrokBlueOrRed, masGamingLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);
                    break;
                case 1:
                    resultPureStrategy = notYourKt.KTcleanerANDalien(igrokBlueOrRed, masGamingLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);
                    break;
                case 2:
                    resultPureStrategy = tailRival.Tail(igrokBlueOrRed, masGamingLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);
                    break;
                case 3:
                    resultPureStrategy = attack.Attack(igrokBlueOrRed, masGamingLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);
                    break;
                case 4:
                    resultPureStrategy = protectYourKT.Protect(igrokBlueOrRed, masGamingLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);
                    break;
            }

            return resultPureStrategy;
        }

        public List<int[,]> PlayerMovement(int pI, int pJ, int player, int[,] arrayLocationPlay, int countKTblue, int countKTred,
                int ran, int compComp, bool flagKT, int countKT)
        {
            return placePlayer.igrokKyda(pI, pJ, player, arrayLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);
        }

        public bool CheckPlayerMovement(int pI, int pJ, int player, int[,] masGamingLocationPlay)
        {
            return placePlayer.proverkaNaXod(pI, pJ, 2, masGamingLocationPlay);
        }
    }
}
