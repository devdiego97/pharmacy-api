namespace Application.DTOS.Common
{
    /// <summary>
    /// Envelope genérico para respostas paginadas.
    /// </summary>
    public record PagedResult<T>(
        IEnumerable<T> Data,
        int Page,
        int PageSize,
        int TotalCount
    )
    {
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasNextPage => Page < TotalPages;
        public bool HasPreviousPage => Page > 1;
    }
}
