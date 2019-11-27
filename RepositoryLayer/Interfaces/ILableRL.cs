using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface ILableRL
    {
        string AddLable(LabelModel lableModel);

        string DeleteLable(int id);

        string UpdateLable(int id, LabelModel labelModel);

        string GetLables();

        string GetLable(int id);
    }
}
