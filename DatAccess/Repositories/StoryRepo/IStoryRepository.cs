using DatAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DatAccess.Repositories.StoryRepo
{
    public interface IStoryRepository
    {
        void AddStory(Story story);
        List<Story>GetAllStories();
        Story GetStoryById(int id);
        void DeleteStory(int id);

    }
}
