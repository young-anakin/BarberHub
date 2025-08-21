using BarberHub.DTOs.ReviewDTO;
using BarberHub.Models;

namespace BarberHub.Services.ReviewService
{
    public interface IReviewService
    {
        Task<Review> AddReview(CreateReviewDTO DTO);
        Task<List<Review>> CompanyReviews(int companyId);
        Task<Review> DeleteReview(int reviewId);
        Task<List<Review>> MyReviews(int reviewerId);
        Task<Review> UpdateReview(UpdateReviewDTO DTO);
        Task<List<Review>> UserReviews(int reviewedId);
    }
}