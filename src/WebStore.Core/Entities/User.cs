
namespace WebStore.Domain.Entities
{
    public sealed class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordHSalt { get; private set; }

        public User()
        {
            
        }
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
        public User(string name, string email, string password, byte[] passwordHash, byte[] passwordHSalt)
        {
            Name = name;
            Email = email;
            Password = password;
            PasswordHash = passwordHash;
            PasswordHSalt = passwordHSalt;
        }

        public User(Guid id, string name, string email, byte[] passwordHash, byte[] passwordHSalt)
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            PasswordHSalt = passwordHSalt;
        }

        public void UpdatePassword(byte[] passwordHash, byte[] passwordHSalt)
        {
            PasswordHash = passwordHash;
            PasswordHSalt = passwordHSalt;
        }
    }
}
