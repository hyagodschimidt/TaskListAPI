namespace TaksList.Models.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required string PhoneNumber { get; set; }
    }
}
