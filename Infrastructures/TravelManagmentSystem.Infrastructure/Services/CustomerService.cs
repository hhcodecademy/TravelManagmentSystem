using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using TravelManagmentSystem.Application.Contracts.Repository;
using TravelManagmentSystem.Application.Contracts.Services;
using TravelManagmentSystem.Application.Contracts.UnitOfWorks;
using TravelManagmentSystem.Application.Dtos;
using TravelManagmentSystem.Domain.Entities;
using TravelManagmentSystem.Infrastructure.Exceptions;

namespace TravelManagmentSystem.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(IGenericRepository<Customer> customerRepository, IMapper mapper, IUnitOfWork unitOfWork, ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<CustomerDto> AddAsync(CustomerDto dto)
        {
            var dtoInputToJson=JsonSerializer.Serialize(dto);
            _logger.LogInformation($"Customer Input: {dtoInputToJson}");
            var entityToCreate = _mapper.Map<Customer>(dto);
            await _customerRepository.AddAsync(entityToCreate);
            await _unitOfWork.SaveChangesAsync();
            var outDto= _mapper.Map<CustomerDto>(entityToCreate);
            var dtoOutputToJson = JsonSerializer.Serialize(dto);
            _logger.LogInformation($"Customer Output: {outDto}");
            return outDto;
        }

        public async Task<IList<CustomerDto>> GetAllAsync()
        {
            //throw new Exception("Custom exception"); 

            var query = _customerRepository.GetAll();
            var entities = await query.ToListAsync();
            var dtos = _mapper.Map<List<CustomerDto>>(entities);
            var dtoOutputToJson = JsonSerializer.Serialize(dtos);
            _logger.LogInformation($"Customer Get Output: {dtoOutputToJson}");
            return dtos;
        }

        public async Task<CustomerDto> GetAsync(Guid id)
        {
            
            var entity = await _customerRepository.GetAsync(id);
            if(entity is null)
            {
                 throw new NotFoundException($"This {id} is not found");
            }
            var dto = _mapper.Map<CustomerDto>(entity);
            return dto;
        }

        public async Task<CustomerDto> RemoveAsync(Guid id )
        {
            var entity = await _customerRepository.GetAsync(id);
            if (entity is null)
            {
                throw new NotFoundException($"This {id} is not found");
            }
            _customerRepository.Remove(entity);
            _unitOfWork.SaveChanges();
            return _mapper.Map<CustomerDto>(entity);
        }

        public async Task<CustomerDto> UpdateAsync(Guid id,CustomerDto dto)
        {
            var entity = await _customerRepository.GetAsync(id);
            if (entity is null)
            {
                throw new NotFoundException($"This {id} is not found");
            }

            var entityToUpdate = _mapper.Map<Customer>(dto);
            entityToUpdate.Id = id;
            _customerRepository.Update(entityToUpdate);
            _unitOfWork.SaveChanges();
            var updatedDto = _mapper.Map<CustomerDto>(entityToUpdate);

            return updatedDto;
        }
    }
}
