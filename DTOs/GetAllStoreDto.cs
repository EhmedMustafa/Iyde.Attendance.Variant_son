namespace Iyde.Attendance.Variant3.DTOs
{
    public class GetAllStoreDto
    {
        public int Id { get; set; }
        public string StoreName { get; set; } = string.Empty;

        public int? CompanyId { get; set; }
        
        //public string CompanyName { get; set; }
    }
}
