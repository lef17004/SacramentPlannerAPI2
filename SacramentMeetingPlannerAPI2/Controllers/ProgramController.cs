using PlannerApi.Models;
using PlannerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace PlannerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProgramController : ControllerBase
{
    private readonly ProgramService _programSerivce;

    public ProgramController(ProgramService programService) =>
        _programSerivce = programService;

    [HttpGet]
    public async Task<List<SacramentProgram>> Get() =>
        await _programSerivce.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<SacramentProgram>> Get(string id)
    {
        var program = await _programSerivce.GetAsync(id);

        if (program is null)
        {
            return NotFound();
        }

        return program;
    }

    [HttpPost]
    public async Task<IActionResult> Post(SacramentProgram newProgram)
    {
        await _programSerivce.CreateAsync(newProgram);

        return CreatedAtAction(nameof(Get), new { id = newProgram.Id }, newProgram);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, SacramentProgram updatedProgram)
    {
        var program = await _programSerivce.GetAsync(id);

        if (program is null)
        {
            return NotFound();
        }

        updatedProgram.Id = program.Id;

        await _programSerivce.UpdateAsync(id, updatedProgram);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var program = await _programSerivce.GetAsync(id);

        if (program is null)
        {
            return NotFound();
        }

        await _programSerivce.RemoveAsync(id);

        return NoContent();
    }
}