//using CleanArchitecture.Application.Common.Interfaces;
//using CleanArchitecture.Application.Common.Mappings;
//using CleanArchitecture.Application.Common.Models;

//namespace CleanArchitecture.Application.TodoItems.Queries.GetTodoItemsWithPagination;

//public record GetTodoItemsWithPaginationQuery : IRequest<PaginatedList<DemandsBriefDto>>
//{
//    public int ListId { get; init; }
//    public int PageNumber { get; init; } = 1;
//    public int PageSize { get; init; } = 10;
//}

//public class GetTodoItemsWithPaginationQueryHandler : IRequestHandler<GetTodoItemsWithPaginationQuery, PaginatedList<DemandsBriefDto>>
//{
//    private readonly IApplicationDbContext _context;
//    private readonly IMapper _mapper;

//    public GetTodoItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
//    {
//        _context = context;
//        _mapper = mapper;
//    }

//    public async Task<PaginatedList<DemandsBriefDto>> Handle(GetTodoItemsWithPaginationQuery request, CancellationToken cancellationToken)
//    {
//        return await _context.TodoItems
//            .Where(x => x.ListId == request.ListId)
//            .OrderBy(x => x.Title)
//            .ProjectTo<DemandsBriefDto>(_mapper.ConfigurationProvider)
//            .PaginatedListAsync(request.PageNumber, request.PageSize);
//    }
//}
