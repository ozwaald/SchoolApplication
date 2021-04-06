using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Contracts.ViewModels
{
    public class ResponseDto<T>
    {
        public ResponseDto()
        {
            Errors = new List<ErrorModel>();
        }
        public T Body { get; set; }
        public List<ErrorModel> Errors { get; set; }
        public bool HasErrors
        {
            get
            {
                return Errors.Any();
            }
        }
    }

    public class ErrorModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
