using Entities.LinkModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Entities.Models;

public class Entity : DynamicObject, IXmlSerializable, IDictionary<string, object>
{
    private readonly string _rootTag = "Entity";
    private readonly IDictionary<string, object> _dictionary;

    public Entity()
    {
        _dictionary = new Dictionary<string, object>();
    }

    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        return _dictionary.TryGetValue(binder.Name, out result);
    }

    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
        _dictionary[binder.Name] = value;
        return true;
    }

    public XmlSchema GetSchema()
    {
        return null;
    }

    public void ReadXml(XmlReader reader)
    {
        reader.ReadStartElement(_rootTag);
        while (reader.IsStartElement())
        {
            var key = reader.Name;
            reader.ReadStartElement(key);
            var value = reader.ReadContentAsObject();
            reader.ReadEndElement();
            _dictionary.Add(key, value);
        }
        reader.ReadEndElement();
    }

    public void WriteXml(XmlWriter writer)
    {
        foreach (var key in _dictionary.Keys)
        {
            var value = _dictionary[key];
            writer.WriteStartElement(key);
            writer.WriteValue(value);
            writer.WriteEndElement();
        }
    }

    private void WriteLinksToXml(string key, object value, XmlWriter writer)
    {
        writer.WriteStartElement(key);

        if (value.GetType() == typeof(List<Link>))
        {
            foreach (var val in value as List<Link>)
            {
                writer.WriteStartElement(nameof(Link));
                WriteLinksToXml(nameof(val.Href), val.Href, writer);
                WriteLinksToXml(nameof(val.Method), val.Method, writer);
                WriteLinksToXml(nameof(val.Rel), val.Rel, writer);
                writer.WriteEndElement();
            }
        }
        else
        {
            writer.WriteString(value.ToString());
        }

        writer.WriteEndElement();
    }

    // Реализация интерфейса IDictionary для поддержки работы DataShaper
    public void Add(string key, object value) => _dictionary.Add(key, value);
    public bool ContainsKey(string key) => _dictionary.ContainsKey(key);
    public bool Remove(string key) => _dictionary.Remove(key);
    public bool TryGetValue(string key, out object value) => _dictionary.TryGetValue(key, out value);
    public object this[string key] { get => _dictionary[key]; set => _dictionary[key] = value; }
    public ICollection<string> Keys => _dictionary.Keys;
    public ICollection<object> Values => _dictionary.Values;
    public int Count => _dictionary.Count;
    public bool IsReadOnly => _dictionary.IsReadOnly;
    public void Add(KeyValuePair<string, object> item) => _dictionary.Add(item);
    public void Clear() => _dictionary.Clear();
    public bool Contains(KeyValuePair<string, object> item) => _dictionary.Contains(item);
    public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex) => _dictionary.CopyTo(array, arrayIndex);
    public bool Remove(KeyValuePair<string, object> item) => _dictionary.Remove(item);
    public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _dictionary.GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => _dictionary.GetEnumerator();
}