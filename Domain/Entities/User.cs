using pharmacy_api.Enum;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PassHash { get; private set; } = string.Empty;
        public UserRole Role { get; private set; } = UserRole.subAdmin;
        public ICollection<Pharmacy> Pharmacies { get; set; } = [];

        protected User() { }

        public User(string name, string lastName, string email, string passHash, UserRole role)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            PassHash = passHash;
            Role = role;
        }

      
    }
}
