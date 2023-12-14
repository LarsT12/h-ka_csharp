using System;
using System.Collections.Generic;

class Program {
  static void Main(string[] args) {
    University university = new University("H-KA");
    University kit = new University("KIT", "Keine Ahnung");

    // Erstelle Gebäude, Räume, Klassen usw. ...
    Building building1 = university.AddBuilding("E");
    Room firstRoom = building1.AddRoom(1, 101, 30);
    Room secondRoom = building1.AddRoom(floor: 1, number: 102, seats: 35);
    building1.AddRoom(floor: 1, number: 103, seats: 32);

    Building building2 = university.AddBuilding("M");
    building2.AddRoom(floor: 1, number: 101, seats: 30);
    building2.AddRoom(floor: 1, number: 102, seats: 32);
    building2.AddRoom(floor: 1, number: 103, seats: 28);

    // Beispielhafte Erstellung von Lehrern
    Teacher mueller = university.AddTeacher(new Teacher { Name = "Mueller" });
    Teacher schulze = university.AddTeacher(new Teacher { Name = "Schulze" });

    // Beispielhafte Erstellung von Klassen
    Klass mathKlass = university.AddKlass(new Klass { Name = "Math", NumberOfStudents = 25 });
    Klass infKlass = university.AddKlass(new Klass { Name = "Inf", NumberOfStudents = 29 });

    // Beispielhafte Zuordnung von Veranstaltungen in den Belegungsplan
    university.Schedule.AddEvent(DayOfWeek.Monday, slot: 2, room: firstRoom, klass: mathKlass, teacher: mueller);
    university.Schedule.AddEvent(DayOfWeek.Friday, slot: 0, room: firstRoom, klass: infKlass, teacher: schulze);
    university.Schedule.AddEvent(DayOfWeek.Friday, slot: 0, room: secondRoom, klass: mathKlass, teacher: mueller);

    Console.WriteLine(university); // Gibt eine Zusammenfassung der Universität aus

    // Ausgabe des Belegungsplans in eine Textdatei
    System.IO.File.WriteAllText(@"Schedule.txt", university.Schedule.ToString());

    // Beispiele Zugriff auf getter und setter bzw. auf die Properties von Objekten

    kit.setAdresse("Hauptstraße 1");
    Console.WriteLine(kit.getAdresse());
    string erstadresse = kit.getAdresse();
    Console.WriteLine(erstadresse);

    string n = kit.Name;
    kit.Name = "Schlossplatz 1";

    string ort = "KA";
    if(ort == "KA") {
      kit.Name = "wert 1";
    } else {
      kit.Name = "wert 2";
    }
    kit.Name = ort == "KA" ? "wert 1" : "wert 2";
    Console.WriteLine(kit.Name);

    University mu = new University("Meine Uni");
    Console.WriteLine(mu.Name);

  }
}


class University {
  private string _Name;
  public string Name {
    get {
      return _Name;
    }
    set {
      if(value != null && value.Length > 2 && value.Length < 100) {
        _Name = value;
      } else {
        throw new Exception("Ungültiger Name");
      }
    }
  }

  private string adresse;
  public string getAdresse() {
    return adresse;
  }
  
  public void setAdresse(string value) {
    if(value != null && value.Length > 10 && value.Length < 100) {
      adresse = value;
    } else {
      throw new Exception("Ungültige Adresse");
    }
  }

  public List<Building> Buildings { get; } = new List<Building>();
  public List<Klass> Klasses { get; } = new List<Klass>();
  public List<Teacher> Teachers { get; } = new List<Teacher>();
  public Schedule Schedule { get; } = new Schedule();

  public Building AddBuilding(string name) {
    Building b = new Building(name);
    Buildings.Add(b);
    return b;
  }

  public Klass AddKlass(Klass newKlass) {
    Klasses.Add(newKlass);
    return newKlass;
  }

  public Teacher AddTeacher(Teacher newTeacher) {
    Teachers.Add(newTeacher);
    return newTeacher;
  }

  public University(string n) {
    Name = n;
  }
  public University(string name, string adresse) {
    Name = name;
    this.adresse = adresse;
  }

  public override string ToString() {
    return $"University {Name} with {Buildings.Count} buildings and {Klasses.Count} classes";
  }
}

class Building {
  public string Name;
  public List<Room> Rooms = new List<Room>();

  public Building(string name) {
    Name = name;
  }

  public override string ToString() {
    return $"Building {Name}, {Rooms.Count} rooms";
  }

  public Room AddRoom(int floor, int number, int seats) {
    Room newRoom = new Room { Floor = floor, Number = number, Seats = seats };
    Rooms.Add(newRoom);
    return newRoom;
  }
}

class Room {
  public int Floor;
  public int Number;
  public int Seats;

  public override string ToString() {
    return $"Room Floor {Floor}, Number {Number}, Seats {Seats}";
  }
}

class Klass {
  public string Name;
  public int NumberOfStudents;

  public override string ToString() {
    return $"Klass {Name}";
  }
}

class Teacher {
  public string Name;
  
  public override string ToString() {
    return $"Teacher {Name}";
  }
}

class Schedule {
  private Dictionary<DayOfWeek, List<TimeSlot>> WeeklySchedule = new Dictionary<DayOfWeek, List<TimeSlot>>();

  public Schedule() {
    init();
  }

  private void init() {
    for(int wd = (int)DayOfWeek.Monday; wd < (int)DayOfWeek.Saturday; wd++) {
      WeeklySchedule.Add((DayOfWeek)wd, new List<TimeSlot> {
        new TimeSlot { Slot = SlotType.MorningI },
        new TimeSlot { Slot = SlotType.MorningII },
        new TimeSlot { Slot = SlotType.AfternoonI },
        new TimeSlot { Slot = SlotType.AfternoonII },
      });
    }
  }

  public void AddEvent(DayOfWeek dayOfWeek, int slot, Room room, Klass klass, Teacher teacher) {
    try {
      Event ev = new Event(room, klass, teacher);
      WeeklySchedule[dayOfWeek][slot].Events.Add(ev);
    } catch(Exception e) {
      Console.WriteLine($"Fehler beim Versuch für {dayOfWeek} im Slot {slot} für \n  - {room}\n  - {klass}\n  - {teacher}\n  einen Termin einzutragen:\n    {e.Message}");
    }
  }


  public override string ToString() {
    // Logik zur Textgenerierung für den Belegungsplan
    string scheduleText = "";
    foreach(var day in WeeklySchedule) {
      scheduleText += $"{day.Key}:\n";
      foreach(var timeSlot in day.Value) {
        scheduleText += $"\t{timeSlot.Slot}:";
        foreach(var ev in timeSlot.Events) {
          scheduleText += $"\n\t\t{ev}";
        }
        scheduleText += "\n";
      }
      scheduleText += "\n";
    }
    return scheduleText;
  }
}

public enum SlotType {
  MorningI,
  MorningII,
  AfternoonI,
  AfternoonII
}

class TimeSlot {
  public SlotType Slot;
  public List<Event> Events = new List<Event>();

  public override string ToString() {
    return $"TimeSlot {Slot}, {Events.Count} events";
  }
}

class Event {
  public Room Room;
  public Klass Klass;
  public Teacher Teacher;

  public Event(Room room, Klass klass, Teacher teacher) {
    if(room.Seats < klass.NumberOfStudents) {
      throw new Exception($"It is not possible to plan an event with {klass.NumberOfStudents} students in a room with only {room.Seats} seats.");
    }
    Room = room;
    Klass = klass;
    Teacher = teacher;
  }

  public override string ToString() {
    return $"Event Class {Klass?.Name} with teacher {Teacher?.Name} in room {Room?.Number}";
  }
}
