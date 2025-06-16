using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Processors
{
    public interface IActivityProcessor<T>
    {
        Task ProcessAsync(T activityDto);
    }
}
