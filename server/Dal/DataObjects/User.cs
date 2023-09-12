namespace DL.DataObjects;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime SubscriptionPeriodDate { get; set; }
    private bool isSubscriptionPeriodValid;

    public bool IsSubscriptionPeriodValid
    {
        get { return SubscriptionPeriodDate < DateTime.Now; }
        set { isSubscriptionPeriodValid = SubscriptionPeriodDate < DateTime.Now; }
    }

    //public bool? IsSubscriptionPeriodValid { get; set; }
    public User()
    {

    }

}
