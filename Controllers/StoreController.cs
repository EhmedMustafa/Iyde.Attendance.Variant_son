using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Iyde.Attendance.Variant3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly IStoreService _storeService;
    public StoreController(IStoreService storeService) => _storeService = storeService;

    [HttpPost]
    public async Task<IActionResult> Create(CreateStoreDto dto)
        => Ok(await _storeService.CreateAsync(dto.Name,dto.CompanyId));


    [HttpGet("get-all-stores")]
    public async Task<IActionResult> GetAll()
        => Ok(await _storeService.GetAllAsync());
}