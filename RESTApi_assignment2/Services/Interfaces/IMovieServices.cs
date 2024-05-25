using IMDB.Models.Request;
using IMDB.Models.Response;
using System.Collections.Generic;

namespace Assignment3.Services.Interfaces
{
    public interface IMovieServices
    {
        ServiceResponse<List<MovieResponse>> GetAll();
        ServiceResponse<MovieResponse> GetById(int id);
        ServiceResponse<int> Create(MovieRequest request);
        void Update(int id, MovieRequest request);
        void Delete(int id);
    }
}
