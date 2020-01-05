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
                Solution solution = new Solution(hardDrives);
                HardDriveMarked[] markedHardDrives = BuildMarkedHardDrives(hardDrives);
                int maxIterations = hardDrives.Count / 2;
                for (int amountHardDrives = 1; amountHardDrives < maxIterations; amountHardDrives++)
                {
                    bool thereIsASolutionWithAmount = solution.HardDrives.Count == amountHardDrives;
                    if (!thereIsASolutionWithAmount)
                    {
                        bool isSolution = IsSolution(markedHardDrives, amountHardDrives, solution);
                        if (isSolution)
                        {
                            return amountHardDrives;
                        }
                    }
                }
                return solution.HardDrives.Count;
            }
        }

        private bool IsSolution(HardDriveMarked[] hardDrives, int amountHardDrives, Solution solution)
        {

            for (int hardDrivePosition = 0; hardDrivePosition < hardDrives.Length; hardDrivePosition++)
            {
                bool isSolution = IsSolutionWithHardDrive(hardDrives, hardDrivePosition, amountHardDrives, solution);
                if (isSolution) return true;
            }
            return false;

        }

        private bool IsSolutionWithHardDrive(HardDriveMarked[] hardDrives, int hardDrivePosition, int amountHardDrives, Solution solution)
        {

            hardDrives[hardDrivePosition].IsMarked = true;
            amountHardDrives--;
            if (amountHardDrives == 0)
            {
                bool thereIsASolution = CheckDirectSolution(hardDrives, solution);
                if (!thereIsASolution)
                {
                    bool thereIsAReverseSolution = CheckReverseSolution(hardDrives, solution);
                }
                hardDrives[hardDrivePosition].IsMarked = false;
                return thereIsASolution;
            }
            else
            {
                for (int nextPosition = hardDrivePosition + 1; nextPosition < hardDrives.Length; nextPosition++)
                {
                    bool isSolution = IsSolutionWithHardDrive(hardDrives, nextPosition, amountHardDrives, solution);
                    if (isSolution) return true;
                }
                hardDrives[hardDrivePosition].IsMarked = false;
                return false;
            }
        }

        private bool CheckDirectSolution(HardDriveMarked[] hardDrives, Solution solution)
        {
            return CheckSolution(hardDrives, solution, true);
        }

        private bool CheckReverseSolution(HardDriveMarked[] hardDrives, Solution solution)
        {
            return CheckSolution(hardDrives, solution, false);
        }

        private bool CheckSolution(HardDriveMarked[] hardDrives, Solution solution, bool checkIsMarked)
        {
            int freeSpace = 0;
            int spaceDataToMove = 0;
            List<HardDrive> hardDrivesSolution = new List<HardDrive>();
            foreach (HardDriveMarked hardDrive in hardDrives)
            {
                if (hardDrive.IsMarked == checkIsMarked)
                {
                    freeSpace += hardDrive.GetFreeSpace();
                    hardDrivesSolution.Add(hardDrive.HardDrive);
                }
                else
                {
                    spaceDataToMove += hardDrive.GetUsedSpace();
                }
            }
            bool isSolution = freeSpace >= spaceDataToMove;
            bool isTheBestSolution = hardDrivesSolution.Count < solution.HardDrives.Count;
            if (isSolution && isTheBestSolution)
            {
                solution.HardDrives.Clear();
                solution.HardDrives = hardDrivesSolution;
            }
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
