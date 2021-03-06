//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YeldaSert.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Evrak = new HashSet<Evrak>();
        }
    
        public int Id { get; set; }
        public string KullaniciTipi { get; set; }
        [Required,DisplayName("Ad�n�z� Giriniz")]
        public string Ad { get; set; }
        [Required, DisplayName("Soyad�n�z� Giriniz")]
        public string Soyad { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
        public string CepTelefonu { get; set; }
        [Required]
        [DisplayName("Email Adresinizi Giriniz")]
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evrak> Evrak { get; set; }
    }
}
