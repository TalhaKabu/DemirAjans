using Kab.DemirAjans.Business.Activations;
using Kab.DemirAjans.Entities.Activations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace Kab.DemirAjans.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivationController(IActivationService activationService) : ControllerBase
{
    private readonly IActivationService _activationService = activationService;

    [HttpPost("send-activation-code")]
    public async Task<IActionResult> SendActivationCodeAsync(ActivationCreateDto create)
    {
        await _activationService.SendActivationCodeAsync(create);
        return Ok(true);
    }

    [HttpPost("verify-activation-code")]
    public async Task<IActionResult> VerifyActivationCodeAsync(VerifyActivationDto verifyActivationDto)
    {
        try
        {
            await _activationService.VerifyActivationCodeAsync(verifyActivationDto);
            return Ok(true);
        }
        catch (ArgumentNullException)
        {
            return NotFound();
        }
        catch (TimeoutException)
        {
            return StatusCode(408); //Timeout
        }
        catch (InvalidDataException)
        {
            return Conflict();
        }
    }
}
