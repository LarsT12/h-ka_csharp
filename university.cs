using System;
using System.Collections.Generic;

class Program {
  static void Main(string[] args) {
    University university = new University("H-KA");

    // Erstelle Gebäude, Räume, Klassen usw. ...
    Building building1 = university.AddBuilding(new Building { Name = "E" });
    Room firstRoom = building1.AddRoom(floor: 1, number: 101, seats: 25);
    Room secondRoom = building1.AddRoom(floor: 1, number: 102, seats: 35);
    building1.AddRoom(floor: 1, number: 103, seats: 32);

    Building building2 = university.AddBuilding(new Building { Name = "M" });
    building2.AddRoom(floor: 1, number: 101, seats: 30);
    building2.AddRoom(floor: 1, number: 102, seats: 32);
    building2.AddRoom(floor: 1, number: 103, seats: 28);

    // Beispielhafte Erstellung von Lehrern
    Teacher mueller = university.AddTeacher(new Teacher { Name = "Mueller" });
    Teacher maier = university.AddTeacher(new Teacher { Name = "Schulze" });

    // Beispielhafte Erstellung von Klassen
    Klass mathKlass = university.AddKlass(new Klass { Name = "Math", NumberOfStudents = 25 });
    Klass infKlass = university.AddKlass(new Klass { Name = "Inf", NumberOfStudents = 30 });

    // Beispielhafte Zuordnung von Veranstaltungen in den Belegungsplan
    university.Schedule.AddEvent(DayOfWeek.Monday, slot: 2, room: firstRoom, klass: mathKlass, teacher: mueller);
    university.Schedule.AddEvent(DayOfWeek.Friday, slot: 0, room: firstRoom, klass: infKlass, teacher: maier);
    university.Schedule.AddEvent(DayOfWeek.Friday, slot: 0, room: secondRoom, klass: mathKlass, teacher: mueller);

    Console.WriteLine(university); // Gibt eine Zusammenfassung der Universität aus

    // Ausgabe des Belegungsplans in eine Textdatei
    System.IO.File.WriteAllText(@"Schedule.txt", university.Schedule.ToString());
  }
}


class University {
  public string Name { get; }
  public List<Building> Buildings { get; set; } = new List<Building>();
  public List<Klass> Klasses { get; set; } = new List<Klass>();
  public List<Teacher> Teachers { get; set; } = new List<Teacher>();
  public Schedule Schedule { get; set; } = new Schedule();

  public Building AddBuilding(Building newBuilding) {
    Buildings.Add(newBuilding);
    return newBuilding;
  }

  public Klass AddKlass(Klass newKlass) {
    Klasses.Add(newKlass);
    return newKlass;
  }

  public Teacher AddTeacher(Teacher newTeacher) {
    Teachers.Add(newTeacher);
    return newTeacher;
  }

  public University(string name) {
    Name = name;
  }

  public override string ToString() {
    return $"University {Name} with {Buildings.Count} buildings and {Klasses.Count} classes";
  }
}

class Building {
  public string Name { get; set; }
  public List<Room> Rooms { get; set; } = new List<Room>();

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
  public int Floor { get; set; }
  public int Number { get; set; }
  public int Seats { get; set; }

  public override string ToString() {
    return $"Room Floor {Floor}, Number {Number}, Seats {Seats}";
  }
}

class Klass {
  public string Name { get; set; }
  public int NumberOfStudents { get; set; }

  public override string ToString() {
      return $"Klass {Name}";
  }
}

class Teacher {
  public string Name { get; set; }
  
  public override string ToString() {
    return $"Teacher {Name}";
  }
}

class Schedule {
  public Dictionary<DayOfWeek, List<TimeSlot>> WeeklySchedule { get; set; } = new Dictionary<DayOfWeek, List<TimeSlot>>();

  public Schedule() {
    init();
  }

  private void init() {
    for(int wd = (int)DayOfWeek.Monday; wd < (int)DayOfWeek.Saturday; wd++) {
      WeeklySchedule.Add((DayOfWeek)wd, new List<TimeSlot> {
        new TimeSlot { Slot = "Morning I" },
        new TimeSlot { Slot = "Morning II" },
        new TimeSlot { Slot = "Afternoon I" },
        new TimeSlot { Slot = "Afternoon II" },
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

class TimeSlot {
  public string Slot { get; set; }
  public List<Event> Events { get; set; } = new List<Event>();

  public override string ToString() {
    return $"TimeSlot {Slot}, {Events.Count} events";
  }
}

class Event {
  public Room Room { get; set; }
  public Klass Klass { get; set; }
  public Teacher Teacher { get; set; }

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
