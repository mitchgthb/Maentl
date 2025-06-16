using BL.Interfaces;
using BL.Strategy.Email;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class EmailClassifierService : IEmailClassifierService
    {
        private readonly IEmailWorkTypeClassifierStrategy _workTypeStrategy;
        private readonly IEmailComplexityEvaluatorStrategy _complexityStrategy;

        public EmailClassifierService(
            IEmailWorkTypeClassifierStrategy workTypeStrategy,
            IEmailComplexityEvaluatorStrategy complexityStrategy)
        {
            _workTypeStrategy = workTypeStrategy;
            _complexityStrategy = complexityStrategy;
        }

        public string ClassifyWorkType(EmailActivityDto email) =>
            _workTypeStrategy.Classify(email);

        public int EvaluateComplexity(EmailActivityDto email) =>
            _complexityStrategy.Evaluate(email);
    }
}
