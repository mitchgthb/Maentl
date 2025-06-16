using BL.DTOAdapters;
using Maentl.SQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ISharePointService
    {
        Task<SharePointUploadResultDto> UploadFileAsync(byte[] content, string fileName, int? projectId);
    }
}
