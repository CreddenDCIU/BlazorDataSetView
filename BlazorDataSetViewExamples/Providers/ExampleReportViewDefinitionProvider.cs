using BlazorDataSetView.Enums;
using BlazorDataSetView.Interfaces;
using BlazorDataSetViewExamples.Records;

namespace BlazorDataSetViewExamples.Providers;

public class ExampleReportViewDefinitionProvider : IViewDefinitionProvider
{
    public Dictionary<string, (bool Visible, EditableInputTypes EditableType, int DisplayOrder)> GetDisplayedFieldDictionary<TEntity>() where TEntity : class
    {
        int displayOrder = 0;

        return typeof(TEntity).Name switch
        {
            nameof(ExampleReportRecord) => new()
            {
                { nameof(ExampleReportRecord.Id), (true, EditableInputTypes.NotEditable, displayOrder++) },
                { nameof(ExampleReportRecord.FirstName), (true, EditableInputTypes.InputText, displayOrder++) },
                { nameof(ExampleReportRecord.LastName), (true, EditableInputTypes.InputText, displayOrder++) },
                { nameof(ExampleReportRecord.DateOfBirth), (true, EditableInputTypes.InputDate, displayOrder++) },
                { nameof(ExampleReportRecord.Age), (true, EditableInputTypes.NotEditable, displayOrder++) },
                { nameof(ExampleReportRecord.RecordTypeId), (true, EditableInputTypes.InputNumber, displayOrder++) },
                { nameof(ExampleReportRecord.RecordType), (true, EditableInputTypes.InputSelect, displayOrder++) },
                { nameof(ExampleReportRecord.IsActive), (true, EditableInputTypes.InputCheckbox, displayOrder++) }
            },
            _ => []
        };
    }

    public Func<TEntity?, string?, string> GetFieldFormatterFunc<TEntity>() where TEntity : class
    {
        return typeof(TEntity).Name switch
        {
            nameof(ExampleReportRecord) => GetFieldFormat,
            _ => ((TEntity? inputRecord, string? inputFieldName) => string.Empty)
        };
    }

    public Dictionary<string, (bool Visible, object InitialValue)> GetFilterableFieldDictionary<TEntity>() where TEntity : class
    {
        return [];
    }

    public Func<string?, IEnumerable<KeyValuePair<string, object>>> GetPossibleValuesForField<TEntity>() where TEntity : class
    {
        return typeof(TEntity).Name switch
        {
            nameof(ExampleReportRecord) => GetFieldPossibleValues<ExampleReportRecord>,
            _ => ((string? fieldName) => [])
        };
    }

    public string GetFieldFormat(object? record, string? fieldName)
    {
        return string.Empty;
    }

    public IEnumerable<KeyValuePair<string, object>> GetFieldPossibleValues<TEntity>(string? fieldName) where TEntity : class
    {
        return fieldName switch
        {
            nameof(ExampleReportRecord.RecordType) => new List<KeyValuePair<string, object>>()
            {
                { new KeyValuePair<string, object>(RecordType.None.ToString(), (int)RecordType.None) },
                { new KeyValuePair<string, object>(RecordType.Type1.ToString(), (int)RecordType.Type1) },
                { new KeyValuePair<string, object>(RecordType.Type2.ToString(), (int)RecordType.Type2) },
                { new KeyValuePair<string, object>(RecordType.Type3.ToString(), (int)RecordType.Type3) }
            },
            _ => []
        };
    }
}
