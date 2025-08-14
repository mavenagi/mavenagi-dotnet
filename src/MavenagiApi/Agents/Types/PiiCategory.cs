using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MavenagiApi.Core;

namespace MavenagiApi;

[JsonConverter(typeof(EnumSerializer<PiiCategory>))]
public enum PiiCategory
{
    [EnumMember(Value = "Name")]
    Name,

    [EnumMember(Value = "Email")]
    Email,

    [EnumMember(Value = "PhoneNumber")]
    PhoneNumber,

    [EnumMember(Value = "StreetAddress")]
    StreetAddress,

    [EnumMember(Value = "CreditCardNumber")]
    CreditCardNumber,

    [EnumMember(Value = "UsBankAccountNumber")]
    UsBankAccountNumber,

    [EnumMember(Value = "UsSocialSecurityNumber")]
    UsSocialSecurityNumber,

    [EnumMember(Value = "UsUkPassportNumber")]
    UsUkPassportNumber,

    [EnumMember(Value = "UsDriversLicenseNumber")]
    UsDriversLicenseNumber,

    [EnumMember(Value = "Date")]
    Date,

    [EnumMember(Value = "IpAddress")]
    IpAddress,

    [EnumMember(Value = "Url")]
    Url,

    [EnumMember(Value = "AbaRoutingNumber")]
    AbaRoutingNumber,

    [EnumMember(Value = "Age")]
    Age,

    [EnumMember(Value = "SwiftCode")]
    SwiftCode,

    [EnumMember(Value = "AuBankAccountNumber")]
    AuBankAccountNumber,

    [EnumMember(Value = "AuBusinessNumber")]
    AuBusinessNumber,

    [EnumMember(Value = "AuCompanyNumber")]
    AuCompanyNumber,

    [EnumMember(Value = "AuDriversLicenseNumber")]
    AuDriversLicenseNumber,

    [EnumMember(Value = "AuMedicalAccountNumber")]
    AuMedicalAccountNumber,

    [EnumMember(Value = "AuPassportNumber")]
    AuPassportNumber,

    [EnumMember(Value = "AuTaxFileNumber")]
    AuTaxFileNumber,

    [EnumMember(Value = "CaBankAccountNumber")]
    CaBankAccountNumber,

    [EnumMember(Value = "CaDriversLicenseNumber")]
    CaDriversLicenseNumber,

    [EnumMember(Value = "CaHealthServiceNumber")]
    CaHealthServiceNumber,

    [EnumMember(Value = "CaPassportNumber")]
    CaPassportNumber,

    [EnumMember(Value = "CaPersonalHealthIdentification")]
    CaPersonalHealthIdentification,

    [EnumMember(Value = "CaSocialInsuranceNumber")]
    CaSocialInsuranceNumber,

    [EnumMember(Value = "EsDni")]
    EsDni,

    [EnumMember(Value = "EsSocialSecurityNumber")]
    EsSocialSecurityNumber,

    [EnumMember(Value = "EsTaxIdentificationNumber")]
    EsTaxIdentificationNumber,

    [EnumMember(Value = "EuDebitCardNumber")]
    EuDebitCardNumber,

    [EnumMember(Value = "EuDriversLicenseNumber")]
    EuDriversLicenseNumber,

    [EnumMember(Value = "EuGpsCoordinates")]
    EuGpsCoordinates,

    [EnumMember(Value = "EuNationalIdentificationNumber")]
    EuNationalIdentificationNumber,

    [EnumMember(Value = "EuPassportNumber")]
    EuPassportNumber,

    [EnumMember(Value = "EuSocialSecurityNumber")]
    EuSocialSecurityNumber,

    [EnumMember(Value = "EuTaxIdentificationNumber")]
    EuTaxIdentificationNumber,

    [EnumMember(Value = "FrDriversLicenseNumber")]
    FrDriversLicenseNumber,

    [EnumMember(Value = "FrHealthInsuranceNumber")]
    FrHealthInsuranceNumber,

    [EnumMember(Value = "FrNationalId")]
    FrNationalId,

    [EnumMember(Value = "FrPassportNumber")]
    FrPassportNumber,

    [EnumMember(Value = "FrSocialSecurityNumber")]
    FrSocialSecurityNumber,

    [EnumMember(Value = "FrTaxIdentificationNumber")]
    FrTaxIdentificationNumber,

    [EnumMember(Value = "FrValueAddedTaxNumber")]
    FrValueAddedTaxNumber,

    [EnumMember(Value = "InternationalBankingAccountNumber")]
    InternationalBankingAccountNumber,

    [EnumMember(Value = "NzBankAccountNumber")]
    NzBankAccountNumber,

    [EnumMember(Value = "NzDriversLicenseNumber")]
    NzDriversLicenseNumber,

    [EnumMember(Value = "NzInlandRevenueNumber")]
    NzInlandRevenueNumber,

    [EnumMember(Value = "NzMinistryOfHealthNumber")]
    NzMinistryOfHealthNumber,

    [EnumMember(Value = "NzSocialWelfareNumber")]
    NzSocialWelfareNumber,

    [EnumMember(Value = "UkDriversLicenseNumber")]
    UkDriversLicenseNumber,

    [EnumMember(Value = "UkElectoralRollNumber")]
    UkElectoralRollNumber,

    [EnumMember(Value = "UkNationalHealthNumber")]
    UkNationalHealthNumber,

    [EnumMember(Value = "UkNationalInsuranceNumber")]
    UkNationalInsuranceNumber,

    [EnumMember(Value = "UkUniqueTaxpayerNumber")]
    UkUniqueTaxpayerNumber,

    [EnumMember(Value = "UsIndividualTaxpayerIdentification")]
    UsIndividualTaxpayerIdentification,
}
