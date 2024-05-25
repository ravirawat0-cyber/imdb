using IMDB.Models.Request;
using IMDB.Models.Response;
using System.Collections.Generic;

namespace IMDB.Interfaces
{
    public interface IProducerServices
    {
        ServiceResponse<List<ProducerResponse>> GetAll();
        ServiceResponse<ProducerResponse> GetById(int id);
        ServiceResponse<int> Create(ProducerRequest request);
        void Update(int id, ProducerRequest request);
        void Delete(int id);
    }
}
