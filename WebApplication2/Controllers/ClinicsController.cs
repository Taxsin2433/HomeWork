using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ClinicsController : ControllerBase
{
    private readonly IClinicRepository _clinicRepository;

    public ClinicsController(IClinicRepository clinicRepository)
    {
        _clinicRepository = clinicRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Clinic>>> GetClinics()
    {
        var clinics = await _clinicRepository.GetAll();
        return Ok(clinics);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Clinic>> GetClinic(int id)
    {
        var clinic = await _clinicRepository.GetById(id);
        if (clinic == null)
        {
            return NotFound();
        }
        return Ok(clinic);
    }

 
    [HttpPost]
    public async Task<ActionResult<Clinic>> CreateClinic(ClinicDto clinicDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var clinic = new Clinic
        {
            Name = clinicDto.Name,
        };

        await _clinicRepository.Add(clinic);

        return CreatedAtAction(nameof(GetClinic), new { id = clinic.Id }, clinic);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClinic(int id, Clinic clinic)
    {
        if (id != clinic.Id)
        {
            return BadRequest();
        }
        await _clinicRepository.Update(clinic);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClinic(int id)
    {
        var clinic = await _clinicRepository.GetById(id);
        if (clinic == null)
        {
            return NotFound();
        }
        await _clinicRepository.Delete(clinic);
        return NoContent();
    }
}