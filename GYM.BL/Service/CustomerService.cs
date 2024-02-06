using GYM.BL.Interfaces;
using GYM.Models.Models;
using GYM.Models.Responses;
using GYM.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.BL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGymsService _GymService;
        private readonly IInstructorService _InstructorService;
        private GymsService gymsService;
        private InstructorService instructorService;

        public CustomerService(IInstructorService instructorService,
                                IGymsService gymsService)
        {
            _InstructorService = instructorService;
            _gymsService = gymsService;
        }

        public CustomerService(GymsService gymsService, InstructorService instructorService)
        {
            this.gymsService = gymsService;
            this.instructorService = instructorService;
        }

        public Instructor? Instructor { get; private set; }
        public List<Gyms>? Gymss { get; private set; }

        public IEnumerable<object> GetAllGymsCount(int input, int instructorId)
        {
            throw new NotImplementedException();
        }

        public GetAllGymssByInstructorResponse? GetAllGymssByInstructor(GetAllGymssByInstructorRequest request)
        {
            throw new NotImplementedException();
        }

        public GetAllGymssByInstructorResponse? GetAllGymssByInstructorAfterDate(GetAllGymssByInstructorRequest request)
        {
            var gymss = _gymsService.GetAllGymssByInstructor(request.InstructorId);
            var instructor = _instructorService.GetById(request.InstructorId);
            var result = new GetAllGymssByInstructorResponse();

            Instructor = instructor;
            Gymss = gyms.Where(b => b.ReleaseDate >= request.AfterDate).ToList();

            return result;
        }

        public object GetAllGymssCount(int input, int instructorId)
        {
            throw new NotImplementedException();
        }
    }
}
