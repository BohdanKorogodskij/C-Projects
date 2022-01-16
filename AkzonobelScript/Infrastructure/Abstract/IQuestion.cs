using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace Interface
{
    public interface IQuestion
    {
        IEnumerable<QuestionBase> GetQuestion { get; }
        void UpdateQuestion(int kodid_, string sQuestion_, string sBottom_);
    }
}
