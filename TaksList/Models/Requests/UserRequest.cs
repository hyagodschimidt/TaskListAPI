using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace TaksList.Models.Requests
{
    public class UserRequest
    {
        public string Name{ get; set; }
        public string PhoneNumber { get; set; }
    }
}
