namespace Register.Dtos
{
    public record PaginationResponseDTO<T>
    {
        public int Total {  get; set; }
        public List<T> Items { get; set; }

        public PaginationResponseDTO(int total, List<T> items)
        {
            this.Total = total;
            this.Items = items;
        }
    }
}
