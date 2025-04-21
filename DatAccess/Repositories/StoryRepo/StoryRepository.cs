using DatAccess.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DatAccess.Data;

namespace DatAccess.Repositories.StoryRepo
{
    public class StoryRepository:IStoryRepository
    {
        private readonly BookDbContext _context;

        public StoryRepository(BookDbContext context)
        {
            _context = context;
        }



        public void AddStory(Story story)
        {
           _context.Stories.Add(story);
            _context.SaveChanges();
        }

        public void DeleteStory(int id)
        {
            var story=_context.Stories.Find(id);
            if (story != null)
            {
                _context.Stories.Remove(story);
                _context.SaveChanges();
            }
        }

        public List<Story> GetAllStories()
        {
            return _context.Stories.OrderByDescending(s=>s.CreatedAt).ToList();
        }

        public Story GetStoryById(int id)
        {
            return _context.Stories.FirstOrDefault(s=>s.Id==id);
        }
    }


}
