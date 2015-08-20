using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using BusinessLogic.DataLayer;

namespace BusinessLogic.DomainLayer
{
    [DataContract]
    [Table("AddressTbl")]
    public class Address : DbEntity
    {
        /// <summary>
        /// Страна
        /// </summary>
        [DataMember]
        [Required]
        public string Country { get; set; }

        /// <summary>
        /// Субъект
        /// </summary>
        [DataMember]
        [Required]
        public string State { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        [DataMember]
        [Required]
        public string City { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        [DataMember]
        [Required]
        public string Street { get; set; }

        /// <summary>
        /// Дом
        /// </summary>
        [DataMember]
        public string House { get; set; }

        /// <summary>
        /// Квартира
        /// </summary>
        [DataMember]
        public int? Appartment { get; set; }

        /// <summary>
        /// Текущий Хэш
        /// </summary>
        [IgnoreDataMember]
        public override byte[] CurrentHash
        {
            get
            {
                return GetSha(
                    Country + State + City +
                    Street + House + Appartment);

            }
        }

        /// <summary>
        /// Конструктор для белгородского адреса
        /// </summary>
        /// <param name="street">Улица</param>
        /// <param name="house">Дом</param>
        /// <param name="appartment">Квартира</param>
        /// <returns>Адрес</returns>
        public static Address CreadBelgorodAddress(
            string street,
            string house,
            int appartment)
        {
            return new Address
            {
                Country = "Россия",
                State = "Белгородская область",
                City = "Белгород"
            };
        }
    }
}
