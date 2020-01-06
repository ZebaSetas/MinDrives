using Domain;
using Strategies.Interface;
using System;
using System.Collections.Generic;

namespace Strategies
{
    public class BacktrackingCalculatorMinDrives:IStrategy
    {
        public int CalculateMinDrives(List<HardDrive> hardDrives)
        {
            //sorted by minimum space used, because it avoid entries in the stack            
            bool thereIsAHardDrive = hardDrives != null && hardDrives.Count > 0;
            if (!thereIsAHardDrive) throw new StrategyException("There is no HardDrive");
            HardDriveMarked[] markedHardDrives = BuildMarkedHardDrives(hardDrives);
            bool thereIsOnlyHardDrive = markedHardDrives.Length == 1;
            if (thereIsOnlyHardDrive) return 1;
            else
            {
                hardDrives.Sort();

                bool isThereAnOptimalSolution = CheckOptimalSolution(markedHardDrives);
                if (isThereAnOptimalSolution) return 1;
                else
                {
                    return FindNoOptimalSolution(markedHardDrives);
                }
            }
        }


        private int FindNoOptimalSolution(HardDriveMarked[] markedHardDrives)
        {
            int minimalSolution = markedHardDrives.Length;
            for (int initialPosition = 0; initialPosition < markedHardDrives.Length; initialPosition++)
            {
                int newSolution = FindNoOptimalSolution(markedHardDrives, initialPosition, markedHardDrives.Length);                
                bool solutionIsMinimal = newSolution < minimalSolution;
                if (solutionIsMinimal)
                {
                    minimalSolution = newSolution;
                }
            }
            return minimalSolution;
        }

        private int FindNoOptimalSolution(HardDriveMarked[] hardDrives, int hardDrivePosition, int solution)
        {           
            hardDrives[hardDrivePosition].IsMarked = true;         
            int minSolution = solution;
            bool thereIsASolution = CheckDirectSolution(hardDrives);
            if (thereIsASolution)
            {
                solution--;
                bool isTheBestSolutionNoOptimal = solution == 2;
                if (isTheBestSolutionNoOptimal) return 2;
                else
                {
                    for (int nextPosition = hardDrivePosition+1; nextPosition < hardDrives.Length; nextPosition++)
                    {
                        bool positionIsNotMarked = !hardDrives[nextPosition].IsMarked;
                        if (positionIsNotMarked)
                        {
                            int newSolution = FindNoOptimalSolution(hardDrives, nextPosition, solution);
                            if (newSolution < minSolution)
                            {
                                minSolution = newSolution;
                            }

                        }
                    }
                }         
            }
            hardDrives[hardDrivePosition].IsMarked = false;
            return minSolution;
        }

        private bool CheckDirectSolution(HardDriveMarked[] hardDrives)
        {
            return CheckSolution(hardDrives, false);
        }

        private bool CheckOptimalSolution(HardDriveMarked[] markedHardDrives)
        {

            bool isThereOptimal = false;
            for (int i = 0; i < markedHardDrives.Length; i++)
            {
                markedHardDrives[i].IsMarked = true;
                isThereOptimal = CheckSolution(markedHardDrives, true);
                markedHardDrives[i].IsMarked = false;
                if (isThereOptimal) return true;
            }
            return isThereOptimal;

        }

        private bool CheckSolution(HardDriveMarked[] hardDrives, bool freeSpaceIsMarked)
        {
            int freeSpace = 0;
            int spaceDataToMove = 0;
            foreach (HardDriveMarked hardDrive in hardDrives)
            {
                if (hardDrive.IsMarked == freeSpaceIsMarked)
                {
                    freeSpace += hardDrive.GetFreeSpace();         
                }
                else
                {
                    spaceDataToMove += hardDrive.GetUsedSpace();
                }
            }
            bool isSolution = freeSpace >= spaceDataToMove;
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
