# Verify-Your-Business

Aplikacja "Verify Your Business" pozwala na określenie wiarygodności partnerów biznesowych poprzez sprawdzanie statusu podatnika VAT oraz ogólnodostępnych danych płatników VAT, a także umożliwia weryfikację numeru konta bankowego.

### Funkcje

- metoda „search”– aby z niej skorzystać, wybierz jeden z parametrów: NIP, REGON oraz dzień, na jaki mają być wyświetlone informacje o podmiocie
- cały zakres danych z wykazu o podmiotach, o które pytasz
- metodę uproszczoną „check”, która poprzez API skrócone będzie łączyła cię z wykazem po wprowadzeniu parametrów zapytania NIP LUB REGON
- Gernerowanie PDF oraz XML z informacjami o podmiocie

### Spis treści
* [Informacje ogólne](#verify-Your-Business)
* [Funkcje](#funkcje)
* [Instalacja](#instalacja)
* [Interfejs aplikacji](#interfejs)
* [Generowanie PDF](#pdf)
* [Generowanie XML](#xml)
* [Licencja](#licencja)
	
### Instalacja
Aby włączyć aplikacje uruchom i przejdź przez instalator `Verify-Your-Business-Installer.exe`, a następnie kliknij w ikonę ukazaną na pulpicie.

### Interfejs

Interfejs aplikacji pozwala w prosty sposób wprowadzić dane.
- W pierwszym polu wybierz `NIP`/`REGON`
- W drugim polu wpisz numer `NIP`/`REGON` w zależności pierwszego pola
- W trzecim polu wybierz właściwą datę. Po kliknięciu w pole pojawi się kalendarz
- Na koniec kliknij przycisk `Szukaj` 

#### Interfejs aplikacji

![alt text](resources/main-window.png)

#### Prezentowanie informacji o podatniku po prawidłowym wyszukaniu

![alt text](resources/mian-window-da.png)

### PDF

Funkcja umożliwająca wygenerowanie PDF. <br>
Gdy dane zostaną zaprezentowane w interfejsie aplikacji, kliknij `Zapisz rezultat do pliku PDF`. Utworzony plik `PDF` Zostanie zapisany w katalogu aplikacji. 

![alt text](resources/pdf.png)

### XML

Funkcja umożliwająca wygenerowanie XML. <br>
Gdy dane zostaną zaprezentowane w interfejsie aplikacji, kliknij `Zapisz rezultat do pliku XML`. Utworzony plik `XML` Zostanie zapisany w katalogu aplikacji. 

![alt text](resources/xml.png)

## Twórcy

- Przemysław Sakowski

- Maksymilian Stępak

- Szymon Ryczek

## Licencja

Projekt jest objęty licencją MIT - szczegóły w pliku LICENCE
