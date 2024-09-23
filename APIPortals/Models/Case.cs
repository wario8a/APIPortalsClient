namespace APIPortalsClient.Net.Models;

public class ResponseCases
{
    public List<Case> Cases { get; set; }
}

public class Case
{
    public int caseKey { get; set; }
    public string caseCode { get; set; }
    public string sourceCaseCode { get; set; }
    public int statusKey { get; set; }
    public int caseTypeKey { get; set; }
    public int feeZoneKey { get; set; }
    public int officeKey { get; set; }
    public int jurisdictionKey { get; set; }
    public int employerKey { get; set; }
    public int claimantKey { get; set; }
    public int claimNumber { get; set; }
}

public class ResponseCaseById
{
    public Case CaseById { get; set; }
}