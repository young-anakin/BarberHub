using BarberHub.Context;
using BarberHub.DTOs.ReviewDTO;
using BarberHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberHub.Services.ReviewService
{
    public class ReviewService : IReviewService
    {
        private readonly DataContext _context;

        public ReviewService(DataContext context)
        {
            _context = context;
        }

        public async Task<Review> AddReview(CreateReviewDTO DTO)
        {
            var reviewer = await _context.Users.Where(u => u.UserId == DTO.ReviewerId)
                                .FirstOrDefaultAsync();
            if (reviewer == null)
            {
                throw new Exception("Reviewer Not found");
            }
            Review review = new Review();

            if (DTO.ReviewedId != null)
            {
                var reviewed = await _context.Users.Where(u => u.UserId == DTO.ReviewedId).FirstOrDefaultAsync();
                if (reviewed == null)
                {
                    throw new Exception("Reviewed Person Not Found");
                }
                review.ReviewedUser = reviewed;
                review.ReviewedUserId = reviewed.UserId;
            }

            if (DTO.CompanyId != null)
            {
                var company = await _context.Companies.Where(c => c.CompanyId == DTO.CompanyId).FirstOrDefaultAsync();
                if (company == null)
                {
                    throw new Exception("Reviewed Company not found");
                }
                review.Company = company;
                review.CompanyId = DTO.CompanyId;
            }
            review.Comment = DTO.Comment;
            review.Rating = DTO.Rating;
            review.ReviewerId = DTO.ReviewerId;
            review.ReviewerUser = reviewer;


            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();

            return review;

        }

        public async Task<Review> UpdateReview(UpdateReviewDTO DTO)
        {
            var review = await _context.Reviews.Where(r => r.ReviewId == DTO.Id).FirstOrDefaultAsync();
            if (review == null)
            {
                throw new Exception("Review not found");
            }
            review.Rating = DTO.Rating;
            review.Comment = DTO.Comment;

            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
            return review;


        }

        public async Task<Review> DeleteReview(int reviewId)
        {
            var review = await _context.Reviews.Where(r => r.ReviewId == reviewId).FirstOrDefaultAsync();
            if (review == null)
            {
                throw new Exception("Review doesn't exist");
            }
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<List<Review>> CompanyReviews(int companyId)
        {
            var reviews = await _context.Reviews.Where(r => r.CompanyId == companyId).ToListAsync();
            return reviews;
        }

        public async Task<List<Review>> UserReviews(int reviewedId)
        {
            var reviews = await _context.Reviews.Where(r => r.ReviewedUserId == reviewedId).ToListAsync();
            return reviews;
        }

        public async Task<List<Review>> MyReviews(int reviewerId)
        {
            var reviews = await _context.Reviews.Where(r => r.ReviewerId == reviewerId).ToListAsync();
            return reviews;
        }
    }
}
