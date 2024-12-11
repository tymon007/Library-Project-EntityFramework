# Aplikacja konsolowa symulująca system biblioteki
Prosty projekt przy pomocy którego zaznajomiłem się z podstawami obsługi EntityFramework przy użyciu Database First Approach.

## Baza danych
Projekt zawiera 2 Tabele:
### Books:
- BookID
- BookTitle
- BookContent
- PublishedDate
- AuthorID

### Authors:
- AuthorID
- AuthorName
- AuthorSurname

Rozwiązanie łączy się z bazą danych MSSQL na maszynie lokalnej przy pomocy komponentu ADO.NET.

## Funkcjonalności
- Wprowadzanie autorów
- Wprowadzanie książek
- Wyświetlanie listy autorów
- Wyświetlanie listy książek
- Wyświetlanie konkretnej książki
- Usuwanie autora
- Usuwanie książek
