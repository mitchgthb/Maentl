﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IEmailClassifierService
    {
        string ClassifyWorkType(EmailActivityDto email);
        int EvaluateComplexity(EmailActivityDto email);
    }

}
