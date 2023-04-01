using System.Collections;

namespace UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Models
{
    public class PaginationDto<T> where T : class
    {
        public PaginationDto(int? total, int? perPage, int? currentPage, T data)
        {
            Data = data;
            PerPage = perPage ?? 10;
            CurrentPage = currentPage ?? 1;
            Total = total ?? 1;
            TotalPage = 1 + ((int) Total! / PerPage!);
        }

        public int? TotalPage { get; private set; }
        public int? Total { get; private set; }
        public int? PerPage { get; private set; }
        public int? CurrentPage { get; private set; }
        public T Data { get; private set; }
    }
}
