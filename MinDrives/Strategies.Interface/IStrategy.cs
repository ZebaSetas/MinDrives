using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Strategies.Interface
{
    public interface IStrategy
    {
        int CalculateMinDrives(List<HardDrive> hardDrives);
    }
}
