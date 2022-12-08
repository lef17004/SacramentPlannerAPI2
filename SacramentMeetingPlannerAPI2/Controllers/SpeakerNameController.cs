using PlannerApi.Models;
using PlannerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace PlannerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpeakerNameController : ControllerBase
{
    private readonly SpeakerNameService _speakerService;

    public SpeakerNameController(SpeakerNameService speakerService) =>
        _speakerService = speakerService;

    [HttpGet]
    public async Task<List<SpeakerName>> Get() =>
        await _speakerService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<SpeakerName>> Get(string id)
    {
        var program = await _speakerService.GetAsync(id);

        if (program is null)
        {
            return NotFound();
        }

        return program;
    }

    [HttpPost]
    public async Task<IActionResult> Post(SpeakerName newName)
    {
        await _speakerService.CreateAsync(newName);

        return CreatedAtAction(nameof(Get), new { id = newName.Id }, newName);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, SpeakerName updatedSpeakerName)
    {
        var program = await _speakerService.GetAsync(id);

        if (program is null)
        {
            return NotFound();
        }

        updatedSpeakerName.Id = program.Id;

        await _speakerService.UpdateAsync(id, updatedSpeakerName);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var program = await _speakerService.GetAsync(id);

        if (program is null)
        {
            return NotFound();
        }

        await _speakerService.RemoveAsync(id);

        return NoContent();
    }
}