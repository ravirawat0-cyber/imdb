using IMDB.Models.Request;
using IMDB.Models.Response;
using System.Collections.Generic;

namespace IMDB.Interfaces
{
    public interface IGenreServices
    {
        ServiceResponse<List<GenreResponse>> GetAll();
        ServiceResponse<GenreResponse> GetById(int id);
        ServiceResponse<int> Create(GenreRequest request);
        void Update(int id,GenreRequest request);
        void Delete(int id);
        IEnumerable<int> CheckIdsExistInDatabase(string ids);

        List<GenreResponse> GetByGivenIds(string[] ids);
    }
}
