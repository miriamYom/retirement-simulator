using System.Reflection;

namespace BL.DTO;

public class UserDTO
{
    public string? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime SubscriptionPeriodDate { get; set; }

    //private bool isSubscriptionPeriodValid;

    //public bool IsSubscriptionPeriodValid
    //{
    //    get { return SubscriptionPeriodDate < DateTime.Now; }
    //    set { isSubscriptionPeriodValid = SubscriptionPeriodDate < DateTime.Now; ; }
    //}
    //public bool IsSubscriptionPeriodValid { get; set; }
    public UserDTO()
    {
        //foreach (PropertyInfo p in this.GetType().GetProperties())
        //{
        //    if (p.PropertyType == typeof(string)) p.SetValue(this, string.Empty);
        //}
    }
}
