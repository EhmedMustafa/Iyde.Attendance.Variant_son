namespace Iyde.Attendance.Variant3.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Store> Stores { get; set; }
    }
}
