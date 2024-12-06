using Kab.DemirAjans.Business.Activations;
using Kab.DemirAjans.Entities.Activations;
using Microsoft.AspNetCore.Mvc;

namespace Kab.DemirAjans.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivationController(IActivationService activationService) : ControllerBase
{
    private readonly IActivationService _activationService = activationService; 

    public async Task SendActivationCodeAsync(ActivationCreateDto create)
    {
        await _activationService.SendActivationCodeAsync(create);
    }
}
