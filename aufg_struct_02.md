# Aufg. Kinosaal

In dieser Aufgabe entwickelst du schrittweise ein `struct`, mit dem Sitzplätze in einem Kinosaal beschrieben werden können. Danach verwendest du ein zweidimensionales Array, um daraus einen ganzen Kinosaal aufzubauen.

Wichtig: Ein zweidimensionales Array hat bereits zwei Indizes, z.B. `saal[reihe, platz]`. Deshalb soll der einzelne Sitzplatz seine Position nicht zwingend selbst speichern. Die Position ergibt sich aus dem Array. Der Sitzplatz speichert vor allem seinen Zustand, z.B. ob er reserviert ist.

## Teil 1: Einen Sitzplatz beschreiben

Überlege zuerst selbst:

- Welche Eigenschaften kann ein Sitzplatz im Kino haben?
- Welche dieser Eigenschaften sollen sich später ändern können?
- Welche Eigenschaften bleiben nach dem Erstellen eher gleich?
- Welche Informationen braucht man, um einen Sitzplatz sinnvoll auszugeben?

Erstelle danach ein `struct` `Sitzplatz`.

Der Sitzplatz soll private Felder haben. In vielen Beispielen und Teams beginnen private Felder mit einem Unterstrich, z.B. `_kategorie`. Das ist keine Regel des Compilers, sondern eine Namenskonvention. Der Compiler verlangt den Unterstrich nicht.

Überlege:

- Welche Werte sind für jeden Sitzplatz zwingend nötig?
- Welche Werte sollen nach dem Erstellen eher gleich bleiben?
- Welche Werte ändern sich erst später durch Aktionen?

Zwingende und weitgehend unveränderliche Werte sollten direkt über den Konstruktor gesetzt werden. Ein Konstruktor hat denselben Namen wie das `struct` und keinen Rückgabetyp:

```csharp
public Sitzplatz(...) {
  ...
}
```

Erstelle außerdem eine passende `ToString()`-Methode.

Teste dein `struct` zunächst nur mit einem einzelnen Sitzplatz.

Wenn du nicht weiterkommst oder deinen Stand vergleichen möchtest, nutze die Musterlösung:

`aufg_struct_02_Teil_01.cs`

## Teil 2: Verhalten ergänzen

Überlege wieder zuerst selbst:

- Was kann man mit einem Sitzplatz tun?
- Was darf nicht passieren?
- Welche Prüfungen sollten Methoden durchführen?

Ergänze Methoden für das veränderliche Verhalten des Sitzplatzes.

- `Reservieren(string name)`
- `Freigeben()`

Dabei soll gelten:

- Ein bereits reservierter Sitzplatz darf nicht erneut reserviert werden.
- Ein freier Sitzplatz darf nicht freigegeben werden.
- Der Name für eine Reservierung darf nicht leer sein.

Teste das Verhalten mit zwei Sitzplätzen.

Wenn du nicht weiterkommst oder deinen Stand vergleichen möchtest, nutze die Musterlösung:

`aufg_struct_02_Teil_02.cs`

## Teil 3: Einen Kinosaal als zweidimensionales Array erstellen

Jetzt soll ein ganzer Kinosaal erstellt werden.

Erstelle ein zweidimensionales Array:

```csharp
Sitzplatz[,] saal = new Sitzplatz[5, 8];
```

Das bedeutet:

- 5 Reihen
- 8 Plätze pro Reihe

Initialisiere alle Plätze mit verschachtelten Schleifen.

Mögliche Idee:

- Reihen 1 bis 3: `"Standard"`, 900 Cent, ohne Getränkehalter
- Reihe 4: `"Komfort"`, 1200 Cent, mit Getränkehalter
- Reihe 5: `"Loge"`, 1500 Cent, mit Getränkehalter

Reserviere danach einzelne Plätze, z.B.:

```csharp
saal[0, 3].Reservieren("Mina");
saal[2, 5].Reservieren("Jonas");
saal[4, 1].Reservieren("Samira");
```

Gib anschließend den ganzen Saal aus. Verwende dabei die Array-Indizes, um Reihe und Platz anzuzeigen.

Hinweis: Für Menschen beginnt die Zählung meist bei 1, Arrays beginnen aber bei 0.

Beispiel:

```csharp
Console.WriteLine($"Reihe {reihe + 1}, Platz {platz + 1}: {saal[reihe, platz]}");
```

Wenn du nicht weiterkommst oder deinen Stand vergleichen möchtest, nutze die Musterlösung:

`aufg_struct_02_Teil_03.cs`

## Teil 4: Auswertungen und Varianten

Erweitere dein Programm um mindestens zwei Auswertungen:

- Wie viele Plätze sind frei?
- Wie viele Plätze sind reserviert?
- Wie viel Geld bringen die reservierten Plätze zusammen?
- Welche Plätze einer bestimmten Kategorie sind noch frei?

Da die Felder des `struct` privat sind, kannst du sie nicht direkt außerhalb des `struct` lesen. Für Auswertungen kannst du deshalb kleine Abfrage-Methoden ergänzen, z.B. `IstReserviert()`, `IstFrei()`, `PreisInCent()` oder `HatKategorie(string kategorie)`.

Probiere außerdem mindestens eine Variante aus:

### Variante A: Rechteckiges zweidimensionales Array

Das ist die Variante aus Teil 3:

```csharp
Sitzplatz[,] saal = new Sitzplatz[5, 8];
```

Sie passt gut, wenn jede Reihe gleich viele Plätze hat.

### Variante B: Gezacktes Array

Ein gezacktes Array ist ein Array von Arrays:

```csharp
Sitzplatz[][] saal = new Sitzplatz[5][];
saal[0] = new Sitzplatz[6];
saal[1] = new Sitzplatz[8];
saal[2] = new Sitzplatz[8];
saal[3] = new Sitzplatz[10];
saal[4] = new Sitzplatz[10];
```

Diese Variante passt gut, wenn nicht jede Reihe gleich viele Plätze hat.

Für diese Aufgabe reicht Variante A. Variante B ist ein Zusatz, wenn du ausprobieren möchtest, wie sich die Schleifen ändern.

Wenn du nicht weiterkommst oder deinen Stand vergleichen möchtest, nutze die Musterlösung:

`aufg_struct_02_Teil_04.cs`

## Teil 5: Einen Kinosaal beschreiben

Bisher haben wir den Kinosaal über ein zweidimensionales Array abgebildet.
Eigenschaften und Verhalten des ganzen Saals, wie z.B. die Anzahl an freien Plätzen, wurden in Teil 4 über statische Methode bereitgestellt.

Erstelle nun eine ```struct Saal``` mit folgendem:
- Sie soll unser zweidimensionales Array der Plätze enhalten. Nenne die bisherige Variable ```saal```entspr. in ```plätze```um und lass sie Teil der Struct *saal* werden.
- Sie soll mit Hilfe des Konstruktors das Initialisieren des Saals durchführen, siehe Methode ```InitialisiereSaal()```.
- Die bisherigen Methoden, die ein Sitzplatz bereitstellt, wie z.B. das Reservieren, müssen so umgestaltet sein, über die Struct Saal erreichbar sind und dass sie die Position des Sitzplatzes als Parameter mitgeben.
- Sie soll die in Teil 4 erstellten statischen Methoden, die uns Eigenschaften des Saals liefern, implementieren.

Erstelle mind. einen Saal, gerne auch ein Array ```Saal[]```, um gleich mehrere zu erstellen.

Wenn du nicht weiterkommst oder deinen Stand vergleichen möchtest, nutze die Musterlösung:

`aufg_struct_02_Teil_05.cs`
