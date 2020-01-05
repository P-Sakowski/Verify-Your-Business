using System;
using System.Collections.Generic;
using System.Text;

namespace Verify_Your_Business_Library
{
    public class TaxPayerFormFields
    {
        public string name { get; }
        public string nip { get; }
        public string statusVat { get; }
        public string regon { get; }
        public string pesel { get; }
        public string krs { get; }
        public string residenceAddress { get; }
        public string workingAddress { get; }
        public string representatives { get; }
        public string authorizedClerks { get; }
        public string partners { get; }
        public string accountNumbers { get; }
        public string registrationLegalDate { get; }
        // public string registrationDenialBasis { get; }
        public string registrationDenialDate { get; }
        // public string restorationBasis { get; }
        public string restorationDate { get; }
        public string removalBasis { get; }
        // public string removalDate { get; }

        public TaxPayerFormFields()
        {
            name = "Firma (nazwa) lub imię i nazwisko";
            nip = "Numer, za pomocą którego podmiot został zidentyfikowany na potrzeby podatku, jeżeli taki numer został przyznany";
            statusVat = "Status podatnika (wg stanu na dzień sprawdzenia)";
            regon = "Numer identyfikacyjny REGON, o ile został nadany";
            pesel = "Numer PESEL, o ile podmiot posiada:";
            krs = "Numer w Krajowym Rejestrze Sądowym, o ile został nadany:";
            residenceAddress = "Adres siedziby – w przypadku podmiotu niebędącego osobą fizyczną:";
            workingAddress = "Adres stałego miejsca prowadzenia działalności albo adres miejsca zamieszkania, w przypadku braku adresu stałego miejsca prowadzenia działalności - w odniesieniu do osoby fizycznej:";
            representatives = "Imiona i nazwiska prokurentów oraz ich numery identyfikacji podatkowej lub numery PESEL:";
            authorizedClerks = "Imiona i nazwiska osób wchodzących w skład organu uprawnionego do reprezentowania podmiotu oraz ich numery identyfikacji podatkowej lub numery PESEL:";
            partners = "Imię i nazwisko lub firma (nazwa) wspólnika oraz jego numer identyfikacji podatkowej lub numer PESEL:";
            accountNumbers = "Numery rachunków rozliczeniowych lub imiennych rachunków w SKOK:";
            registrationLegalDate = "Data rejestracji jako podatnika VAT:";
            // registrationDenialBasis = ": " + registrationDenialBasis;
            registrationDenialDate = "Data odmowy rejestracji jako podatnika VAT Podstawa prawna odmowy rejestracji:";
            // restorationBasis = ": " + restorationBasis;
            restorationDate = "Data przywrócenia rejestracji jako podatnika VAT Podstawa prawna przywrócenia:";
            removalBasis = "Data wykreślenia rejestracji jako podatnika VAT Podstawa prawna wykreślenia:";
            // removalDate = ": " + removalDate;
        }
    }
}
