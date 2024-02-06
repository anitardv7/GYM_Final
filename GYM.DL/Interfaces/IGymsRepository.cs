using GYM.DL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.DL.Repositories
{
    public interface IGymsRepository
    {
        List<Gyms> GetAllGymssByInstructor(int instructorId);

        //  Gyms? GetByTitle(string title);
    }
}
