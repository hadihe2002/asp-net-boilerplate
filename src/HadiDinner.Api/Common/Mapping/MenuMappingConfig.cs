using HadiDinner.Application.Menus.Commands.CreateMenu;
using HadiDinner.Contracts.Menus;
using HadiDinner.Domain.Menu;
using Mapster;
using MenuItem = HadiDinner.Domain.Menu.Entities.MenuItem;
using MenuSection = HadiDinner.Domain.Menu.Entities.MenuSection;

namespace HadiDinner.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);

        config
            .NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(
                dest => dest.AverageRating,
                src => src.AverageRating.RatingCount > 0 ? src.AverageRating.Value : 0
            )
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
            .Map(
                dest => dest.MenuReviewIds,
                src => src.ReviewIds.Select(reviewId => reviewId.Value)
            );

        config
            .NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>().Map(dest => dest.Id, src => src.Id.Value);
    }
}
