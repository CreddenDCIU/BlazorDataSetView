namespace BlazorDataSetViewExamples.Records;

public class ExampleReportRecord
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int? Age => DateOfBirth == null ? null : DateTime.Today.Year - DateOfBirth.Value.Year - 
        (DateTime.Today.Month < DateOfBirth.Value.Month || DateTime.Today.Day < DateOfBirth.Value.Day ? 1 : 0);
    public DateTime? DateOfBirth { get; set; }
    public int RecordTypeId { get; set; }
    public RecordType RecordType
    {
        get => (RecordType)RecordTypeId;
        set
        {
            RecordTypeId = (int)value;
        }
    }
    public bool IsActive { get; set; }
}

public enum RecordType
{
    None = 0,
    Type1 = 1,
    Type2 = 2,
    Type3 = 3
}
