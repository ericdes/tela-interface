//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITela
{
    
    
    /// <summary>
    /// 
    /// </summary>
    public class TransportationStatusRecord : ITela.CodeValue
    {
        
        public string code { get; private set; }
        
        public string name { get; private set; }
        
        public string description { get; set; }
        
        public TransportationStatusRecord(string code, string name) : 
                base(code, name)
        {
            this.code = code;
            this.name = name;
        }
    }
}
