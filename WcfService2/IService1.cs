using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService2
{
    [ServiceContract]
    public interface IService1



    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Art/GetAllArt/",
           BodyStyle = WebMessageBodyStyle.Wrapped,
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json)]
        List<Art> GetArts();



        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/Art/GetArt/{ArtId}",
             BodyStyle = WebMessageBodyStyle.Wrapped,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json)]
        Art GetArtById(string ArtId);



        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Art/UpdateArt/{ArtId}/{Buyer}",
             BodyStyle = WebMessageBodyStyle.Wrapped,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json)]
        string UpdateArt(string ArtId, string Buyer);



        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Art/AddArt/{ArtId}/{Artist}/{Style}/{Title}/{Price}/{Buyer}/{Location}",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string Add(string ArtId, string Artist, string Style, string Title, string Price, string Buyer, string Location);



        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Art/DeleteArt/{ArtId}",
              BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
              ResponseFormat = WebMessageFormat.Json)]
        string DeleteArt(string ArtId);
    }
}

namespace WcfService2



{
    [DataContract]
    public class Art
    {
        int Aid;
        string Aname;
        string Astyle;
        string Atitle;
        string Abuyer;
        string Alocation;
        int Aprice;



        [DataMember]
        public int ArtId
        {
            get { return Aid; }
            set { Aid = value; }
        }
        [DataMember]
        public string Artist
        {
            get { return Aname; }
            set { Aname = value; }
        }
        [DataMember]
        public string Style
        {
            get { return Astyle; }
            set { Astyle = value; }
        }
        [DataMember]
        public string Title
        {
            get { return Atitle; }
            set { Atitle = value; }
        }
        [DataMember]
        public string Buyer
        {
            get { return Abuyer; }
            set { Abuyer = value; }
        }
        [DataMember]
        public string Location
        {
            get { return Alocation; }
            set { Alocation = value; }
        }
        [DataMember]
        public int Price
        {
            get { return Aprice; }
            set => Aprice = value;
        }



    }
}