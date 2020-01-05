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
                HardDriveMarked[] markedHardDrives = BuildMarkedHardDrives(hardDrives);
                int minHardDrives = hardDrives.Count;
                for (int position=0;position<markedHardDrives.Length;position++)
                {
                    List<HardDriveMarked> hardDriveSolution = CheckSolutionByHardDrive(markedHardDrives, position);
                    if(hardDriveSolution != null && hardDriveSolution.Count>0 )
                    {
                        if (hardDriveSolution.Count < minHardDrives)
                        {
                            minHardDrives = hardDriveSolution.Count;
                        }
                    }
                }
                return minHardDrives;
            }
            
        }

        private List<HardDriveMarked> CheckSolutionByHardDrive(HardDriveMarked[] hardDrives, int position)
        {
            List<HardDriveMarked> solution = new List<HardDriveMarked>();
            hardDrives[position].IsMarked = true;
            for(int i = 0; i < hardDrives.Length; i++)
            {
                List<HardDriveMarked> partialSolution = GetSolution(position, solution, hardDrives);                
                if ((solution.Count == 0) || (partialSolution.Count < solution.Count))
                {
                    solution = partialSolution;
                }

            }
            hardDrives[position].IsMarked = false;
            return solution;
        }

        private List<HardDriveMarked> GetSolution(int position, List<HardDriveMarked> partialSolution, HardDriveMarked[] hardDrives)
        {
            List<HardDriveMarked> solution = CopySolution(partialSolution);
            solution.Add(hardDrives[position]);
            if (solution.Count == hardDrives.Length)
            {                
                return solution;
            }
            else
            {                
                hardDrives[position].IsMarked = true;
                if (CheckIsSolution(hardDrives))
                {
                    hardDrives[position].IsMarked = false;
                    return solution;
                }
                else
                {
                    List<HardDriveMarked> newSolution = new List<HardDriveMarked>();
                    for (int newPosition= 0; newPosition < hardDrives.Length; newPosition++)
                    {
                        
                        if (hardDrives[newPosition].IsMarked == false)
                        {
                            hardDrives[newPosition].IsMarked = true;
                            List<HardDriveMarked> maybeSolution = GetSolution(newPosition,solution,hardDrives);
                            if ((newSolution.Count == 0) || (newSolution.Count > maybeSolution.Count))                                 
                            {
                                newSolution = maybeSolution;
                            }
                            hardDrives[position].IsMarked = false;
                        }

                    }                    
                    return newSolution;
                }                
            }
            

        }

        private List<HardDriveMarked> CopySolution(List<HardDriveMarked> solution)
        {
            List<HardDriveMarked> newSolution = new List<HardDriveMarked>();
            foreach(HardDriveMarked hardDrive in solution)
            {
                newSolution.Add(hardDrive);
            }
            return newSolution;
        }

        private bool CheckIsSolution(HardDriveMarked[] hardDrives)
        {
            int freeSpace = 0;
            int spaceDataToMove = 0;
            List<HardDrive> hardDrivesSolution = new List<HardDrive>();
            foreach (HardDriveMarked hardDrive in hardDrives)
            {
                if (hardDrive.IsMarked)
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
            return isSolution;
        }

        private HardDriveMarked[] BuildMarkedHardDrives(List<HardDrive> hardDrives)
        {
            HardDriveMarked[] markedHardDrives = new HardDriveMarked[hardDrives.Count];
            int position = 0;
            hardDrives.ForEach(hardDrive =>
            {
                markedHardDrives[position] = new HardDriveMarked()
                {
                    HardDrive = hardDrive
                };
                position++;
               
            });
            return markedHardDrives;
        }
    }
}
