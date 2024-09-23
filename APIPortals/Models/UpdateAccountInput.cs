namespace APIPortals.Net.Models;

public class UpdateAccountInput
{
    public required int accountKey { get; set; }
    public string accountCode { get; set; }
    public int accountTypeKey { get; set; }
    public string parentKey { get; set; }
    public int sourceAccountCode { get; set; }
    public int industrykey { get; set; }
    public string identifier { get; set; }
    public string legalDesc { get; set; }
    public string federalCode { get; set; }
    public string accountDesc { get; set; }
    public string website { get; set; }
}

public class UpdateAccountPayload
{
    public Result result { get; set; }
}

public class Result
{
public bool isSuccess { get; set; }
public bool isFailure { get; set; }
public Error error { get; set; }
}

public class Error
{
    public string code { get; set; }
    public string name { get; set; }
}