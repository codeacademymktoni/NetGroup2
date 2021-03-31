using MyRecipes.Models;
using MyRecipes.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipes.Services
{
    public class CommentsService
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public List<Comment> GetAll()
        {
            return _commentsRepository.GetAll();
        }
    }
}
