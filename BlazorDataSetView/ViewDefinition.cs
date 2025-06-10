using BlazorDataSetView.Enums;

namespace BlazorDataSetView;

public class ViewDefinition<TEntity>
{
    public Type? DataSetRecordType => typeof(TEntity);
    public Dictionary<string, (bool Visible, EditableInputTypes EditableType, int DisplayOrder)> DisplayedFields { get; set; } = [];
    public Dictionary<string, (bool Visible, object InitialValue)> FilterableFields { get; set; } = [];
    public required Func<TEntity?, string?, string> FieldFormatter { get; set; }
    public Func<string?, IEnumerable<KeyValuePair<string, object>>>? PossibleValuesForField { get; set; }
}
