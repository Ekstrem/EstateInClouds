using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using BusinessLogic.DataLayer;

namespace BusinessLogic.DomainLayer
{
    /// <summary>
    /// Контакт
    /// </summary>
    [DataContract]
    [Table("ContactsTbl")]
    public class Contact : DbEntity
    {
        /// <summary>
        /// Тип контакта
        /// </summary>
        [DataMember]
        public Guid TypeID { get; set; }

        [IgnoreDataMember]
        [ForeignKey("TypeID")]
        public virtual ContactType Type { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string Value { get; set; }

        [IgnoreDataMember]
        public override byte[] CurrentHash
        {
            get
            {
                return GetSha(TypeID + Value);
            }
        }
    }
}
