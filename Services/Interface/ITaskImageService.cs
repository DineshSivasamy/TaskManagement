using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface
{
    public interface ITaskImageService
    {
        IList<TaskImage> GetAllTaskImages(Guid TaskId);

        TaskImage Get(Guid id);

        TaskImage Create(TaskImage TaskImage);

        TaskImage Update(TaskImage TaskImage);

        bool Delete(TaskImage TaskImage);
    }
}
