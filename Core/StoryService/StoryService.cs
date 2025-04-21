using DatAccess.Models;
using DatAccess.Repositories.StoryRepo;
using Microsoft.AspNetCore.Http;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.StoryService
{
    public class StoryService:IStoryService
    {
        private readonly IStoryRepository _repository;
        public StoryService(IStoryRepository repository)
        {
            _repository = repository;
        }

        public void AddStory(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return;
            using var ms=new MemoryStream();
            file.CopyTo(ms);
            var story = new Story
            {
                MediaData = ms.ToArray(),
                MediaMimeType = file.ContentType,
                CreatedAt = DateTime.Now,
            };
            _repository.AddStory(story);
        }

        public void DeleteStory(int id)
        {
           _repository.DeleteStory(id);
        }

        public List<Story> GetAllStories()=>_repository.GetAllStories();


        public Story GetStoryById(int id) => _repository.GetStoryById(id);
        

        
 
    }
}
