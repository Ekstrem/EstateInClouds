using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using BusinessLogic.DataLayer;

namespace BusinessLogic.DomainLayer
{
    /// <summary>
    /// Тип контакта
    /// </summary>
    [DataContract]
    [Table("ContactTypesTbl")]
    public class ContactType : DbEntity
    {
        /// <summary>
        /// Имя типа
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string Type { get; set; }

        [IgnoreDataMember]
        public override byte[] CurrentHash
        {
            get { return GetSha(Type); }
        }
    }
}