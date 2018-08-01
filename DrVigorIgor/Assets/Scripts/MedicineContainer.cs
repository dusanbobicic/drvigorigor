using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("MedicineCollection")]
public class MedicineContainer {
    [XmlArray("Medicines")]
    [XmlArrayItem("Medicine")]
    public List<Medicine> Medicines = new List<Medicine>();
}
