using System;
using System.Collections.Generic;
using System.Text;

namespace Verify_Your_Business_Library
{
    public class TaxPayerFormFields
    {
        public string Name { get; }
        public string Nip { get; }
        public string StatusVat { get; }
        public string Regon { get; }
        public string Pesel { get; }
        public string Krs { get; }
        public string ResidenceAddress { get; }
        public string WorkingAddress { get; }
        public string Representatives { get; }
        public string AuthorizedClerks { get; }
        public string Partners { get; }
        public string AccountNumbers { get; }
        public string RegistrationLegalDate { get; }
        // public string registrationDenialBasis { get; }
        public string RegistrationDenialDate { get; }
        // public string restorationBasis { get; }
        public string RestorationDate { get; }
        public string RemovalBasis { get; }
        // public string removalDate { get; }

        public TaxPayerFormFields()
        {
            Name = "Firma (nazwa) lub imię i nazwisko";
            Nip = "Numer, za pomocą którego podmiot został zidentyfikowany na potrzeby podatku, jeżeli taki numer został przyznany";
            StatusVat = "Status podatnika (wg stanu na dzień sprawdzenia)";
            Regon = "Numer identyfikacyjny REGON, o ile został nadany";
            Pesel = "Numer PESEL, o ile podmiot posiada";
            Krs = "Numer w Krajowym Rejestrze Sądowym, o ile został nadany";
            ResidenceAddress = "Adres siedziby – w przypadku podmiotu niebędącego osobą fizyczną";
            WorkingAddress = "Adres stałego miejsca prowadzenia działalności albo adres miejsca zamieszkania, w przypadku braku adresu stałego miejsca prowadzenia działalności - w odniesieniu do osoby fizycznej";
            Representatives = "Imiona i nazwiska prokurentów oraz ich numery identyfikacji podatkowej lub numery PESEL";
            AuthorizedClerks = "Imiona i nazwiska osób wchodzących w skład organu uprawnionego do reprezentowania podmiotu oraz ich numery identyfikacji podatkowej lub numery PESEL";
            Partners = "Imię i nazwisko lub firma (nazwa) wspólnika oraz jego numer identyfikacji podatkowej lub numer PESEL";
            AccountNumbers = "Numery rachunków rozliczeniowych lub imiennych rachunków w SKOK";
            RegistrationLegalDate = "Data rejestracji jako podatnika VAT";
            // registrationDenialBasis = ": " + registrationDenialBasis;
            RegistrationDenialDate = "Data odmowy rejestracji jako podatnika VAT Podstawa prawna odmowy rejestracji";
            // restorationBasis = ": " + restorationBasis;
            RestorationDate = "Data przywrócenia rejestracji jako podatnika VAT Podstawa prawna przywrócenia";
            RemovalBasis = "Data wykreślenia rejestracji jako podatnika VAT Podstawa prawna wykreślenia";
            // removalDate = ": " + removalDate;
        }
    }
}
