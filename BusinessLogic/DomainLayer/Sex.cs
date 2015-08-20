using System.Runtime.Serialization;

namespace BusinessLogic.DomainLayer
{
    /// <summary>
    /// Пол
    /// </summary>
    [DataContract]
    public enum Sex
    {
        /// <summary>
        /// Женский
        /// </summary>
        [EnumMember(Value = "0")]
        Female = 0,
        /// <summary>
        /// Мужской
        /// </summary>
        [EnumMember(Value = "1")]
        Male = 1
    }
}
