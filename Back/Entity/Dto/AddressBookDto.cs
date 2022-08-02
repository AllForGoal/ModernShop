using System;

namespace Entity.Dto
{
    public class AddressBookDto
    {
        public Guid Id { get; set; }
         public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string Photo1 { get; set; }
    
    }
     public class AddAddressBookDto
    {
         public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
    }
     public class UpdateAddressBookDto
    {
        public Guid Id { get; set; }
         public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
    }
}