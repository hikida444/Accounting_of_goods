namespace WinFormsApp1.Models
{
    public class User
    {
        public string LastName { get; set; }   
        public string FirstName { get; set; } 
        public string? MiddleName { get; set; }
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public List<Shipment> Shipments { get; set; } = new List<Shipment>();
    }
}
