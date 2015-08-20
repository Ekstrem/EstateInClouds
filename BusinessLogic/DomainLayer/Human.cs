using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using BusinessLogic.DataLayer;

namespace BusinessLogic.DomainLayer
{
    /// <summary>
    /// Базовый класс человека
    /// </summary>
    [DataContract]
    [Table("PeopleTbl")]
    public class Human : DbEntity
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(25)]
        public string SecondName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(15)]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        [DataMember]
        [StringLength(15)]
        public string MiddleName { get; set; }

        private DateTime? _birthDay;
        /// <summary>
        /// Дата рождения
        /// </summary>
        [DataMember]
        public string BirthDay
        {
            get
            {
                return _birthDay.HasValue
                    ? _birthDay.Value.ToString("d")
                    : null;
            }
            set
            {
                DateTime date;
                if (DateTime.TryParse(value, out date))
                {
                    _birthDay = date;
                }
            }
        }

        /// <summary>
        /// Пол
        /// </summary>
        [DataMember]
        [Required]
        public Sex Sex { get; set; }

        /// <summary>
        /// Контакты
        /// </summary>
        [DataMember]
        public ICollection<Contact> Contacts { get; set; }

        [IgnoreDataMember]
        public override byte[] CurrentHash
        {
            get
            {
                return GetSha(
                    SecondName+FirstName+MiddleName+
                    Sex+BirthDay+
                    Contacts.Count);
            }
        }

        public Human()
        {
            Contacts = new HashSet<Contact>();
        }

    }
}
