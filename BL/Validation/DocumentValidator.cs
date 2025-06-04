using Maentl.SQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Validation
{
    public static class DocumentValidator
    {
        public static bool IsValid(Document doc, out List<string> errors)
        {
            errors = new();

            if (string.IsNullOrWhiteSpace(doc.Title))
                errors.Add("Document must have a title.");

            if (string.IsNullOrWhiteSpace(doc.CreatedBy))
                errors.Add("CreatedBy is required.");

            if (doc.CreatedAt == default)
                errors.Add("CreatedAt must be set.");

            return !errors.Any();
        }
    }
}
