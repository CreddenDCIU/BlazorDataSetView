﻿using BlazorDataSetView.Enums;
using BlazorDataSetView.Interfaces;

namespace BlazorDataSetView.Providers;

public class DefaultViewDefinitionProvider : IViewDefinitionProvider
{
    public Dictionary<string, (bool Visible, EditableInputTypes EditableType, int DisplayOrder)> GetDisplayedFieldDictionary<TEntity>() where TEntity : class
    {
        var properties = typeof(TEntity).GetProperties();
        Dictionary<string, (bool Visible, EditableInputTypes EditableType, int DisplayOrder)> retVal = [];

        foreach (var property in properties)
        {
            retVal.Add(property.Name, (true, EditableInputTypes.NotEditable, 0));
        }

        return retVal;
    }

    public Dictionary<string, (bool Visible, object InitialValue)> GetFilterableFieldDictionary<TEntity>() where TEntity : class 
        => [];

    public Func<TEntity?, string?, string> GetFieldFormatterFunc<TEntity>() where TEntity : class
        => ((TEntity? inputRecord, string? inputFieldName) => string.Empty);

    public Func<string?, IEnumerable<KeyValuePair<string, object>>?> GetPossibleValuesForField<TEntity>() where TEntity : class
        => ((string? inputFieldName) => []);
}
