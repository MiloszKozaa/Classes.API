namespace Classes.Models
{
    public sealed class Student : ModelBase
    {
        public string Username { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        private List<ExternalProfile> _externalProfiles;
        public List<ExternalProfile>? ExternalProfiles => _externalProfiles ?? new List<ExternalProfile>();

        private Student(Guid id, string username, string firstName, string lastName, string email, string phoneNumber, DateTime createdAt, DateTime lastEditedAt)
        {
            Id = id;
      
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;

            CreatedAt = createdAt;
            LastEditedAt = lastEditedAt;
        }

        public static Student Create(string username, string firstName, string lastName, string email, string phoneNumber)
        {
            return new Student(new Guid(), username, firstName, lastName, email, phoneNumber, DateTime.UtcNow, DateTime.UtcNow);
        }

        public Student Update(string username, string firstName, string lastName, string email, string phoneNumber)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            LastEditedAt = DateTime.UtcNow;
            return this;
        }

        public Student AddExternalProfile(ExternalProfile externalProfile)
        {
            _externalProfiles = _externalProfiles ?? new List<ExternalProfile>();
            if (_externalProfiles.Any(e => e.Student == externalProfile.Student)) return this;

            _externalProfiles.Add(externalProfile);

            return this;
        }
        public Student DeleteExternalProfile(Guid id)
        {
            if (_externalProfiles == null) throw new ArgumentException("Student external profile ID are not included into db request.");

            _externalProfiles = _externalProfiles.Where(e => e.Id != id).ToList();

            return this;
        }
    }
}

// student - 01964e5e-5519-78c3-86d4-73a5696ea987
// profile - 01965042-1546-7161-bc7c-1aaa16924015