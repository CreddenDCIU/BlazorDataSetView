namespace BlazorDataSetView.Interfaces;

public interface IViewDefinitionProvider
{
    public Dictionary<string, (bool Visible, int DisplayOrder)> GetDisplayedFieldDictionary<TEntity>() where TEntity : class;
    public Dictionary<string, (bool Visible, object InitialValue)> GetFilterableFieldDictionary<TEntity>() where TEntity : class;
    public Func<TEntity?, string?, string> GetFieldFormatterFunc<TEntity>() where TEntity : class;
}
