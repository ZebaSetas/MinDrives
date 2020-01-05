using Domain;
using Strategies.Interface;
using System;
using System.Collections.Generic;

namespace Strategies
{
    public class BacktrackingCalculatorMinDrives
    {

        public int Calculate(List<HardDrive> hardDrives)
        {
            bool thereIsAHardDrive = hardDrives != null && hardDrives.Count > 0;
            if (!thereIsAHardDrive) throw new StrategyException("There is no HardDrive");
            bool thereIsOnlyHardDrive = hardDrives.Count == 1;
            if (thereIsOnlyHardDrive) return 1;
            else
            {
               // Solution solution = new Solution(hardDrives);
                HardDriveMarked[] markedHardDrives = BuildMarkedHardDrives(hardDrives);
                //int maxIterations = hardDrives.Count / 2;
                int minSolution = hardDrives.Count;
                for (int position = 0; position < hardDrives.Count; position++)
                {
                    int solution = IsSolutionWithHardDrive(markedHardDrives, position, hardDrives.Count);
                    if (solution < minSolution)
                    {
                        minSolution = solution;
                    }
                }
                return minSolution;
            }
        }

        /* private bool IsSolution(HardDriveAdapter[] hardDrives, Solution solution)
         {

             for (int hardDrivePosition = 0; hardDrivePosition < hardDrives.Length; hardDrivePosition++)
             {
                 bool isSolution = IsSolutionWithHardDrive(hardDrives, hardDrivePosition,amountHardDrives, solution);
                 if (isSolution) return true;                
             }
             return false;

         }*/

        private int IsSolutionWithHardDrive(HardDriveMarked[] hardDrives, int hardDrivePosition, int solution)
        {            
            hardDrives[hardDrivePosition].IsMarked = true;
            /* bool thereIsASolution = CheckReverseSolution(hardDrives, solution);
               if (thereIsASolution)
               {
                   hardDrives[hardDrivePosition].IsMarked = false;
                   return thereIsASolution;
               }
               else
               {*/
            int minSolution = solution;
            bool thereIsASolution = CheckDirectSolution(hardDrives);
            if (thereIsASolution)
            {
                solution--;                
                for (int nextPosition = 0; nextPosition < hardDrives.Length; nextPosition++)
                {
                    if (hardDrivePosition != nextPosition && !hardDrives[nextPosition].IsMarked)
                    {
                        int newSolution = IsSolutionWithHardDrive(hardDrives, nextPosition, solution);
                        if (newSolution < minSolution)
                        {
                            minSolution = newSolution;
                        }
                        
                    }
                }
                          
            }
            hardDrives[hardDrivePosition].IsMarked = false;
            return minSolution;
        }

        /*private bool CheckDirectSolution(HardDriveMarked[] hardDrives, Solution solution)
        {
            return CheckSolution(hardDrives, solution, false);
        }

        private bool CheckReverseSolution(HardDriveMarked[] hardDrives, Solution solution)
        {
            return CheckSolution(hardDrives, solution, true);
        }*/

        private bool CheckDirectSolution(HardDriveMarked[] hardDrives)
        {
            return CheckSolution(hardDrives);
        }

        //private bool CheckSolution(HardDriveMarked[] hardDrives, Solution solution, bool checkIsMarked)
        private bool CheckSolution(HardDriveMarked[] hardDrives)
        {
            int freeSpace = 0;
            int spaceDataToMove = 0;
       //     List<HardDrive> hardDrivesSolution = new List<HardDrive>();
            foreach (HardDriveMarked hardDrive in hardDrives)
            {
                if (!hardDrive.IsMarked)
                {
                    freeSpace += hardDrive.GetFreeSpace();
         //           hardDrivesSolution.Add(hardDrive.HardDrive);
                }
                else
                {
                    spaceDataToMove += hardDrive.GetUsedSpace();
                }
            }
            bool isSolution = freeSpace >= spaceDataToMove;
           /* bool isTheBestSolution = hardDrivesSolution.Count < solution.HardDrives.Count;
            if (isSolution && isTheBestSolution)
            {
                solution.HardDrives.Clear();
                solution.HardDrives = hardDrivesSolution;
            }*/
            return isSolution;
        }

        private HardDriveMarked[] BuildMarkedHardDrives(List<HardDrive> hardDrives)
        {
            HardDriveMarked[] markedHardDrives = new HardDriveMarked[hardDrives.Count];
            int position = 0;
            hardDrives.ForEach(hardDrive =>
            {
                if (hardDrive.IsValid())
                {
                    markedHardDrives[position] = new HardDriveMarked()
                    {
                        HardDrive = hardDrive
                    };
                    position++;
                }
                else
                {
                    throw new StrategyException("There is an invalid HardDrive");
                }
            });
            return markedHardDrives;
        }

    }
}
