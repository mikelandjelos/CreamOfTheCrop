using OOPR.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPR.Services.Interfaces
{
    public interface IGradeStrategiesServices
    {
        StrategyModel GetStrategy(string name);

        void AddStrategy(StrategyModel strategy);

        void Load();
    }
}
