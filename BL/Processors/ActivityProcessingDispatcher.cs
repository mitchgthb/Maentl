using DTO;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Processors
{
    public class ActivityProcessingDispatcher
    {
        private readonly IServiceProvider _provider;

        public ActivityProcessingDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task DispatchAsync(object activity)
        {
            switch (activity)
            {
                case EmailActivityDto email:
                    var emailProcessor = _provider.GetRequiredService<IActivityProcessor<EmailActivityDto>>();
                    await emailProcessor.ProcessAsync(email);
                    break;

                case DocumentDto doc:
                    var docProcessor = _provider.GetRequiredService<IActivityProcessor<DocumentDto>>();
                    await docProcessor.ProcessAsync(doc);
                    break;

                    // add more cases here
            }
        }
    }

}
