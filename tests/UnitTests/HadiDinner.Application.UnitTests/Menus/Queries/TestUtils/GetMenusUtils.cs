using HadiDinner.Application.Menus.Queries.GetMenus;

namespace HadiDinner.Api.UnitTests.Menus.Queries.TestUtils;

public class GetMenusQueryUtils
{
    private int _limit = 10;
    private int _page = 1;

    public GetMenusQueryUtils WithPage(int page)
    {
        _page = page;
        return this;
    }

    public GetMenusQueryUtils WithLimit(int limit)
    {
        _limit = limit;
        return this;
    }

    public GetMenusQuery CreateMenuQuery()
    {
        return new GetMenusQuery(Limit: _limit, Page: _page);
    }
}
