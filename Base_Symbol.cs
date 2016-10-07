//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataTransaction
{
    using System;
    using System.Collections.Generic;
    
    public partial class Base_Symbol
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Base_Symbol()
        {
            this.Symbols = new HashSet<Symbol>();
        }
    
        public int Base_Symbol_ID { get; set; }
        public string Base_Symbol1 { get; set; }
        public string Description { get; set; }
        public int Price_Format { get; set; }
        public decimal Tick_Size { get; set; }
        public decimal PL_Per_Tick { get; set; }
        public int Contract_Kind_ID { get; set; }
        public decimal Contract_Size { get; set; }
        public int Segment_ID { get; set; }
        public int Exchange_ID { get; set; }
        public int Currency_ID { get; set; }
        public System.TimeSpan Start_Time { get; set; }
        public System.TimeSpan End_Time { get; set; }
        public string TimeZone_Offset { get; set; }
        public Nullable<int> Margin_Type_ID { get; set; }
        public Nullable<decimal> Initial_Margin { get; set; }
        public Nullable<decimal> Maintainance_Margin { get; set; }
        public int Commission_Type_ID { get; set; }
        public decimal Commission { get; set; }
        public int Sector_ID { get; set; }
        public decimal DevidedBy { get; set; }
        public decimal MultipliedBy { get; set; }
    
        public virtual Commission_Types Commission_Types { get; set; }
        public virtual ContractKind ContractKind { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Exchange Exchange { get; set; }
        public virtual Margin_Types Margin_Types { get; set; }
        public virtual Sector Sector { get; set; }
        public virtual Segment Segment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Symbol> Symbols { get; set; }
    }
}
