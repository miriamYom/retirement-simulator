namespace BL;

public class InvalidParameterException : Exception
{
    public InvalidParameterException(string message)
       : base(message)
    {
        //this.Message = message;
    }
    public InvalidParameterException()
         : base("Parameter is not valid")
    {

    }
    public override string Message => "Parameter is not valid";
}

public class InvalidDateException : Exception
{
    public InvalidDateException(string message)
       : base(message)
    {
    }
    public override string Message => "Date is not valid";
}
public class SubscriptionIsNotValid : Exception
{
    public SubscriptionIsNotValid(/*string message*/)
       //: base(message)
    {
    }
    public override string Message => "The subscription is not valid";
}