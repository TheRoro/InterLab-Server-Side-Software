using InterLab.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterLab.API.Domain.Services.Communication
{
    public class DocumentResponse : BaseResponse<Document>
    {
        public DocumentResponse(Document document) : base(document) { }
        public DocumentResponse(string message) : base(message) { }
    }
}
