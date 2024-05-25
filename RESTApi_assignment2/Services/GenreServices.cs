using Assignment3.Repository;
using IMDB.Interfaces;
using IMDB.Models.DbModels;
using IMDB.Models.Request;
using IMDB.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDB
{
    public class GenreServices : IGenreServices
    {
        private readonly GenreRepository _genreRepository;

        public GenreServices(GenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public ServiceResponse<int> Create(GenreRequest request)
        {
            ValidateRequest(request);
            var genre = new Genre
            {
                Name = request.Name
            };
            var id = _genreRepository.Create(genre);
            return new ServiceResponse<int>
            {
                Data = id
            };
        }

        public void Delete(int id)
        {
            if (_genreRepository.GetById(id) == null)
            {
                throw new KeyNotFoundException($"Genre with ID {id} not found");
            }
            _genreRepository.Delete(id);
        }

        public ServiceResponse<List<GenreResponse>> GetAll()
        {
            var genrelist = _genreRepository.GetAll();
            if (genrelist == null)
            {
                throw new ArgumentException("Genere is empty.");
            }
            var genreResponseList = genrelist.Select(genre => new GenreResponse
            {
                Id = genre.Id,
                Name = genre.Name
            }).ToList();
            return new ServiceResponse<List<GenreResponse>>
            {
                Data = genreResponseList
            };
        }

        public ServiceResponse<GenreResponse> GetById(int id)
        {
            var genre = _genreRepository.GetById(id);
            if (genre == null)
            {
                return null;
            }
            var genreResponse = new GenreResponse
            {
                Id = genre.Id,
                Name = genre.Name
            };
            return new ServiceResponse<GenreResponse>
            {
                Data = genreResponse
            };
        }

        public void Update(int id, GenreRequest request)
        {
            var genre = _genreRepository.GetById(id);
            if (genre == null)
            {
                throw new KeyNotFoundException($"Genre with {id} not found");
            }
            ValidateRequest(request);
            genre.Name = request.Name;
            _genreRepository.Update(id, genre);
            
        }

        public IEnumerable<int> CheckIdsExistInDatabase(string ids)
        {
            return _genreRepository.CheckIdsExistInDatabase(ids);
        }

        public List<GenreResponse> GetByGivenIds(string[] ids)
        {
            var genrelist = _genreRepository.GetByGivenIds(ids);
            if (genrelist == null)
            {
                return new List<GenreResponse>();
            }
            var genreResponseList = genrelist.Select(genre => new GenreResponse
            {
                Id = genre.Id,
                Name = genre.Name
            }).ToList();
            return genreResponseList;
        }
        private void ValidateRequest(GenreRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentException("Name cannot be empty or null");
            }
        }
    }
}
