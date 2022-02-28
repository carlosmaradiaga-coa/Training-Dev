using CoacehlTraining.Core.DTO;
using GV.DomainModel.SharedKernel.Interop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoacehlTraining.Core.Interfaces
{
    public interface IPersonService
    {
        Task<Result<IEnumerable<PersonInfo>>> GetAll();

        Task<Result<PersonResponse>> Add(PersonInfo personInfo);

        Task<Result<PersonUpdate>> Update(int personId, PersonInfo personInfo);


    }
}
