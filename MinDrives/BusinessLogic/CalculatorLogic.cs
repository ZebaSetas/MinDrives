using BusinessLogic.Interface;
using Domain;
using Strategies;
using Strategies.Interface;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class CalculatorLogic : ICalculatorLogic
    {
        public int MinDrives(int[]used, int[]total)
        {
            ThrowExceptionIfListAreInvalid(used,total);            
            return MinDrives(used,total, new BacktrackingCalculatorMinDrives());
        }

        public int MinDrives(int[] used, int[] total, StrategyThemplate strategy)
        {
           List<HardDrive> hardDrives = BuildHardDrives(used, total);            
            return strategy.CalculateMinDrives(hardDrives);
        }

        private void ThrowExceptionIfListAreInvalid(int[] used, int[] total)
        {
            bool thereIsListNull = used == null || total == null;
            if(thereIsListNull) throw new BusinessLogicException("Error! List of used or total is null");
            bool theListsAreNotSameSize = used.Length != total.Length;
            if(theListsAreNotSameSize) throw new BusinessLogicException("Error! List of used or total are not the same size");
        }

        private List<HardDrive> BuildHardDrives(int[] used, int[] total)
        {
            List<HardDrive> hardDrives = new List<HardDrive>();
            int nextId = 0;
            for (int i = 0; i < used.Length; i++)
            {
                HardDrive hardDrive = new HardDrive()
                {
                    UsedSpace = used[i],
                    MaxSpace = total[i],
                    Id = nextId
                };                      
                if (!hardDrive.IsValid())                
                    throw new BusinessLogicException("Error! HardDrive with " + used[i] + 
                                                     " for used value and " + total[i] + 
                                                     " for total value is not valid");
                
                hardDrives.Add(hardDrive);
                nextId++;
            }
            return hardDrives;
        }
    }
}
