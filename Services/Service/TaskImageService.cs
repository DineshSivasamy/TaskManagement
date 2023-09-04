using Model;
using Repository.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Services.Service
{
    public class TaskImageService : ITaskImageService
    {
        private readonly IRepositoryBase<TaskImage> Repository;

        public TaskImageService(IRepositoryBase<TaskImage> repositoryBase)
        {
            Repository = repositoryBase;
        }

        public TaskImage Create(TaskImage TaskImage)
        {
            return Repository.Create(TaskImage);
        }

        public bool Delete(TaskImage TaskImage)
        {
            return Repository.Delete(TaskImage);
        }

        public TaskImage Get(Guid id)
        {
            var result = Repository.Get(x => x.Id == id);
            return result.FirstOrDefault();
        }

        public IList<TaskImage> GetAllTaskImages(Guid taskId)
        {
            return Repository.GetAll().Where(x => x.Task.Id == taskId).ToList();
        }

        public TaskImage Update(TaskImage TaskImage)
        {
            return Repository.Update(TaskImage);
        }
    }
}
