using IMDB.Models.Request;
using IMDB.Models.Response;
using System.Collections.Generic;

namespace IMDB.Interfaces
{
    public interface IReviewServices
    {
        ServiceResponse<List<ReviewResponse>> GetAll(int movieId);
        ServiceResponse<ReviewResponse> GetById(int movieId, int id);
        ServiceResponse<int> Create(int movieId, ReviewRequest request);
        void  Update(int movieId, int id, ReviewRequest request);
        void Delete(int movieId, int id);
    }
}
