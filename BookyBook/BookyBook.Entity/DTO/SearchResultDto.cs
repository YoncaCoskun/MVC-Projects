namespace BookyBook.Entity.DTO
{
    public class SearchResultDto : IEntityKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
