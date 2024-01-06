using BubberDinner.Application.Menus.Commands.CreateMenu;
using BubberDinner.Contract.Menus.Request;
using BubberDinner.Contract.Menus.Response;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers.Menus;




[Route("hosts/{hostId}/menus")]
public class MenusController : ApiBaseController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public MenusController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));
        var response = await _sender.Send(command);
        return response.Match<IActionResult>(
            menu => Ok(_mapper.Map<MenuResponse>(menu)),
            errors => Problem(errors)
        );
    }

}