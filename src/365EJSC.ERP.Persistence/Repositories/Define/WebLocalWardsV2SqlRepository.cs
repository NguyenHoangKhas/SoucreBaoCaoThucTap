using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Define;
using _365EJSC.ERP.Domain.Entities.Define;
using _365EJSC.ERP.Persistence;
using _365EJSC.ERP.Persistence.Repositories.Base;

public class WebLocalWardsV2SqlRepository : GenericSqlRepository<WebLocalWardsV2, int>, IWebLocalWardsV2SqlRepository
{
    private readonly ApplicationDbContext _context;

    public WebLocalWardsV2SqlRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

}
