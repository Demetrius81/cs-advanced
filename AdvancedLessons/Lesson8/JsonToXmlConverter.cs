using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Lesson8;

/// <summary>
/// Converter Json to XML
/// </summary>
internal class JsonToXmlConverter
{
    internal static readonly char[] separator = ['\\', '/'];

    /// <summary>
    /// Method convert JSON file to XML file
    /// </summary>
    /// <param name="path">Valid path to JSON file</param>
    public void EasyConvert(string path)
    {
        using (var reader = new StreamReader(new FileStream(path, FileMode.Open)))
        {
            XDocument
                .Load(JsonReaderWriterFactory
                    .CreateJsonReader(
                        Encoding.ASCII.GetBytes(reader.ReadToEnd()),
                        new XmlDictionaryReaderQuotas()))
                .Save(GetOutputPath(path));
        }
    }

    /// <summary>
    /// Method convert JSON file to XML file
    /// </summary>
    /// <param name="path">Valid path to JSON file</param>
    public void Convert(string path)
    {
        using (var stream = new FileStream(path, FileMode.Open))
        {
            var document = JsonDocument.Parse(stream);
            var xmlDocument = new XDocument();
            xmlDocument.Add(new XElement("root", new XAttribute("type", "object")));
            ConvertJsonToXml(document.RootElement, xmlDocument.Root);

            xmlDocument.Save(GetOutputPath(path));
        }
    }

    /// <summary>
    /// Method convert JSON element to XML element
    /// </summary>
    /// <param name="jsonElement">parent JSON element to convert</param>
    /// <param name="xmlElement">parent XML element</param>
    /// <exception cref="ArgumentException">thrown if JsonValueKind of element is not valid</exception>
    private void ConvertJsonToXml(JsonElement jsonElement, XElement xmlElement)
    {
        foreach (JsonProperty jsonProperty in jsonElement.EnumerateObject())
        {
            XElement childXmlElement;
            switch (jsonProperty.Value.ValueKind)
            {
                case JsonValueKind.Object:
                    childXmlElement = new XElement(
                        $$"""{{jsonProperty.Name}}""",
                        new XAttribute("type", jsonProperty.Value.ValueKind.ToString()));

                    xmlElement.Add(childXmlElement);
                    ConvertJsonToXml(jsonProperty.Value, childXmlElement);
                    break;
                case JsonValueKind.Array:
                    foreach (JsonElement arrayElement in jsonProperty.Value.EnumerateArray())
                    {
                        childXmlElement = new XElement(
                            $$"""{{jsonProperty.Name}}""",
                            new XAttribute("type", jsonProperty.Value.ValueKind.ToString()));

                        xmlElement.Add(childXmlElement);
                        ConvertJsonToXml(arrayElement, childXmlElement);
                    }
                    break;
                case JsonValueKind.String:
                    childXmlElement = new XElement(
                        $$"""{{jsonProperty.Name}}""",
                        new XAttribute("type", jsonProperty.Value.ValueKind.ToString()),
                        jsonProperty.Value.GetString());

                    xmlElement.Add(childXmlElement);
                    break;
                case JsonValueKind.True | JsonValueKind.False:
                    childXmlElement = new XElement(
                        $$"""{{jsonProperty.Name}}""",
                        new XAttribute("type", jsonProperty.Value.ValueKind.ToString()),
                        jsonProperty.Value.GetBoolean());

                    xmlElement.Add(childXmlElement);
                    break;
                case JsonValueKind.Number:
                    childXmlElement = new XElement(
                        $$"""{{jsonProperty.Name}}""",
                        new XAttribute("type", jsonProperty.Value.ValueKind.ToString()),
                        jsonProperty.Value.GetRawText());

                    xmlElement.Add(childXmlElement);
                    break;
                default:
                    throw new ArgumentException($"Something broken in JsonToXmlConverter.ConvertJsonToXml.");
            }
        }


    }

    /// <summary>
    /// Method creat path to save XML file in same directory
    /// </summary>
    /// <param name="path">Path to JSON file</param>
    /// <returns>Path to save new XML file</returns>
    private string GetOutputPath(string path)
    {
        var pathArr = path.Split(separator).ToList();
        var name = pathArr[^1].Split('.')[0];
        pathArr.RemoveAt(pathArr.Count - 1);
        pathArr.Add($"{name}.xml");

        return Path.Combine(pathArr.ToArray());
    }



}


