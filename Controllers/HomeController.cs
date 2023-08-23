using Microsoft.AspNetCore.Mvc;
using WebApiConsumer.Contracts;

namespace WebApiConsumer;

[ApiController]
[Route("/api/v1")]
public class HomeController : ControllerBase
{
    private readonly IDummyJsonService _service;
    private readonly ILogger<HomeController> _logger;
    private readonly IDummyJsonServiceRefit _dummyJsonServiceRefit;

    public HomeController(IDummyJsonService service, ILogger<HomeController> logger, IDummyJsonServiceRefit dummyJsonServiceRefit)
    {
        _service = service;
        _logger = logger;
        _dummyJsonServiceRefit = dummyJsonServiceRefit;
    }

    [Route("auth/login")]
    [HttpPost]
    public async Task<ActionResult<LoginResponse>> Login()
    {
        try
        {
            return Ok(await _service.Login("kminchelle", "0lelplR"));
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [Route("users/{id:int}")]
    [HttpGet]
    public async Task<ActionResult<GetUserResponse>> GetUser([FromRoute] int id)
    {
        try
        {
            return Ok(await _service.GetUser(id));
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }

    [Route("users/refit/{id:int}")]
    [HttpGet]
    public async Task<ActionResult<GetUserResponse?>> GetUserRefit([FromRoute] int id)
    {
        try
        {
            var result = await _dummyJsonServiceRefit.GetUser(id);
            return result ?? null;
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            return BadRequest();
        }
    }
}
