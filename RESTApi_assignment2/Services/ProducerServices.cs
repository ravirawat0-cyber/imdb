using IMDB.Interfaces;
using IMDB.Models.DbModels;
using IMDB.Models.Request;
using IMDB.Models.Response;
using IMDB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDB
{
    public class ProducerServices : IProducerServices
    {
        private readonly ProducerRepository _producerRepository;

        public ProducerServices(ProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public ServiceResponse<int> Create(ProducerRequest request)
        {
            ValidateReqeust(request);
            var producer = new Producer
            {
                Name = request.Name,
                Bio = request.Bio,
                Sex = request.Sex,
                DOB = request.DOB
            };
            var id = _producerRepository.Create(producer);
            return new ServiceResponse<int>
            {
                Data = id
            };
        }

        public void Delete(int id)
        {
            if(_producerRepository.GetById(id) == null) 
            {
                throw new KeyNotFoundException($"Producer with ID {id} not found");
            };
            _producerRepository.Delete(id);
        }

        public ServiceResponse<List<ProducerResponse>> GetAll()
        {
            var produerlist = _producerRepository.GetAll();
            if (produerlist == null)
            {
                throw new ArgumentException("Producer is empty.");
            }
            var producerResponseList = produerlist.Select(producer => new ProducerResponse
            {
                Id = producer.Id,
                Name = producer.Name,
                Bio = producer.Bio,
                Sex = producer.Sex,
                DOB = producer.DOB
            }).ToList();
            return new ServiceResponse<List<ProducerResponse>>
            {
                Data = producerResponseList
            };
        }

        public ServiceResponse<ProducerResponse> GetById(int id)
        {
            var producer = _producerRepository.GetById(id);
            if (producer == null)
            {
                return null;
            }
            var producerResponse = new ProducerResponse
            {
                Id = producer.Id,
                Name = producer.Name,
                Bio = producer.Bio,
                Sex = producer.Sex,
                DOB = producer.DOB
            };
            return new ServiceResponse<ProducerResponse>
            {
                Data = producerResponse
            };
        }

        public void Update(int id, ProducerRequest request)
        {
          
            ValidateReqeust(request);
            var producer = new Producer 
            { 
                Name = request.Name,
                Sex = request.Sex,
                Bio = request.Bio,
                DOB = request.DOB
            };
            _producerRepository.Update(id , producer);
            
        }
        private void ValidateReqeust(ProducerRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentException("Name cannot be empty or null");
            }

            if (request.DOB > DateTime.Now)
            {
                throw new ArgumentException("DOB cannot be greater than current date.");
            }

            if (string.IsNullOrWhiteSpace(request.Sex))
            {
                throw new ArgumentException("Gender cannot be empty or null");
            }

            if (string.IsNullOrWhiteSpace(request.Bio))
            {
                throw new ArgumentException("Bio cannot be empty or null");
            }
        }

    }

}
