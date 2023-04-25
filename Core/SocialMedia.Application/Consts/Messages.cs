using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Consts
{
    public static class Messages
    {
        public static string EmptyNameMessage = "Name cannot be empty";
        public static string MaximumSymbolMessage = "You have reached the maximum character limit";
        public static string MaximumNameSymbolMessage = "Name must be less than 25 characters";
        public static string MaximumLastNameSymbolMessage = "Name must be less than 35 characters";
        public static string InvalidEmailMessage = "Email is not valid";
        public static string EmptyEmailMessage = "Email cannot be empty";
        public static string UsedEmailMessage = "Email already in use";
        public static string MaximumUsernameSymbolMessage = "Username must be less than 16 characters";
        public static string EmptyPostMessage = "Post cannot be empty";
        public static string EmptyCommentMessage = "Comment cannot be empty";
        public static string NoUserFoundMessage = "No user founds";
        public static string NoPostsFoundMessage = "No posts founds";
    }
}