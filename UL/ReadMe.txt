Projekat je konzolna aplikacija, koja lici na neki CLI.
Konvencija imenovanja:
Strategije:
	strategija[Naziv].xml
Predmeti:
	predmet[Naziv].xml
Studenti:
	Svejedno

Program flow:
	Ucitava se xml sa studentima (korisnik bira koji zeli od dostupnih,
				     (tj onih prisutnih u bin/Debug)
	Studenti povlace podatke o predmetima, a predmeti o strategijama.
	Prilikom ocenjivanja, moze se ocenjivati default strategijama za predmet, 
	ili zamenite strategiju za sve predmete.
	Upis ocena studenata se upisuje u xml fajl ocene.xml