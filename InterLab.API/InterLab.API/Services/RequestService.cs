using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterLab.API.Domain.Models;
using InterLab.API.Domain.Repositories;
using InterLab.API.Domain.Services;
using InterLab.API.Domain.Services.Communication;

namespace InterLab.API.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        public readonly IUnitOfWork _unitOfWork;
        public RequestService(IRequestRepository requestRepository, IUnitOfWork unitOfWork)
        {
            _requestRepository = requestRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<RequestResponse> GetByIdAsync(int id)
        {
            var existingRequest = await _requestRepository.FindByIdAsync(id);

            if (existingRequest == null)
                return new RequestResponse("Request not found");
            return new RequestResponse(existingRequest);
        }
        public async Task<RequestResponse> GetByIdAndUserIdAsync(int id, int userId)
        {
            var existingRequest = await _requestRepository.FindByUserIdAndRequestIdAsync(id, userId);

            if (existingRequest == null)
                return new RequestResponse("Request not found");
            return new RequestResponse(existingRequest);

        }
        public async Task<RequestResponse> GetByIdAndInternshipIdAsync(int id, int internshipId)
        {
            var existingRequest = await _requestRepository.FindByInternshipIdAndRequestIdAsync(id, internshipId);

            if (existingRequest == null)
                return new RequestResponse("Request not found");
            return new RequestResponse(existingRequest);

        }

        public async Task<IEnumerable<Request>> ListAsync()
        {
            return await _requestRepository.ListAsync();
        }

        public async Task<IEnumerable<Request>> ListByInternshipIdAsync(int internshipId)
        {
            return await _requestRepository.ListByInternshipIdAsync(internshipId);
        }

        public async Task<IEnumerable<Request>> ListByUserIdAsync(int userId)
        {
            return await _requestRepository.ListByUserIdAsync(userId);
        }

        public async Task<RequestResponse> SaveAsync(Request request)
        {
            try
            {
                await _requestRepository.AddAsync(request);
                await _unitOfWork.CompleteAsync();

                return new RequestResponse(request);
            }
            catch (Exception ex)
            {
                return new RequestResponse($"An error ocurred while saving the request: {ex.Message}");
            }
        }
        
        public async Task<RequestResponse> DeleteAsync(int id)
        {
            var existingRequest = await _requestRepository.FindByIdAsync(id);

            if (existingRequest == null)
                return new RequestResponse("Request not found");

            try
            {
                _requestRepository.Remove(existingRequest);
                await _unitOfWork.CompleteAsync();

                return new RequestResponse(existingRequest);
            }
            catch (Exception ex)
            {
                return new RequestResponse($"An error ocurred while deleting request: {ex.Message}");
            }
        }

        public async Task<RequestResponse> AssignUserInternshipAsync(int userId, int internshipId)
        {
            try
            {

                await _requestRepository.AssignUserInternship(userId, internshipId);
                await _unitOfWork.CompleteAsync();
                Request request = await _requestRepository.FindByUserIdAndInternshipId(userId, internshipId);
                return new RequestResponse(request);
            }
            catch (Exception ex)
            {
                return new RequestResponse($"An error ocurred while assigning Company to User: {ex.Message}");
            }

        }

    }
}
