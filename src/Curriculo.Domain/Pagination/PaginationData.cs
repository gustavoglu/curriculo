namespace Curriculo.Domain.Pagination
{
    public class PaginationData
    {
        public PaginationData(object data, int total = 0, int page = 1)
        {
            Data = data;
            Total = total;
            Page = page;
        }

        public object Data { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
    }
}
