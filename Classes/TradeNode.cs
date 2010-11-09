using CookComputing.XmlRpc;
using MolineSoftware.DrupalXmlRpc;

namespace trade {
    public class TradeNode : DrupalNode {
        public TradeNode() : base() { base.Type = "custom_node"; }

        [XmlRpcMember(Member = "field_am_model")]
        public XmlRpcStruct[] _Model { get; set; }

        [XmlRpcMember(Member = "field_imgdirectory")]
        public XmlRpcStruct[] _IMGDir { get; set; }

        [XmlRpcMember(Member = "path")]
        public string _Path { get; set; }

        [XmlRpcMember(Member = "field_chassis")]
        public XmlRpcStruct[] _Chassis { get; set; }

        [XmlRpcMember(Member = "field_tsu")]
        public XmlRpcStruct[] _TSUObozn { get; set; }

        [XmlRpcMember(Member = "field_komplektatsia")]
        public XmlRpcStruct[] _Osobennosti { get; set; }

        [XmlRpcMember(Member = "field_trucktype")]
        public XmlRpcStruct[] _gCategory { get; set; }
    }
}