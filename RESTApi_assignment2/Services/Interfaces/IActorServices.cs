using IMDB.Models.Request;
using IMDB.Models.Response;
using System.Collections.Generic;

namespace IMDB.Interfaces
{
    public interface IActorServices
    {
        ServiceResponse<List<ActorResponse>> GetAll();
        ServiceResponse<ActorResponse> GetById(int id);
        ServiceResponse<int> Create(ActorRequest request);
        void Update(int id, ActorRequest request);
        void Delete(int id);
        IEnumerable<int> CheckIdsExistInDatabase(string ids);
        List<ActorResponse> GetByGivenIds(string[] ids);
    }

}
