using CookComputing.XmlRpc;
using MolineSoftware.DrupalXmlRpc;

namespace trade {
    public class CustomNode : DrupalNode {
        public CustomNode() : base() { base.Type = "custom_node"; }

        [XmlRpcMember(Member = "field_am_model")]
        public XmlRpcStruct[] _Model { get; set; }

        [XmlRpcMember(Member = "field_imgdirectory")]
        public XmlRpcStruct[] _IMGDir { get; set; }

        [XmlRpcMember(Member = "path")]
        public string _Path { get; set; }

        [XmlRpcMember(Member = "field_chassis")]
        public XmlRpcStruct[] _Chassis { get; set; }

        [XmlRpcMember(Member = "field_transmission")]
        public XmlRpcStruct[] _KPP { get; set; }

        [XmlRpcMember(Member = "field_spaln")]
        public XmlRpcStruct[] _Spaln { get; set; }

        [XmlRpcMember(Member = "field_wheels")]
        public XmlRpcStruct[] _KF { get; set; }

        [XmlRpcMember(Member = "field_gruzpod")]
        public XmlRpcStruct[] _Gruzpod { get; set; }

        [XmlRpcMember(Member = "field_vplatf_dl_ramy")]
        public XmlRpcStruct[] _VMontazhn { get; set; }

//        [XmlRpcMember(Member = "field_draw")]
//        public XmlRpcStruct[] _Draw { get; set; }

//        [XmlRpcMember(Member = "field_model_photo")]
//        public XmlRpcStruct[] _Photo { get; set; }

        [XmlRpcMember(Member = "field_gaslitre")]
        public XmlRpcStruct[] _Fuel { get; set; }

        [XmlRpcMember(Member = "field_tsu")]
        public XmlRpcStruct[] _TSUObozn { get; set; }

        [XmlRpcMember(Member = "field_komplektatsia")]
        public XmlRpcStruct[] _Osobennosti { get; set; }

        [XmlRpcMember(Member = "field_trucktype")]
        public XmlRpcStruct[] _gCategory { get; set; }

        [XmlRpcMember(Member = "field_engine")]
        public XmlRpcStruct[] _Engine { get; set; }

        [XmlRpcMember(Member = "field_power")]
        public XmlRpcStruct[] _Horse { get; set; }

        [XmlRpcMember(Member = "field_oshinov")]
        public XmlRpcStruct[] _Oshinov { get; set; }
    }
}
