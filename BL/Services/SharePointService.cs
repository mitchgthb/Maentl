using BL.DTOAdapters;
using BL.Interfaces;
using Maentl.SQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class SharePointService : ISharePointService
    {
        public async Task<SharePointUploadResultDto> UploadFileAsync(byte[] fileContent, string fileName, int? projectId)
        {
            // Simulate upload and return dummy result
            // Replace this with real Microsoft Graph or CSOM logic

            // Simulate delay
            await Task.Delay(300);

            return new SharePointUploadResultDto
            {
                FileUrl = $"https://sharepoint.company.com/sites/project{projectId}/Documents/{fileName}",
                DocId = Guid.NewGuid().ToString()
            };
        }


    }

}
