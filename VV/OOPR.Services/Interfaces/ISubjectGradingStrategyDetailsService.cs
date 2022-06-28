using OOPR.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOPR.Repository.Interfaces
{
    public interface ISubjectGradingStrategyDetailsService
    {
        SubjectGradingStrategy GetSubject(string name);

        void AddSubject(SubjectGradingStrategy strategy);

        void Load();
    }
}
