using pharmacy_api.Enum;

namespace Application.DTOS.User
{
    /// <summary>
    /// Parâmetros de filtragem e paginação para listagem de usuários.
    /// </summary>
    public record UserQueryParams
    {
        public string? Name { get; init; }
        public string? Email { get; init; }
        public UserRole? Role { get; init; }

        private int _page = 1;
        public int Page
        {
            get => _page;
            init => _page = value < 1 ? 1 : value;
        }

        private int _pageSize = 20;
        public int PageSize
        {
            get => _pageSize;
            init => _pageSize = value is < 1 or > 100 ? 20 : value;
        }
    }
}
