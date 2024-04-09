using System.Text.Json.Serialization;

namespace PL.ViewModels
{
    public class PersonViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("dateOfBirth")]
        public DateOnly DateOfBirth { get; set; }
        [JsonPropertyName("isMarried")]
        public bool IsMarried { get; set; }
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonPropertyName("salary")]
        public decimal Salary { get; set; }
        public PersonViewModel() { }
    }
}
