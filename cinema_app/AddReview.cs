using System;
using System.Collections.Generic;
namespace cinema_app
{
    public class AddReview
    {
        public static void Addreview(string review, User user, Movie movie, DateTime date)
        {
            Tuple<string, DateTime, User> Review = Tuple.Create(review, date, user);
            movie.review.Add(Review);
        }


    }
}

