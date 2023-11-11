using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crudapp.Dto
{
    public class PageDto
    {
        private global::System.Int32 _totalPage = 0;
        public int TotalPage { get => _totalPage; set => _totalPage = value; }

        private int _current_page = 1;
        public int Current_page { get => _current_page <= 0 ? 1 : _current_page; set => _current_page = value; }


        private global::System.Int32 _total = 0;
        public int Total { get => _total; set => _total = value; } 
        
        public int PageSize { get; set; } = 5;



        public string? filter { get; set; } = null;
        public string? sort { get; set; } = null;
        public string? kw { get; set; } = null;
        public string? Q1 { get; set; } = null;
        public string? Q2 { get; set; } = null;
        public string? Q3 { get; set; } = null;
        public string? Q4 { get; set; } = null;
        public string? Q5 { get; set; } = null;
        public string? Q6 { get; set; } = null;
        public string? Q7 { get; set; } = null;
        public string? Q8 { get; set; } = null;
        public string? Q9 { get; set; } = null;
        public string? Q10 { get; set; } = null;
        public string? Q11 { get; set; } = null;
        public string? Q12 { get; set; } = null;
        public string? Q13 { get; set; } = null;
        public string? Q14 { get; set; } = null;
        public string? Q15 { get; set; } = null;
        public string? Q16 { get; set; } = null;
        public string? Q17 { get; set; } = null;
        public string? Q18 { get; set; } = null;
        public string? Q19 { get; set; } = null;
        public string? Q20 { get; set; } = null;

    }
}