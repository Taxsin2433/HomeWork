using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ClientSettingsController : ControllerBase
{
    private readonly IClientSettingsRepository _clientSettingsRepository;

    public ClientSettingsController(IClientSettingsRepository clientSettingsRepository)
    {
        _clientSettingsRepository = clientSettingsRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientSettings>>> GetClientSettings()
    {
        var clientSettings = await _clientSettingsRepository.GetAll();
        return Ok(clientSettings);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClientSettings>> GetClientSetting(int id)
    {
        var clientSetting = await _clientSettingsRepository.GetById(id);
        if (clientSetting == null)
        {
            return NotFound();
        }
        return Ok(clientSetting);
    }

    [HttpPost]
    public async Task<ActionResult<ClientSettings>> CreateClientSettings(ClientSettingsDto clientSettingsDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var clientSettings = new ClientSettings
        {
            Setting1 = clientSettingsDto.Setting1,
            Setting2 = clientSettingsDto.Setting2,       
        };

        await _clientSettingsRepository.Add(clientSettings);

        return CreatedAtAction(nameof(GetClientSettings), new { id = clientSettings.Id }, clientSettings);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClientSetting(int id, ClientSettings clientSetting)
    {
        if (id != clientSetting.Id)
        {
            return BadRequest();
        }
        await _clientSettingsRepository.Update(clientSetting);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClientSetting(int id)
    {
        var clientSetting = await _clientSettingsRepository.GetById(id);
        if (clientSetting == null)
        {
            return NotFound();
        }
        await _clientSettingsRepository.Delete(clientSetting);
        return NoContent();
    }
}
