using System.Runtime.Serialization;

namespace Domain;

public enum FieldCell
{
    [EnumMember(Value = " ")]
    None = ' ',
    [EnumMember(Value = "0")]
    Zero = '0',
    [EnumMember(Value = "1")]
    One,
    [EnumMember(Value = "2")]
    Two,
    [EnumMember(Value = "3")]
    Three,
    [EnumMember(Value = "4")]
    Four,
    [EnumMember(Value = "5")]
    Five,
    [EnumMember(Value = "6")]
    Six,
    [EnumMember(Value = "7")]
    Seven,
    [EnumMember(Value = "8")]
    Eight,
    [EnumMember(Value = "M")]
    M = 'M',
    [EnumMember(Value = "X")]
    X = 'X'
};
