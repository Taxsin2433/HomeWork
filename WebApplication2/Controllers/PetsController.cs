using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PetsController : ControllerBase
{
    private readonly IPetRepository _petRepository;

    public PetsController(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
    {
        var pets = await _petRepository.GetAll();
        return Ok(pets);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pet>> GetPet(int id)
    {
        var pet = await _petRepository.GetById(id);
        if (pet == null)
        {
            return NotFound();
        }
        return Ok(pet);
    }

    [HttpPost]
    public async Task<ActionResult<Pet>> CreatePet(PetDto petDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var pet = new Pet
        {
            Name = petDto.Name,
        };

        await _petRepository.Add(pet);

        return CreatedAtAction(nameof(GetPet), new { id = pet.Id }, pet);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePet(int id, Pet pet)
    {
        if (id != pet.Id)
        {
            return BadRequest();
        }
        await _petRepository.Update(pet);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePet(int id)
    {
        var pet = await _petRepository.GetById(id);
        if (pet == null)
        {
            return NotFound();
        }
        await _petRepository.Delete(pet);
        return NoContent();
    }
}