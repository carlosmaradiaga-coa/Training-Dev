using Ardalis.Specification;
using CoacehlTraining.Core.Entities;

namespace CoacehlTraining.Core.Specs
{
    public class PersonSpecs : Specification<Person>, ISingleResultSpecification
    {
        /// <summary>
        /// Busqueda en la DB(Person) por el campo Dni
        /// </summary>
        /// <param name="dni">DNI</param>
        public PersonSpecs(string dni)
        {
            Query.Where(x => x.Dni == dni);
        }

        /// <summary>
        /// Busqueda en la DB(Person) por los campos Dni y Nombre
        /// </summary>
        /// <param name="dni">DNI</param>
        /// <param name="firstName">Nombre</param>
        public PersonSpecs(string dni, string firstName)
        {
            Query.Where(x => x.Dni == dni && x.FirstName == firstName);
        }
    }
}
