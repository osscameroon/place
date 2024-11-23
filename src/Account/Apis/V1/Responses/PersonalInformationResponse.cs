using Account.Application.Queries.GetPersonalInformation;

namespace Account.Apis.V1.Responses;

public class PersonalInformationResponse
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? ZipCode { get; set; }
    public string? Country { get; set; }
    public string? Gender { get; set; }
    public string FormattedAddress { get; set; } = null!;
}