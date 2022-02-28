using System;

namespace CoacehlTraining.Core.DTO
{
    public class PersonInfo
    {
        public string Identification { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class PersonResponse
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }
    }


    public class PersonUpdate
    {
        public DateTime LastUpate { get; set; }
    }
}
