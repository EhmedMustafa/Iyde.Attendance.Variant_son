using Iyde.Attendance.Variant3.DTOs;
using Iyde.Attendance.Variant3.Models;
using Iyde.Attendance.Variant3.Repositories.Interfaces;
using Iyde.Attendance.Variant3.Services.Interfaces;

namespace Iyde.Attendance.Variant3.Services.Implementations;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;
    public StoreService(IStoreRepository storeRepository) => _storeRepository = storeRepository;

    public async Task<ResultDto> CreateAsync(string name)
    {
        var store = new Store { Name = name };
        await _storeRepository.AddAsync(store);
        await _storeRepository.SaveAsync();
        return ResultDto.Ok("Store created");
    }

    public Task<List<GetAllStoreDto>> GetAllAsync()
    {
        return _storeRepository.GetAllAsync()
            .ContinueWith(t => t.Result
                .Select(s => new GetAllStoreDto
                {
                    Id = s.Id,
                    StoreName = s.Name
                })
                .ToList());
    }
}