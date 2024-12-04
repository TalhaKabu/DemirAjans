using Kab.DemirAjans.Domain.ExtraProperties;
using System.ComponentModel.DataAnnotations;
using System;

namespace Kab.DemirAjans.Domain.Users;

public class User : AuditedAggregateRoot
{
    public int Id { get; protected set; }

    [Required]
    [MaxLength(UserConst.MaxUserNameLength)]
    public string Username { get; protected set; }

    [Required]
    [MaxLength(UserConst.MaxPasswordLength)]
    public string Password { get; protected set; }

    [Required]
    [MaxLength(UserConst.MaxNameLength)]
    public string Name { get; protected set; }

    [Required]
    [MaxLength(UserConst.MaxLastNameLength)]
    public string LastName { get; protected set; }

    [Required]
    [MaxLength(UserConst.MaxEmailLength)]
    public string Email { get; protected set; }

    public bool IsAdmin { get; protected set; }

    public User(int id, string username, string password, string name, string lastName, string email, bool isAdmin)
    {
        SetDefaultExtraProperties(false);
        SetUserName(username);
        SetPassword(password);
        SetName(name);
        SetLastName(lastName);
        SetEmail(email);
        SetIsAdmin(isAdmin);
    }

    public User( string username, string password, string name, string lastName, string email, bool isAdmin)
    {
        SetDefaultExtraProperties(true);
        SetUserName(username);
        SetPassword(password);
        SetName(name);
        SetLastName(lastName);
        SetEmail(email);
        SetIsAdmin(isAdmin);
    }

    public void SetUserName(string userName)
    {
        if (string.IsNullOrEmpty(userName))
            throw new ArgumentException("Şifre alanı boş olamaz!");
        if (userName.Length > UserConst.MaxUserNameLength)
            throw new ArgumentException($"Şifre uzunluğu {UserConst.MaxUserNameLength} 'ten büyük olamaz!");

        Username = userName;
    }

    public void SetPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("Şifre alanı boş olamaz!");
        if (password.Length > UserConst.MaxPasswordLength)
            throw new ArgumentException($"Şifre uzunluğu {UserConst.MaxPasswordLength} 'ten büyük olamaz!");

        Password = password;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Ad alanı boş olamaz!");
        if (name.Length > UserConst.MaxNameLength)
            throw new ArgumentException($"Ad uzunluğu {UserConst.MaxNameLength} 'ten büyük olamaz!");

        Name = name;
    }

    public void SetLastName(string lastName)
    {
        if (string.IsNullOrEmpty(lastName))
            throw new ArgumentException("Soyadı alanı boş olamaz!");
        if (lastName.Length > UserConst.MaxLastNameLength)
            throw new ArgumentException($"Soyadı uzunluğu {UserConst.MaxLastNameLength} 'ten büyük olamaz!");

        LastName = lastName;
    }

    public void SetEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            throw new ArgumentException("Email alanı boş olamaz!");
        if (email.Length > UserConst.MaxEmailLength)
            throw new ArgumentException($"Email uzunluğu {UserConst.MaxEmailLength} 'ten büyük olamaz!");

        Email = email;
    }

    public void SetIsAdmin(bool isAdmin)
    {
        IsAdmin = isAdmin;
    }
}