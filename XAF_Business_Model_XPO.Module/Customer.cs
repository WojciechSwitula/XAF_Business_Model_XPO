using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;

namespace SimpleProjectManager.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Customer : BaseObject
    {
        public Customer(Session session) : base(session) { }

        string customerName;
        public string CustomerName
        {
            get { return customerName; }
            set { SetPropertyValue(nameof(CustomerName), ref customerName, value); }
        }
        string vatNumber;
        public string VatNumber
        {
            get { return vatNumber; }
            set { SetPropertyValue(nameof(VatNumber), ref vatNumber, value); }
        }
        string street;
        public string Street
        {
            get { return street; }
            set { SetPropertyValue(nameof(Street), ref street, value); }
        }
        string city;
        public string City
        {
            get { return city; }
            set { SetPropertyValue(nameof(City), ref city, value); }
        }
        string postalCode;
        public string PostalCode
        {
            get { return postalCode; }
            set { SetPropertyValue(nameof(PostalCode), ref postalCode, value); }
        }
        string phone;
        public string Phone
        {
            get { return phone; }
            set { SetPropertyValue(nameof(Phone), ref phone, value); }
        }
        string regon;
        public string Regon
        {
            get { return regon; }
            set { SetPropertyValue(nameof(Regon), ref regon, value); }
        }
        string numberInRegisterOfRecords;
        public string NumberInRegisterOfRecords
        {
            get { return numberInRegisterOfRecords; }
            set { SetPropertyValue(nameof(NumberInRegisterOfRecords), ref numberInRegisterOfRecords, value); }
        }
        string email;
        public string Email
        {
            get { return email; }
            set { SetPropertyValue(nameof(Email), ref email, value); }
        }



    }

}