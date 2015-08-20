using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLogic.DataLayer
{
    public abstract class DbEntity
    {
        private const int _hashSize = 64;

        /// <summary>
        /// Идентификатор сущности в БД
        /// </summary>
        [DataMember]
        [Key]
        public Guid ID { get; set; }

        private byte[] _hash = new byte[_hashSize];

        [IgnoreDataMember]
        public abstract byte[] CurrentHash { get; }

        /// <summary>
        /// Хэш в БД
        /// </summary>
        [DataMember]
        public byte[] Hash { get; set; }

        protected static byte[] GetSha(string source)
        {
            using (var md5Hash = SHA512.Create())
            {
                return md5Hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }
        }
    }
}