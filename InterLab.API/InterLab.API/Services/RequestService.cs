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

        public async Task<RequestResponse> GetByIdAsync(int id)
        {
            var existingRequest = await _requestRepository.FindByIdAsync(id);

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

        public async Task<RequestResponse> UpdateAsync(int id, Request request)
        {
            var existingRequest = await _requestRepository.FindByIdAsync(id);

            if (existingRequest == null)
                return new RequestResponse("Request not found");

            existingRequest.State = request.State;


            try
            {
                _requestRepository.Update(existingRequest);
                await _unitOfWork.CompleteAsync();

                return new RequestResponse(existingRequest);
            }
            catch (Exception ex)
            {
                return new RequestResponse($"An error ocurred while updating request: {ex.Message}");
            }
        }
    }
}
