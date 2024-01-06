using BubberDinner.Application.Menus.Commands.CreateMenu;
using BubberDinner.Contract.Menus.Request;
using BubberDinner.Contract.Menus.Response;
using BubberDinner.Domain.Models.MenuAggregate;

using Mapster;

using MenuSection = BubberDinner.Domain.MenuAggregate.Entities.MenuSection;
using MenuItem = BubberDinner.Domain.MenuAggregate.Entities.MenuItem;
using BubberDinner.Domain.DinnerAggregate.ValueObjects;
namespace BubberDinner.Api.Commons.Mapping.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
        .Map(dest => dest.HostId, src => src.HostId)
        .Map(dest => dest, src => src.Request);

        config.NewConfig<Menu, MenuResponse>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
        .Map(dest => dest.HostId, src => src.HostId)
        .Map(dest => dest.DinneIds, src => src.DinnerIds.Select(DinnerId => DinnerId.Value))
        .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(MenuReviewId => MenuReviewId.Value));

        config.NewConfig<MenuSection, MenuSectionResponse>().Map(dest => dest.Id, src => src.Id.Value);
        config.NewConfig<MenuItem, MenuItemResponse>().Map(dest => dest.Id, src => src.Id.Value);
    }
}
