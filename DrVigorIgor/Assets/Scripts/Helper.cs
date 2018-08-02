using System.IO;
using System.Xml.Serialization;

public static class Helper
{
    public static string Serialize<T>(this T toSerialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StringWriter w = new StringWriter();
        xml.Serialize(w, toSerialize);
        return w.ToString();
    }

    public static T Deserialize<T>(this string toDeserialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StringReader r = new StringReader(toDeserialize);
        return (T)xml.Deserialize(r);
    }
}