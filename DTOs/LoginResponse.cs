namespace Iyde.Attendance.Variant3.DTOs
{
    public class LoginResponse
    {
        public string UserName { get; set; }
        public int? CompanyId { get; set; }

        // YENİ: Həmin şirkətə aid mağazaların siyahısı
        public List<GetAllStoreDto> Stores { get; set; }
    }
}
