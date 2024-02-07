using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Lesson8;
internal class JsonToXmlConverter
{
    internal static readonly char[] separator = ['\\', '/'];

    public void NormalConverter(string path)
    {
        var pathArr = path.Split(separator).ToList();
        var name = pathArr[^1].Split('.')[0];
        pathArr.RemoveAt(pathArr.Count - 1);
        pathArr.Add($"{name}.xml");
        var newPath = Path.Combine(pathArr.ToArray());

        using (var reader = new StreamReader(new FileStream(path, FileMode.Open)))
        {
            string jsonString = reader.ReadToEnd();
            XDocument
                .Load(JsonReaderWriterFactory
                    .CreateJsonReader(
                        Encoding.ASCII.GetBytes(jsonString),
                        new XmlDictionaryReaderQuotas()))
                .Save(newPath);
        }
    }

    public void Convert(string path)
    {
        using (var stream = new FileStream(path, FileMode.Open))
        {
            var pathArr = path.Split(separator).ToList();
            var name = pathArr[^1].Split('.')[0];
            pathArr.RemoveAt(pathArr.Count - 1);
            pathArr.Add($"{name}.xml");
            var newPath = Path.Combine(pathArr.ToArray());

            var document = JsonDocument.Parse(stream);
            /*XmlElement rootElement = */CreateXmlElement(document.RootElement);
            return;
            //XmlDocument xmlDocument = new XmlDocument();
            //xmlDocument.AppendChild(xmlDocument.ImportNode(rootElement, true));
            //xmlDocument.Save(newPath);
        }
    }
     
    static /*XmlElement*/ void CreateXmlElement(JsonElement jsonElement)

    {

        XmlDocument xmlDocument = new XmlDocument();


        // Создание элемента XML с именем, соответствующим имени элемента JSON

        XmlElement element = xmlDocument.CreateElement(jsonElement.ValueKind.ToString());
        //return null;

        switch (jsonElement.ValueKind)
        {
            case JsonValueKind.Object:
                // Для объекта JSON рекурсивно создаем XML-элементы для каждого свойства
                foreach (JsonProperty property in jsonElement.EnumerateObject())
                {
                    var chEl = xmlDocument.CreateElement(property.Name);
                    chEl.SetAttribute("type", jsonElement.ValueKind.ToString());
                    element.AppendChild(chEl);
                    Console.WriteLine(element.InnerXml);
                    return;
                    /*XmlElement propertyElement = */
                    CreateXmlElement(property.Value);
                    //propertyelement.setattribute("name", property.name);
                    //element.AppendChild(propertyElement);


                    Console.WriteLine(property.Name + " " + property.Value);

                }
                break;
            case JsonValueKind.Array:
                // Для массива JSON рекурсивно создаем XML-элементы для каждого элемента
                foreach (JsonElement arrayElement in jsonElement.EnumerateArray())
                {
                    //XmlElement arrayItemElement = CreateXmlElement(arrayElement);
                    //element.AppendChild(arrayItemElement);

                    Console.WriteLine(arrayElement.ValueKind.ToString());

                }
                break;
            case JsonValueKind.String:
                //element.InnerText = jsonElement.GetString();
                Console.WriteLine(jsonElement.GetString());

                break;
            case JsonValueKind.Number:
            case JsonValueKind.True:
            case JsonValueKind.False:
                //element.InnerText = jsonElement.GetRawText();
                Console.WriteLine(jsonElement.GetRawText());

                break;
            case JsonValueKind.Null:
                //element.SetAttribute("null", "true");
                Console.WriteLine(jsonElement.ToString());

                break;
        }

        //return element;
    }
}


