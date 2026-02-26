using System.Text.Json;
using HadiDinner.Application.Common.Interfaces.Persistence;
using HadiDinner.Application.Menus.Commands.CreateMenu;
using HadiDinner.Contracts.Menus;
using HadiDinner.Domain.Menu;
using HadiDinner.Infrastructure.Persistence.Repositories;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HadiDinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenuController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    private readonly IMenuRepository _menuRepository;

    public MenuController(IMapper mapper, ISender sender, IMenuRepository menuRepository)
    {
        _mapper = mapper;
        _mediator = sender;
        _menuRepository = menuRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(
        [FromBody] CreateMenuRequest request,
        [FromRoute] string hostId
    )
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));

        var createMenuResult = await _mediator.Send(command);

        MenuResponse menuResponse = _mapper.Map<MenuResponse>(createMenuResult.Value);

        return createMenuResult.Match(
            (_) => StatusCode(201, menuResponse),
            errors => Problem(errors)
        );
    }

    [HttpGet("{menuId}")]
    public async Task<IActionResult> GetMenu([FromRoute] string hostId, [FromRoute] string menuId)
    {
        Menu? menu = _menuRepository.GetMenuById(menuId);

        return Ok(menu);
    }

    [HttpGet]
    public async Task<IActionResult> GetMenus([FromRoute] string hostId)
    {
        List<Menu>? menus = _menuRepository.GetMenus();

        return Ok(_mapper.Map<List<MenuResponse>>(menus));
    }
}
