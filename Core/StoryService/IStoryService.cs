using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatAccess.Models;
using Microsoft.AspNetCore.Http;
using NuGet.Protocol.Core.Types;

namespace Core.StoryService
{
    public interface IStoryService
    {
        void AddStory(IFormFile file);
        List<Story> GetAllStories();
        Story GetStoryById(int id);
        void DeleteStory(int id);
    }
}
