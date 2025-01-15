using Models.Interfaces_Abstracts;
using PersonGenderOptions = Models.Interfaces_Abstracts.IPerson.PersonGenderOptions;
using CivilStatusOptions = Models.Interfaces_Abstracts.IPerson.CivilStatusOptions;

namespace Models.People
{
    public class Person : SQLPersistentModel, IPerson
    {
        public string Name { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; } = default;
        public PersonGenderOptions Gender { get; set; } = PersonGenderOptions.OTHER;
        public CivilStatusOptions CivilStatus { get; set; } = CivilStatusOptions.SINGLE;
        public IPersonDocument[] Document { get; set; } = [];
    }
}
