using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMushroomPlaces.Model.PureStrategies;

namespace GameMushroomPlaces.Model.MixedStrategies
{
    public class MixedStrategies
    {
        NearestCleanKT cleanKT = new NearestCleanKT();
        NotYourKT notYourKt = new NotYourKT();
        TailOfRival tailRival = new TailOfRival();
        AttackKTRival attack = new AttackKTRival();
        ProtectYourKT protectYourKT = new ProtectYourKT();
        List<int[,]> resultMixStrategy = new List<int[,]>();
        int[] scoreUpRed = new int[3];
        int[] scoreUpBlue = new int[3];

        private Strategies strategies;

        private enum Strategies
        {
            CLEAR_KT, NO_YOUR_KT, TAIL, ATTACK, PROTECT
        }
        int[,] arrayAllKT, arrayAllPairsKT;

        private Breakpoints breakpoints = new Breakpoints();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="countStrategies">количество стратегий</param>
        /// <param name="flagStrategyBlueOrRed">какие стратегии</param>
        /// <param name="igrokBlueOrRed">какой игрок</param>
        /// <param name="masGamingLocationPlay"></param>
        /// <param name="countKTblue"></param>
        /// <param name="countKTred"></param>
        /// <param name="ran"></param>
        /// <param name="compComp"></param>
        /// <param name="flagKT"></param>
        /// <param name="countKT"></param>
        public List<int[,]> DefinitionTypeSelectStartegy(int countStrategies, bool[] flagStrategyBlueOrRed, int igrokBlueOrRed, int[,] masGamingLocationPlay,
            int countKTblue, int countKTred, int ran, int compComp, bool flagKT, int countKT)
        {
            if (countStrategies == 2)
                SelectionTwoStrategies(flagStrategyBlueOrRed, igrokBlueOrRed, masGamingLocationPlay,
                    countKTblue, countKTred, ran, compComp, flagKT, countKT);
            if (countStrategies == 3)
                SelectionThreeStrategies(flagStrategyBlueOrRed, igrokBlueOrRed, masGamingLocationPlay,
                    countKTblue, countKTred, ran, compComp, flagKT, countKT);
            if (countStrategies == 4)
                SelectionFourStrategies(flagStrategyBlueOrRed, igrokBlueOrRed, masGamingLocationPlay,
                    countKTblue, countKTred, ran, compComp, flagKT, countKT);
            if (countStrategies == 5)
                SelectionFiveStrategies(flagStrategyBlueOrRed, igrokBlueOrRed, masGamingLocationPlay,
                    countKTblue, countKTred, ran, compComp, flagKT, countKT);
            return resultMixStrategy;
        }

        public void ExecutionStrategies(int igrokBlueOrRed, int[,] masGamingLocationPlay, int countKTblue, int countKTred, int ran, int compComp, bool flagKT, int countKT)
        {
            switch (strategies)
            {
                case Strategies.CLEAR_KT:
                    resultMixStrategy = cleanKT.KTcleaner(igrokBlueOrRed, masGamingLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);
                    break;
                case Strategies.NO_YOUR_KT:
                    resultMixStrategy = notYourKt.KTcleanerANDalien(igrokBlueOrRed, masGamingLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);
                    break;
                case Strategies.TAIL:
                    resultMixStrategy = tailRival.Tail(igrokBlueOrRed, masGamingLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);
                    break;
                case Strategies.ATTACK:
                    resultMixStrategy = attack.Attack(igrokBlueOrRed, masGamingLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);
                    break;
                case Strategies.PROTECT:
                    resultMixStrategy = protectYourKT.Protect(igrokBlueOrRed, masGamingLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);
                    break;
            }
        }

        private void SelectionTwoStrategies(bool[] flagStrategyBlueOrRed, int igrokBlueOrRed,
            int[,] masGamingLocationPlay,
            int countKTblue, int countKTred, int ran, int compComp, bool flagKT, int countKT)
        {
            if (flagStrategyBlueOrRed[0] == true && flagStrategyBlueOrRed[1] == true)
                strategies = MixClearAndNoYour(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[0] == true && flagStrategyBlueOrRed[2] == true)
                strategies = MixClearAndTail(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[0] == true && flagStrategyBlueOrRed[3] == true)
                strategies = MixClearAndAttack(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[0] == true && flagStrategyBlueOrRed[4] == true)
                strategies = MixClearAndProtect(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[1] == true && flagStrategyBlueOrRed[2] == true)
                strategies = MixNoYourAndTail(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[1] == true && flagStrategyBlueOrRed[3] == true)
                strategies = MixNoYourAndAttack(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[1] == true && flagStrategyBlueOrRed[4] == true)
                strategies = MixNoYourAndProtect(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[2] == true && flagStrategyBlueOrRed[3] == true)
                strategies = MixTailAndAttack(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[2] == true && flagStrategyBlueOrRed[4] == true)
                strategies = MixTailAndProtect(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[3] == true && flagStrategyBlueOrRed[4] == true)
                strategies = MixAttackAndProtect(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);

            ExecutionStrategies(igrokBlueOrRed, masGamingLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);
        }

        private void SelectionThreeStrategies(bool[] flagStrategyBlueOrRed, int igrokBlueOrRed, int[,] masGamingLocationPlay,
            int countKTblue, int countKTred, int ran, int compComp, bool flagKT, int countKT)
        {
            if (flagStrategyBlueOrRed[0] == true && flagStrategyBlueOrRed[1] == true && flagStrategyBlueOrRed[2] == true)
                strategies = MixClearNoYourTail(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[0] == true && flagStrategyBlueOrRed[1] == true && flagStrategyBlueOrRed[3] == true)
                strategies = MixClearNoYourAttack(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[0] == true && flagStrategyBlueOrRed[1] == true && flagStrategyBlueOrRed[4] == true)
                strategies = MixClearNoYourProtect(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[0] == true && flagStrategyBlueOrRed[2] == true && flagStrategyBlueOrRed[3] == true)
                strategies = MixClearTailAttack(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[0] == true && flagStrategyBlueOrRed[2] == true && flagStrategyBlueOrRed[4] == true)
                strategies = MixClearTailProtect(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[0] == true && flagStrategyBlueOrRed[3] == true && flagStrategyBlueOrRed[4] == true)
                strategies = MixClearAttackProtect(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[1] == true && flagStrategyBlueOrRed[2] == true && flagStrategyBlueOrRed[3] == true)
                strategies = MixNoYourTailAttack(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[1] == true && flagStrategyBlueOrRed[2] == true && flagStrategyBlueOrRed[4] == true)
                strategies = MixNoYourTailProtect(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[1] == true && flagStrategyBlueOrRed[3] == true && flagStrategyBlueOrRed[4] == true)
                strategies = MixNoYourAttackProtect(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[2] == true && flagStrategyBlueOrRed[3] == true && flagStrategyBlueOrRed[4] == true)
                strategies = MixTailAttackProtect(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);

            ExecutionStrategies(igrokBlueOrRed, masGamingLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);
        }
        
        private void SelectionFourStrategies(bool[] flagStrategyBlueOrRed, int igrokBlueOrRed, int[,] masGamingLocationPlay,
            int countKTblue, int countKTred, int ran, int compComp, bool flagKT, int countKT)
        {
            if (flagStrategyBlueOrRed[0] == true && flagStrategyBlueOrRed[1] == true &&
                flagStrategyBlueOrRed[2] == true && flagStrategyBlueOrRed[3] == true)
                strategies = MixClearNoYourTailAttack(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[0] == true && flagStrategyBlueOrRed[1] == true &&
                flagStrategyBlueOrRed[2] == true && flagStrategyBlueOrRed[4] == true)
                strategies = MixClearNoYourTailProtect(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[0] == true && flagStrategyBlueOrRed[2] == true &&
                flagStrategyBlueOrRed[3] == true && flagStrategyBlueOrRed[4] == true)
                strategies = MixClearTailAttackProtect(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[0] == true && flagStrategyBlueOrRed[1] == true &&
                flagStrategyBlueOrRed[3] == true && flagStrategyBlueOrRed[4] == true)
                strategies = MixClearNoYourAttackProtect(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            if (flagStrategyBlueOrRed[1] == true && flagStrategyBlueOrRed[2] == true &&
                flagStrategyBlueOrRed[3] == true && flagStrategyBlueOrRed[4] == true)
                strategies = MixNoYourTailAttackProtect(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);

            ExecutionStrategies(igrokBlueOrRed, masGamingLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);
        }

        private void SelectionFiveStrategies(bool[] flagStrategyBlueOrRed, int igrokBlueOrRed, int[,] masGamingLocationPlay,
            int countKTblue, int countKTred, int ran, int compComp, bool flagKT, int countKT)
        {
            strategies = MixClearNoYourTailAttackProtect(masGamingLocationPlay, igrokBlueOrRed, countKTblue, countKTred);
            ExecutionStrategies(igrokBlueOrRed, masGamingLocationPlay, countKTblue, countKTred, ran, compComp, flagKT, countKT);
        }

        //не свои контрольные точки
        private bool DeadBreakpoints(int[,] masGamingLocationPlay)
        {
            int[,] arrayDeadKT = breakpoints.ExistenceDeadBreakpoints(masGamingLocationPlay, 66);
            if (arrayDeadKT.Length > 0) return true;
            else return false;
        }

        private bool countScore(int player, int countKTblue, int countKTred)
        {
            //количество очков
            if (player == 1 && (countKTred - countKTblue >= 2))
            {
                return true;
            }
            else
            {
                if (player == 2 && (countKTblue - countKTred >= 2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool nearFiveKT(int player, int[,] arrayAllKT, int[,] arrayAllPairsKT)
        {
            int countNoYourKTNear = 0;
            
            for (int i = 0; i < arrayAllPairsKT.Length / 4; i++)
            {
                if (arrayAllKT[arrayAllPairsKT[i, 0], 2] == player ||
                    arrayAllKT[arrayAllPairsKT[i, 1], 2] == player)
                {
                    if (arrayAllPairsKT[i, 2] <= 3)
                    {
                        countNoYourKTNear++;
                    }
                }
            }
            if (countNoYourKTNear >= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool nearKTOpponenta(int player, int[,] arrayAllKT, int[,] arrayAllPairsKT)
        {
            bool nearNoYourKT = false;
            int lenghtKT = 20;
            int[] typeFindKT = new int[2];
            if (player == 1)
            {
                typeFindKT[0] = 5;
                typeFindKT[1] = 7;
            }
            else
            {
                typeFindKT[0] = 4;
                typeFindKT[1] = 6;
            }
            for (int i = 0; i < arrayAllPairsKT.Length / 4; i++)
            {
                if (arrayAllKT[arrayAllPairsKT[i, 0], 2] == player ||
                    arrayAllKT[arrayAllPairsKT[i, 1], 2] == player)
                {
                    if (arrayAllKT[arrayAllPairsKT[i, 0], 2] == typeFindKT[0] ||
                        arrayAllKT[arrayAllPairsKT[i, 1], 2] == typeFindKT[0] ||
                        arrayAllKT[arrayAllPairsKT[i, 0], 2] == typeFindKT[1] ||
                        arrayAllKT[arrayAllPairsKT[i, 1], 2] == typeFindKT[1])
                    {
                        if (lenghtKT > arrayAllPairsKT[i, 3])
                        {
                            lenghtKT = arrayAllPairsKT[i, 3];
                        }
                    }
                }
            }
            if (lenghtKT <= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //чистые

        //атака

        private bool PlayerNearKTOpponent(int player, int[,] arrayAllKT, int[,] arrayAllPairsKT)
        {
            int lenghtToKTPlayer = 20;
            int lenghtToKTOpponent = 20;
            for (int i = 0; i < arrayAllPairsKT.Length / 4; i++)
            {
                if (player == 1)
                {
                    //если первый игрок
                    if (arrayAllKT[arrayAllPairsKT[i, 0], 3] == 1 || arrayAllKT[arrayAllPairsKT[i, 1], 3] == 1 ||
                        arrayAllKT[arrayAllPairsKT[i, 0], 3] == 6 || arrayAllKT[arrayAllPairsKT[i, 1], 3] == 6)
                    {
                        if (arrayAllKT[arrayAllPairsKT[i, 0], 3] == 5 || arrayAllKT[arrayAllPairsKT[i, 1], 3] == 5)
                        {
                            if (lenghtToKTOpponent > arrayAllPairsKT[i, 2])
                            {
                                lenghtToKTOpponent = arrayAllPairsKT[i, 2];
                            }
                        }
                    }
                    //если второй игрок
                    if (arrayAllKT[arrayAllPairsKT[i, 0], 3] == 2 || arrayAllKT[arrayAllPairsKT[i, 1], 3] == 2 ||
                        arrayAllKT[arrayAllPairsKT[i, 0], 3] == 7 || arrayAllKT[arrayAllPairsKT[i, 1], 3] == 7)
                    {
                        if (arrayAllKT[arrayAllPairsKT[i, 0], 3] == 4 || arrayAllKT[arrayAllPairsKT[i, 1], 3] == 4)
                        {
                            if (lenghtToKTPlayer > arrayAllPairsKT[i, 2])
                            {
                                lenghtToKTPlayer = arrayAllPairsKT[i, 2];
                            }
                        }
                    }
                }
                else
                {
                    //если первый игрок
                    if (arrayAllKT[arrayAllPairsKT[i, 0], 3] == 1 || arrayAllKT[arrayAllPairsKT[i, 1], 3] == 1 ||
                        arrayAllKT[arrayAllPairsKT[i, 0], 3] == 6 || arrayAllKT[arrayAllPairsKT[i, 1], 3] == 6)
                    {
                        if (arrayAllKT[arrayAllPairsKT[i, 0], 3] == 5 || arrayAllKT[arrayAllPairsKT[i, 1], 3] == 5)
                        {
                            if (lenghtToKTPlayer > arrayAllPairsKT[i, 2])
                            {
                                lenghtToKTPlayer = arrayAllPairsKT[i, 2];
                            }
                        }
                    }
                    //если второй игрок
                    if (arrayAllKT[arrayAllPairsKT[i, 0], 3] == 2 || arrayAllKT[arrayAllPairsKT[i, 1], 3] == 2 ||
                        arrayAllKT[arrayAllPairsKT[i, 0], 3] == 7 || arrayAllKT[arrayAllPairsKT[i, 1], 3] == 7)
                    {
                        if (arrayAllKT[arrayAllPairsKT[i, 0], 3] == 4 || arrayAllKT[arrayAllPairsKT[i, 1], 3] == 4)
                        {
                            if (lenghtToKTOpponent > arrayAllPairsKT[i, 2])
                            {
                                lenghtToKTOpponent = arrayAllPairsKT[i, 2];
                            }
                        }
                    }
                }
            }
            if (lenghtToKTPlayer > lenghtToKTOpponent) return true;
            else return false;
        }

        //охрана

        private bool OneClearKTOpponentWin(int[,] arrayAllKT)
        {
            int countClearKT = 0;
            for (int i = 0; i < arrayAllKT.Length / 4; i++)
            {
                if (arrayAllKT[i, 2] == 3)
                {
                    countClearKT++;
                }
            }
            if (countClearKT == 1) return true;
            return false;
        }

        //хвост
        private bool ScoreUPOpponent(int player, int countKTblue, int countKTred)
        {
            if (player == 1)
            {
                if ((scoreUpRed[2] - scoreUpRed[0]) == 2)
                {
                    SetArrayScoreUpBlueOrRed(player, countKTblue, countKTred);
                    return true;
                }
                else
                {
                    SetArrayScoreUpBlueOrRed(player, countKTblue, countKTred);
                    return false;
                }
            }
            else
            {
                if ((scoreUpBlue[2] - scoreUpBlue[0]) == 2)
                {
                    SetArrayScoreUpBlueOrRed(player, countKTblue, countKTred);
                    return true;
                }
                else
                {
                    SetArrayScoreUpBlueOrRed(player, countKTblue, countKTred);
                    return false;
                }
            }
        }

        private void SetArrayScoreUpBlueOrRed(int player, int countKTblue, int countKTred)
        {
            if (player == 1)
            {
                for (int i = 0; i < scoreUpRed.Length - 1; i++)
                {
                    scoreUpRed[i] = scoreUpRed[i + 1];
                    if (i == 2)
                    {
                        scoreUpRed[scoreUpRed.Length - 1] = countKTred;
                    }
                }
            }
            else
            {
                for (int i = 0; i < scoreUpBlue.Length - 1; i++)
                {
                    scoreUpBlue[i] = scoreUpBlue[i + 1];
                    if (i == 2)
                    {
                        scoreUpBlue[scoreUpBlue.Length - 1] = countKTblue;
                    }
                }
            }
        }

        private bool NearOpponent(int[,] arrayGamingLocation)
        {
            breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
            int[,] arrayAllKT = breakpoints.GetArrayAllKT();
            int lenght = 0;

            for (int i = 0; i < arrayAllKT.Length / 4; i++)
            {
                for (int j = 0; j < arrayAllKT.Length / 4; j++)
                {
                    if ((arrayAllKT[i, 2] == 1 && arrayAllKT[j, 2] == 2) ||
                        (arrayAllKT[i, 2] == 2 && arrayAllKT[j, 2] == 1))
                    {
                        lenght = Math.Abs(arrayAllKT[i, 0] - arrayAllKT[j, 0]);
                        lenght += Math.Abs(arrayAllKT[i, 1] - arrayAllKT[j, 1]);
                        if (lenght <= 5) return true;
                    }
                }
            }
            if (lenght <= 5) return true;
            else return false;
        }

        // Two strategies
        private Strategies MixClearAndNoYour(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
            //мертвая контрольная точка
            if (DeadBreakpoints(arrayGamingLocation) == true) return Strategies.NO_YOUR_KT;
            else
            {
                //количество очков
                if (countScore(player, countKTblue, countKTred) == true) return Strategies.NO_YOUR_KT;
                else
                {
                    breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                    //5 КТ
                    arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                    breakpoints.GetArrayLeghtPairsKT(66, player);
                    arrayAllPairsKT = breakpoints.GetArrayPairsKT(); //пары с длинами

                    if (nearFiveKT(player, arrayAllKT, arrayAllPairsKT) == true) return Strategies.NO_YOUR_KT;
                    else
                    {
                        //ближе КТ соперника
                        if (nearKTOpponenta(player, arrayAllKT, arrayAllPairsKT) == true) return Strategies.NO_YOUR_KT;
                        else return Strategies.CLEAR_KT;
                    }
                }
            }
        }
        private Strategies MixClearAndTail(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            if (ScoreUPOpponent(player, countKTblue, countKTred) == true) return Strategies.TAIL;
            else
            {
                if (NearOpponent(arrayGamingLocation) == true) return Strategies.TAIL;
                else return Strategies.CLEAR_KT;
            }
        }
        private Strategies MixClearAndAttack(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            //игрок проигрывает
            if ((player == 1 && (countKTred > countKTblue)) ||
                (player == 2 && (countKTred < countKTblue))) return Strategies.ATTACK;
            else
            {
                breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                //KT игрока дальше от соперника
                arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                breakpoints.GetArrayLeghtPairsKT(66, player);
                arrayAllPairsKT = breakpoints.GetArrayPairsKT(); //пары с длинами

                if (PlayerNearKTOpponent(player, arrayAllKT, arrayAllPairsKT)) return Strategies.ATTACK;
                else return Strategies.CLEAR_KT;
            }
        }
        private Strategies MixClearAndProtect(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            //игрок проигрывает
            if ((player == 1 && (countKTred > countKTblue)) ||
                (player == 2 && (countKTred < countKTblue))) return Strategies.PROTECT;
            else
            {
                if (NearOpponent(arrayGamingLocation) == true) return Strategies.PROTECT;
                else
                {
                    breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                    arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                    if (OneClearKTOpponentWin(arrayAllKT) == true) return Strategies.CLEAR_KT;
                    else return Strategies.PROTECT;
                }
            }
        }
        private Strategies MixNoYourAndTail(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            if (ScoreUPOpponent(player, countKTblue, countKTred) == true) return Strategies.TAIL;
            else
            {
                if (NearOpponent(arrayGamingLocation) == true) return Strategies.TAIL;
                else return Strategies.NO_YOUR_KT;
            }
        }
        private Strategies MixNoYourAndAttack(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            //игрок проигрывает
            if ((player == 1 && (countKTred > countKTblue)) ||
                (player == 2 && (countKTred < countKTblue))) return Strategies.ATTACK;
            else
            {
                breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                //KT игрока дальше от соперника
                arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                breakpoints.GetArrayLeghtPairsKT(66, player);
                arrayAllPairsKT = breakpoints.GetArrayPairsKT(); //пары с длинами

                if (PlayerNearKTOpponent(player, arrayAllKT, arrayAllPairsKT)) return Strategies.ATTACK;
                else return Strategies.NO_YOUR_KT;
            }
        }
        private Strategies MixNoYourAndProtect(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            //игрок проигрывает
            if ((player == 1 && (countKTred > countKTblue)) ||
                (player == 2 && (countKTred < countKTblue))) return Strategies.PROTECT;
            else
            {
                if (NearOpponent(arrayGamingLocation) == true) return Strategies.PROTECT;
                else return Strategies.NO_YOUR_KT;
            }
        }
        private Strategies MixTailAndAttack(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            if (ScoreUPOpponent(player, countKTblue, countKTred) == true && NearOpponent(arrayGamingLocation) == true) return Strategies.TAIL;
            else return Strategies.ATTACK;
        }
        private Strategies MixTailAndProtect(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            if (ScoreUPOpponent(player, countKTblue, countKTred) == true && NearOpponent(arrayGamingLocation) == true) return Strategies.TAIL;
            else return Strategies.PROTECT;
        }
        private Strategies MixAttackAndProtect(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            //игрок проигрывает
            if ((player == 1 && (countKTred > countKTblue)) ||
                (player == 2 && (countKTred < countKTblue))) return Strategies.ATTACK;
            else
            {
                breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                //KT игрока дальше от соперника
                arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                breakpoints.GetArrayLeghtPairsKT(66, player);
                arrayAllPairsKT = breakpoints.GetArrayPairsKT(); //пары с длинами

                if (PlayerNearKTOpponent(player, arrayAllKT, arrayAllPairsKT)) return Strategies.ATTACK;
                else return Strategies.PROTECT;
            }
        }

        // Three strategies
        private Strategies MixClearNoYourTail(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            if (ScoreUPOpponent(player, countKTblue, countKTred) == true && NearOpponent(arrayGamingLocation) == true) return Strategies.TAIL;
            else
            {
                //мертвая контрольная точка
                if (DeadBreakpoints(arrayGamingLocation) == true) return Strategies.NO_YOUR_KT;
                else
                {
                    //количество очков
                    if (countScore(player, countKTblue, countKTred) == true) return Strategies.NO_YOUR_KT;
                    else
                    {
                        breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                        //5 КТ
                        arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                        breakpoints.GetArrayLeghtPairsKT(66, player);
                        arrayAllPairsKT = breakpoints.GetArrayPairsKT(); //пары с длинами

                        if (nearFiveKT(player, arrayAllKT, arrayAllPairsKT) == true) return Strategies.NO_YOUR_KT;
                        else
                        {
                            //ближе КТ соперника
                            if (nearKTOpponenta(player, arrayAllKT, arrayAllPairsKT) == true) return Strategies.NO_YOUR_KT;
                            else return Strategies.CLEAR_KT;
                        }
                    }
                }
            }
        }
        private Strategies MixClearNoYourAttack(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            //игрок проигрывает
            if ((player == 1 && (countKTred > countKTblue)) ||
                (player == 2 && (countKTred < countKTblue))) return Strategies.ATTACK;
            else
            {
                breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                //KT игрока дальше от соперника
                arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                breakpoints.GetArrayLeghtPairsKT(66, player);
                arrayAllPairsKT = breakpoints.GetArrayPairsKT(); //пары с длинами

                if (PlayerNearKTOpponent(player, arrayAllKT, arrayAllPairsKT)) return Strategies.ATTACK;
                else
                {
                    //мертвая контрольная точка
                    if (DeadBreakpoints(arrayGamingLocation) == true) return Strategies.NO_YOUR_KT;
                    else
                    {
                        //количество очков
                        if (countScore(player, countKTblue, countKTred) == true) return Strategies.NO_YOUR_KT;
                        else
                        {
                            breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                            //5 КТ
                            arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                            breakpoints.GetArrayLeghtPairsKT(66, player);
                            arrayAllPairsKT = breakpoints.GetArrayPairsKT(); //пары с длинами

                            if (nearFiveKT(player, arrayAllKT, arrayAllPairsKT) == true) return Strategies.NO_YOUR_KT;
                            else
                            {
                                //ближе КТ соперника
                                if (nearKTOpponenta(player, arrayAllKT, arrayAllPairsKT) == true) return Strategies.NO_YOUR_KT;
                                else return Strategies.CLEAR_KT;
                            }
                        }
                    }
                }
            }
        }
        private Strategies MixClearNoYourProtect(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            //игрок проигрывает
            if ((player == 1 && (countKTred > countKTblue)) ||
                (player == 2 && (countKTred < countKTblue))) return Strategies.PROTECT;
            else
            {
                if (NearOpponent(arrayGamingLocation) == true) return Strategies.PROTECT;
                else
                {
                    breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                    arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                    if (OneClearKTOpponentWin(arrayAllKT) == true)
                    {
                        //мертвая контрольная точка
                        if (DeadBreakpoints(arrayGamingLocation) == true) return Strategies.NO_YOUR_KT;
                        else
                        {
                            //количество очков
                            if (countScore(player, countKTblue, countKTred) == true) return Strategies.NO_YOUR_KT;
                            else
                            {
                                breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                                //5 КТ
                                arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                                breakpoints.GetArrayLeghtPairsKT(66, player);
                                arrayAllPairsKT = breakpoints.GetArrayPairsKT(); //пары с длинами

                                if (nearFiveKT(player, arrayAllKT, arrayAllPairsKT) == true) return Strategies.NO_YOUR_KT;
                                else
                                {
                                    //ближе КТ соперника
                                    if (nearKTOpponenta(player, arrayAllKT, arrayAllPairsKT) == true) return Strategies.NO_YOUR_KT;
                                    else return Strategies.CLEAR_KT;
                                }
                            }
                        }
                    }
                    else return Strategies.PROTECT;
                }
            }
        }
        private Strategies MixClearTailAttack(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            if (ScoreUPOpponent(player, countKTblue, countKTred) == true && NearOpponent(arrayGamingLocation) == true) return Strategies.TAIL;
            else
            {
                //игрок проигрывает
                if ((player == 1 && (countKTred > countKTblue)) ||
                    (player == 2 && (countKTred < countKTblue))) return Strategies.ATTACK;
                else
                {
                    breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                    //KT игрока дальше от соперника
                    arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                    breakpoints.GetArrayLeghtPairsKT(66, player);
                    arrayAllPairsKT = breakpoints.GetArrayPairsKT(); //пары с длинами

                    if (PlayerNearKTOpponent(player, arrayAllKT, arrayAllPairsKT)) return Strategies.ATTACK;
                    else return Strategies.CLEAR_KT;
                }
            }
        }
        private Strategies MixClearTailProtect(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            if (ScoreUPOpponent(player, countKTblue, countKTred) == true && NearOpponent(arrayGamingLocation) == true) return Strategies.TAIL;
            else
            {
                //игрок проигрывает
                if ((player == 1 && (countKTred > countKTblue)) ||
                    (player == 2 && (countKTred < countKTblue))) return Strategies.PROTECT;
                else
                {
                    if (NearOpponent(arrayGamingLocation) == true) return Strategies.PROTECT;
                    else
                    {
                        breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                        arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                        if (OneClearKTOpponentWin(arrayAllKT) == true) return Strategies.CLEAR_KT;
                        else return Strategies.PROTECT;
                    }
                }
            }
        }
        private Strategies MixClearAttackProtect(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            //игрок проигрывает
            if ((player == 1 && (countKTred > countKTblue)) ||
                (player == 2 && (countKTred < countKTblue)) && NearOpponent(arrayGamingLocation) == true) return Strategies.PROTECT;
            else
            {
                breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                //KT игрока дальше от соперника
                arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                breakpoints.GetArrayLeghtPairsKT(66, player);
                arrayAllPairsKT = breakpoints.GetArrayPairsKT(); //пары с длинами

                if (PlayerNearKTOpponent(player, arrayAllKT, arrayAllPairsKT)) return Strategies.ATTACK;
                else
                {
                    //игрок проигрывает
                    if ((player == 1 && (countKTred > countKTblue)) ||
                        (player == 2 && (countKTred < countKTblue))) return Strategies.ATTACK;
                    else
                    {
                        breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                        arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                        if (OneClearKTOpponentWin(arrayAllKT) == true) return Strategies.CLEAR_KT;
                        else return Strategies.PROTECT;
                    }
                }
            }
        }
        private Strategies MixNoYourTailAttack(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            if (ScoreUPOpponent(player, countKTblue, countKTred) == true && NearOpponent(arrayGamingLocation) == true) return Strategies.TAIL;
            else
            {
                //игрок проигрывает
                if ((player == 1 && (countKTred > countKTblue)) ||
                    (player == 2 && (countKTred < countKTblue))) return Strategies.ATTACK;
                else
                {
                    breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                    //KT игрока дальше от соперника
                    arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                    breakpoints.GetArrayLeghtPairsKT(66, player);
                    arrayAllPairsKT = breakpoints.GetArrayPairsKT(); //пары с длинами

                    if (PlayerNearKTOpponent(player, arrayAllKT, arrayAllPairsKT)) return Strategies.ATTACK;
                    else return Strategies.NO_YOUR_KT;
                }
            }
        }
        private Strategies MixNoYourTailProtect(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            if (ScoreUPOpponent(player, countKTblue, countKTred) == true && NearOpponent(arrayGamingLocation) == true) return Strategies.TAIL;
            else
            {
                //игрок проигрывает
                if ((player == 1 && (countKTred > countKTblue)) ||
                    (player == 2 && (countKTred < countKTblue))) return Strategies.PROTECT;
                else
                {
                    if (NearOpponent(arrayGamingLocation) == true) return Strategies.PROTECT;
                    else return Strategies.NO_YOUR_KT;
                }
            }
        }
        private Strategies MixNoYourAttackProtect(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            //игрок проигрывает
            if ((player == 1 && (countKTred > countKTblue)) ||
                (player == 2 && (countKTred < countKTblue)) && NearOpponent(arrayGamingLocation) == true) return Strategies.PROTECT; 
            else
            {
                breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                //KT игрока дальше от соперника
                arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                breakpoints.GetArrayLeghtPairsKT(66, player);
                arrayAllPairsKT = breakpoints.GetArrayPairsKT(); //пары с длинами

                if (PlayerNearKTOpponent(player, arrayAllKT, arrayAllPairsKT)) return Strategies.ATTACK;
                else
                {
                    //игрок проигрывает
                    if ((player == 1 && (countKTred > countKTblue)) ||
                        (player == 2 && (countKTred < countKTblue))) return Strategies.ATTACK;
                    else
                    {
                        if (NearOpponent(arrayGamingLocation) == true) return Strategies.PROTECT;
                        else return Strategies.NO_YOUR_KT;
                    }
                }
            }
        }
        private Strategies MixTailAttackProtect(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            if (ScoreUPOpponent(player, countKTblue, countKTred) == true && NearOpponent(arrayGamingLocation) == true) return Strategies.TAIL;
            else
            {
                //игрок проигрывает
                if ((player == 1 && (countKTred > countKTblue)) ||
                    (player == 2 && (countKTred < countKTblue))) return Strategies.ATTACK;
                else
                {
                    breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                    //KT игрока дальше от соперника
                    arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                    breakpoints.GetArrayLeghtPairsKT(66, player);
                    arrayAllPairsKT = breakpoints.GetArrayPairsKT(); //пары с длинами

                    if (PlayerNearKTOpponent(player, arrayAllKT, arrayAllPairsKT)) return Strategies.ATTACK;
                    else return Strategies.PROTECT;
                }
            }
        }

        // Four strategies
        private Strategies MixClearNoYourTailAttack(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            if (ScoreUPOpponent(player, countKTblue, countKTred) == true && NearOpponent(arrayGamingLocation) == true) return Strategies.TAIL;
            else
            {
                //игрок проигрывает
                if ((player == 1 && (countKTred > countKTblue)) ||
                    (player == 2 && (countKTred < countKTblue))) return Strategies.ATTACK;
                else
                {
                    breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                    //KT игрока дальше от соперника
                    arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                    breakpoints.GetArrayLeghtPairsKT(66, player);
                    arrayAllPairsKT = breakpoints.GetArrayPairsKT(); //пары с длинами

                    if (PlayerNearKTOpponent(player, arrayAllKT, arrayAllPairsKT)) return Strategies.ATTACK;
                    else
                    {
                        return MixClearAndNoYour(arrayGamingLocation, player, countKTblue, countKTred);
                    }
                }
            }
        }
        private Strategies MixClearNoYourTailProtect(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            if (ScoreUPOpponent(player, countKTblue, countKTred) == true && NearOpponent(arrayGamingLocation) == true) return Strategies.TAIL;
            else
            {
                //игрок проигрывает
                if ((player == 1 && (countKTred > countKTblue)) ||
                    (player == 2 && (countKTred < countKTblue))) return Strategies.PROTECT;
                else
                {
                    if (NearOpponent(arrayGamingLocation) == true) return Strategies.PROTECT;
                    else
                    {
                        return MixClearAndNoYour(arrayGamingLocation, player, countKTblue, countKTred);
                    }
                }
            }
        }
        private Strategies MixClearTailAttackProtect(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            if (ScoreUPOpponent(player, countKTblue, countKTred) == true && NearOpponent(arrayGamingLocation) == true) return Strategies.TAIL;
            else
            {
                //игрок проигрывает
                if ((player == 1 && (countKTred > countKTblue)) ||
                    (player == 2 && (countKTred < countKTblue)) && NearOpponent(arrayGamingLocation) == true) return Strategies.PROTECT; 
                else
                {
                    breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                    //KT игрока дальше от соперника
                    arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                    breakpoints.GetArrayLeghtPairsKT(66, player);
                    arrayAllPairsKT = breakpoints.GetArrayPairsKT(); //пары с длинами

                    if (PlayerNearKTOpponent(player, arrayAllKT, arrayAllPairsKT)) return Strategies.ATTACK;
                    else
                    {
                        //игрок проигрывает
                        if ((player == 1 && (countKTred > countKTblue)) ||
                            (player == 2 && (countKTred < countKTblue))) return Strategies.ATTACK;
                        else
                        {
                            breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                            arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                            if (OneClearKTOpponentWin(arrayAllKT) == true) return Strategies.CLEAR_KT;
                            else return Strategies.PROTECT;
                        }
                    }
                }
            }
        }
        private Strategies MixClearNoYourAttackProtect(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            //игрок проигрывает
            if ((player == 1 && (countKTred > countKTblue)) ||
                (player == 2 && (countKTred < countKTblue))) return Strategies.ATTACK;
            else
            {
                breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                //KT игрока дальше от соперника
                arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                breakpoints.GetArrayLeghtPairsKT(66, player);
                arrayAllPairsKT = breakpoints.GetArrayPairsKT(); //пары с длинами

                if (PlayerNearKTOpponent(player, arrayAllKT, arrayAllPairsKT)) return Strategies.ATTACK;
                else
                {
                    //игрок проигрывает
                    if ((player == 1 && (countKTred > countKTblue)) ||
                        (player == 2 && (countKTred < countKTblue))) return Strategies.PROTECT;
                    else
                    {
                        if (NearOpponent(arrayGamingLocation) == true) return Strategies.PROTECT;
                        else return MixClearAndNoYour(arrayGamingLocation, player, countKTblue, countKTred);
                    }
                }
            }
        }
        private Strategies MixNoYourTailAttackProtect(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            if (ScoreUPOpponent(player, countKTblue, countKTred) == true && NearOpponent(arrayGamingLocation) == true)
                return Strategies.TAIL;
            else return MixNoYourAttackProtect(arrayGamingLocation, player, countKTblue, countKTred);
        }

        // Five strategies
        private Strategies MixClearNoYourTailAttackProtect(int[,] arrayGamingLocation, int player, int countKTblue, int countKTred)
        {
            if (ScoreUPOpponent(player, countKTblue, countKTred) == true && NearOpponent(arrayGamingLocation) == true)
                return Strategies.TAIL;
            else
            {
                //игрок проигрывает
                if ((player == 1 && (countKTred > countKTblue)) ||
                    (player == 2 && (countKTred < countKTblue)) && NearOpponent(arrayGamingLocation) == true) return Strategies.PROTECT;
                else
                {
                    breakpoints.GetArrayAllBreakpoints(arrayGamingLocation);
                    //KT игрока дальше от соперника
                    arrayAllKT = breakpoints.GetArrayAllKT(); //пары с типами
                    breakpoints.GetArrayLeghtPairsKT(66, player);
                    arrayAllPairsKT = breakpoints.GetArrayPairsKT(); //пары с длинами

                    if (PlayerNearKTOpponent(player, arrayAllKT, arrayAllPairsKT)) return Strategies.ATTACK;
                    else
                    {
                        //игрок проигрывает
                        if ((player == 1 && (countKTred > countKTblue)) ||
                            (player == 2 && (countKTred < countKTblue))) return Strategies.ATTACK;
                        else
                        {
                            if (NearOpponent(arrayGamingLocation) == true) return Strategies.PROTECT;
                            else return MixClearAndNoYour(arrayGamingLocation, player, countKTblue, countKTred);
                        }
                    }
                }
            }
        }
    }
}
