﻿using System;

namespace ARM.Module.ViewModel.Reports.AcademicArrears
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("lettertemplate")]
    public class ARMAcademicArrearsLetterTemplate
    {
        [System.Xml.Serialization.XmlElement("header")]
        public string Header { get; set; }
        [System.Xml.Serialization.XmlElement("body")]
        public string Body { get; set; }
        [System.Xml.Serialization.XmlElement("footer")]
        public string Footer { get; set; }
    }
}