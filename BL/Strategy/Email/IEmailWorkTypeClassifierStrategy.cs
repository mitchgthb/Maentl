using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Strategy.Email
{
    public interface IEmailWorkTypeClassifierStrategy
    {
        string Classify(EmailActivityDto email);
    }

    public class KeywordBasedWorkTypeClassifier : IEmailWorkTypeClassifierStrategy
    {
        public string Classify(EmailActivityDto email)
        {
            if (email.Subject.Contains("review", StringComparison.OrdinalIgnoreCase))
                return "Review";
            if (email.Body.Contains("advise", StringComparison.OrdinalIgnoreCase))
                return "Advice";
            return "General";
        }
    }
}
