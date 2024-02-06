﻿using GYM.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.BL.Interfaces
{
    public interface IGymsService
    {
        List<Gyms> GetAllGymssByInstructor(int InstructorId);
    }
}

