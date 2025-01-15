namespace Models.Interfaces_Abstracts
{
    public interface IPerson
    {
        public enum PersonGenderOptions
        {
            MASCULINE,
            FEMININE,
            NON_BINARY,
            OTHER
        }

        public enum CivilStatusOptions
        {
            SINGLE,
            MARRIED,
            DIVORCED,
            WIDOW,
        }
        
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public PersonGenderOptions Gender { get; set; }
        public CivilStatusOptions CivilStatus { get; set; }
        public IPersonDocument[] Document { get; set; }
    }
}
