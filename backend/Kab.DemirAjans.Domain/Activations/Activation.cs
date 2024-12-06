using Kab.DemirAjans.Domain.Users;
using System.ComponentModel.DataAnnotations;
using Kab.DemirAjans.Domain.ExtraProperties;
using System;

namespace Kab.DemirAjans.Domain.Activations;

public class Activation : AuditedAggregateRoot
{
    public int Id { get; set; }

    [MaxLength(UserConst.MaxEmailLength)]
    [Required]
    public string Email { get; set; }

    [MaxLength(ActivationConst.MaxCodeLength)]
    [Required]
    public string Code { get; set; }
    public DateTime ExpirationDate { get; set; }

    public Activation(int id, string email, string code, DateTime expirationDate)
    {
        SetDefaultExtraProperties(false);
        SetEmail(email);    
        SetCode(code);
        SetExpirationDate(expirationDate);
    }

    public Activation(string email, string code, DateTime expirationDate)
    {
        SetDefaultExtraProperties(true);
        SetEmail(email);
        SetCode(code);
        SetExpirationDate(expirationDate);
    }

    public void SetEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            throw new ArgumentNullException("Mail adresi boş olamaz!");
        if (email.Length > UserConst.MaxEmailLength)
            throw new ArgumentException($"Mail adresi uzunluğu {UserConst.MaxEmailLength} 'ten büyük olamaz!");

        Email = email;
    }

    public void SetCode(string code)
    {
        if (string.IsNullOrEmpty(code))
            throw new ArgumentNullException("Aktivasyon kodu boş olamaz!");
        if (code.Length > ActivationConst.MaxCodeLength)
            throw new ArgumentException($"Aktivasyon kodu uzunluğu {ActivationConst.MaxCodeLength} 'ten büyük olamaz!");

        Code = code;
    }

    public void SetExpirationDate(DateTime expirationDate)
    {
        ExpirationDate = expirationDate;
    }
}