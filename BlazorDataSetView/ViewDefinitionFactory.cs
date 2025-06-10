using BlazorDataSetView.Interfaces;
using BlazorDataSetView.Providers;

namespace BlazorDataSetView;

public class ViewDefinitionFactory
{
    public static ViewDefinition<TEntity> Create<TEntity>(IViewDefinitionProvider? provider = null) where TEntity : class
    {
        provider ??= new DefaultViewDefinitionProvider();

        return new()
        {
            DisplayedFields = provider.GetDisplayedFieldDictionary<TEntity>(),
            FilterableFields = provider.GetFilterableFieldDictionary<TEntity>(),
            FieldFormatter = provider.GetFieldFormatterFunc<TEntity>(),
            PossibleValuesForField = provider.GetPossibleValuesForField<TEntity>()
        };
    }
}