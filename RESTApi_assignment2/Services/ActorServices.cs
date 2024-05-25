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
    public class ActorServices : IActorServices
    {
        private readonly ActorRepository _actorRepository;
        public ActorServices(ActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }
        public ServiceResponse<int> Create(ActorRequest request)
        {
            ValidateRequest(request);
            var actor = new Actor 
            {
                Name = request.Name,
                Bio = request.Bio,
                Sex = request.Sex,
                DOB = request.DOB
            };
            var id = _actorRepository.Create(actor);

            return new ServiceResponse<int>
            {
                Data = id
            };
        }

        public void Delete(int id)
        {
            if (_actorRepository.GetById(id) == null)
            {
                throw new KeyNotFoundException($"Actor with ID {id} not found");
            }

            _actorRepository.Delete(id);
        }

        public ServiceResponse<List<ActorResponse>> GetAll()
        {
            var actorlist = _actorRepository.GetAll();
            if (actorlist == null)
            {
                throw new ArgumentException("Actor not found.");
            }   
            var actorResponseList = actorlist?.Select(actor => new ActorResponse
            {
                Id = actor.Id,
                Name = actor.Name,
                Bio = actor.Bio,
                Sex = actor.Sex,
                DOB = actor.DOB
            }).ToList();

            return new ServiceResponse<List<ActorResponse>>
            {
                Data = actorResponseList ?? new List<ActorResponse>()
            };
        }

        public ServiceResponse<ActorResponse> GetById(int id)
        {
            var actor = _actorRepository.GetById(id);
            if (actor == null)
            {
                return null;
            }
            var actorResponse = new ActorResponse
            {
                Id = actor.Id,
                Name = actor.Name,
                Bio = actor.Bio,
                Sex = actor.Sex,
                DOB = actor.DOB
            };
            return new ServiceResponse<ActorResponse>
            {
                Data = actorResponse ?? new ActorResponse()
            };
        }

        public void Update(int id, ActorRequest request)
        {
            ValidateRequest(request);
            var actor = new Actor
            {
                Id = id,
                Name = request.Name,
                Sex = request.Sex,
                Bio = request.Bio,
                DOB = request.DOB
            };
            _actorRepository.Update(id, actor);
        }
        public IEnumerable<int> CheckIdsExistInDatabase(string ids)
        {
            return _actorRepository.CheckIdsExistInDatabase(ids);
        }
        public List<ActorResponse> GetByGivenIds(string[] ids)
        {
            var actorlist = _actorRepository.GetByGivenIds(ids);
            if (actorlist == null)
            {
                return new List<ActorResponse>();
            }
            var actorResponseList = actorlist.Select(actor => new ActorResponse
            {
                Id = actor.Id,
                Name = actor.Name,
                Bio = actor.Bio,
                Sex = actor.Sex,
                DOB = actor.DOB
            }).ToList();
            return actorResponseList;
        }
        private void ValidateRequest(ActorRequest request)
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
                throw new ArgumentException("Sex cannot be empty or null");
            }

            if (string.IsNullOrWhiteSpace(request.Bio))
            {
                throw new ArgumentException("Bio cannot be empty or null");
            }
        }
    }
}

