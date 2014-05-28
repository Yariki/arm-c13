using System;

namespace ARM.Module.ViewModel.Reports.LetterTemplate
{
    /// <summary>
    /// Клас що представляє собою модель шаблона листа. Шаблон розміщения у файлі локалізації.
    /// </summary>
    [Serializable]
    [System.Xml.Serialization.XmlRoot("lettertemplate")]
    public class ARMLetterTemplate
    {
        [System.Xml.Serialization.XmlElement("header")]
        public string Header { get; set; }
        [System.Xml.Serialization.XmlElement("body")]
        public string Body { get; set; }
        [System.Xml.Serialization.XmlElement("footer")]
        public string Footer { get; set; }
    }
}