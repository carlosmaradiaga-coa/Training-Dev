using CoacehlTraining.Core.DTO;
using CoacehlTraining.Core.Entities;
using CoacehlTraining.Core.Interfaces;
using CoacehlTraining.Core.Specs;
using CoacehlTraining.Core.Validators;
using GV.DomainModel.SharedKernel.Extensions;
using GV.DomainModel.SharedKernel.Interfaces;
using GV.DomainModel.SharedKernel.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoacehlTraining.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IReadRepository<Person> personReadRepository;
        private readonly IRepository<Person> personWriteRepository;

        public PersonService(IReadRepository<Person> personReadRepository, IRepository<Person> personWriteRepository)
        {
            this.personReadRepository = personReadRepository;
            this.personWriteRepository = personWriteRepository;
        }


        public async Task<Result<PersonResponse>> Add(PersonInfo personInfo)
        {
            var result = new Result<PersonResponse>();
            try
            {
                //1. Validaciones que necesito aplicar
                //1.1 Validar el DTO de entrada (personInfo)
                var validator = new PersonValidator(1);
                var validation = validator.Validate(personInfo);
                if (!validation.IsValid)
                    return result.Invalid(validation.AsErrors());

                //1.2 Validar si existe un DNI
                var exist = await personReadRepository.GetBySpecAsync(new PersonSpecs(personInfo.Identification));
                if (exist != null)
                    return result.Conflict($"No se permite agregar un DNI existente: {personInfo.Identification}");

                //2. Validacion que nos garantice que el Add fue exitoso
                var newPerson = await personWriteRepository.AddAsync(new Person
                {
                    Dni = personInfo.Identification,
                    FirstName = personInfo.FirstName,
                    LastName = personInfo.LastName,
                    CreationDate = DateTime.Now
                });
                if (newPerson == null)
                    return result.Conflict("No completo el registro de la persona");

                //3. Retorno de resultado
                return result.Success(new PersonResponse
                {
                    Id = newPerson.Id,
                    CreationDate = newPerson.CreationDate
                });
            }
            catch (Exception ex)
            {
                return result.Error("Error", new[] { ex.Message });
            }
        }

        public async Task<Result<IEnumerable<PersonInfo>>> GetAll()
        {
            var result = new Result<IEnumerable<PersonInfo>>();
            try
            {
                //Retorna una lista de personas
                var people = await personReadRepository.ListAsync();
                if (people == null)
                    return result.NotFound("Lista de personas nula.");

                //Validamos si existen elementos en la lista de personas
                if (!people.Any())
                    return result.NotFound("Lista de personas vacia.");

                //Forma tradicional de crear una lista
                var temp = new List<PersonInfo>
                {
                    new PersonInfo
                    {
                        Identification = "1234",
                        FirstName = "AA",
                        LastName = "BB"
                    },
                    new PersonInfo
                    {
                        Identification = "12345",
                        FirstName = "AA",
                        LastName = "BB"
                    },
                    new PersonInfo
                    {
                        Identification = "123456",
                        FirstName = "AA",
                        LastName = "BB"
                    }
                };
                var valor = temp.Last(item => item.FirstName == "AA");

                /*foreach (var a in people)
                {
                    x2.Add(new PersonInfo
                    {
                        Identification = a.Dni,
                        FirstName = a.FirstName,
                        LastName = a.LastName
                    });
                }
                */

                return result.Success(people.Select(item => new PersonInfo
                {
                    Identification = item.Dni,
                    FirstName = item.FirstName,
                    LastName = item.LastName
                }));
            }
            catch (Exception ex)
            {
                return result.Error("Error", new[] { ex.Message });
            }
        }

        public async Task<Result<PersonUpdate>> Update(int personId, PersonInfo personInfo)
        {
            var result = new Result<PersonUpdate>();
            try
            {
                // Validar que existe el valor personId:
                var exist = await personReadRepository.GetByIdAsync(personId);
                if (exist == null)
                    return result.Conflict($"El número de Id: {personId} No Existe");

                // validar el modelo de datos de entrada:
                var validator = new PersonValidator(1);
                var validation = validator.Validate(personInfo);
                if (!validation.IsValid)
                    return result.Invalid(validation.AsErrors());


                // validar que numero de Id sea el correcto para el número de Identidad:


                //var exist = await personReadRepository.GetBySpecAsync(new PersonSpecs(personInfo.Identification));
                //if (exist == null)
                //    return result.Conflict($"El número de DNI {personInfo.Identification} No existe");


                // 





                return result.Success(new PersonUpdate
                {
                    LastUpate = DateTime.Now
                });
             
            }
            catch (Exception ex)
            {
                return result.Error("Error", new[] { ex.Message });
            }
        }


    }
}
