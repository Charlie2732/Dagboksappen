# Dagboksappen
En enkel konsolapplikation i C# där användaren kan skriva dagboksanteckningar, lista dem, söka på datum samt spara och läsa från fil (JSON).
FUNKTIONER
Skriv ny anteckning (titel + text)
Lista alla anteckningar
Sök anteckning på datum (yyyy-MM-dd)
Spara till JSON-fil
Läs från JSON-fil
Inputvalidering (titel/text kan inte vara tomma, datumformat kontrolleras)
REFLEKTION
Jag valde att lagra anteckningar i en List, eftersom den är enkel och flexibel att arbeta med.
För filhantering används JSON via System.Text.Json, vilket gör sparad data både lättläst och lätt att deserialisera.
Lade till input-validering, dokumentation, release v1.0.0. i README
