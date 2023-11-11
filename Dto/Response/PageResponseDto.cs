using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crudapp.Dto.Response
{
    public class PageResponseDto
    {
        public int status {get;set;}
        public string? message {get;set;}
        public Boolean? success {get;set;}
        public  Object? datas {get;set;}
        public int total {get;set;}
        public int perpage {get;set;}
        public int? currentpage {get;set;}
    }
}