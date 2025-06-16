using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Strategy.Email
{
    public interface IEmailComplexityEvaluatorStrategy
    {
        int Evaluate(EmailActivityDto email);
    }

    public class BasicComplexityEvaluator : IEmailComplexityEvaluatorStrategy
    {
        public int Evaluate(EmailActivityDto email)
        {
            var wordCount = email.Body?.Split(' ').Length ?? 0;
            if (wordCount > 300) return 3;
            if (wordCount > 100) return 2;
            return 1;
        }
    }
}
