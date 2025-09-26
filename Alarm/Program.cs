AlarmDelegate alarmDelegate = new AlarmDelegate(dummy);

Timer timer = new Timer(TimerAf);
int sec = 10;
int sluimertijd = 5;

char keuze = ' ';

do {
    Console.WriteLine("Wekker");
    Console.Write("A: Stel de manier waarop je wekker afloopt\n");
    Console.Write("B: Stel de sluimertijd\n");
    Console.Write("C: Stel de tijd in waarop het alarm moet afgaan\n");
    Console.Write("S: Stop de wekker\n");
    Console.Write("Maak jou keuze: ");
    keuze = (char)Console.Read();
    Console.ReadLine();

    switch (keuze) {
        case 'A':
        case 'a':
            Console.WriteLine(" Kies uit de volgende alarmacties:");
            Console.WriteLine("A: Toon bericht:");
            Console.WriteLine("B: Speel een geluidssignaal");
            Console.WriteLine("C: Laat de lampen flitsen");
            Console.Write("Maak je keuze (hoofdletter = starten, kleine letter = stoppen): ");
            char alarmkeuze = (char)Console.Read();
            Console.ReadLine();
            Console.WriteLine();

            switch (alarmkeuze)
            {
                case 'a':
                case 'A':
                    alarmDelegate += new AlarmDelegate(ToonBericht);
                    break;

                case 'b':
                case 'B':
                    alarmDelegate += new AlarmDelegate(SpeelGeluid);
                    break;

                case 'c':
                case 'C':
                    alarmDelegate += new AlarmDelegate(FlitsLampen);
                    break;

                default:
                    Console.WriteLine("Ongeldige keuze, probeer opnieuw.");
                    break;
            }
            
            break;
        case 'B':
        case 'b':
            Console.Write("Wanneer moet de wekker herhalen? ");
            sluimertijd = int.Parse(Console.ReadLine() ?? "0");

            timer.Change(sec * 1000, sluimertijd * 1000);

            break;
        case 'C':
        case 'c':
            Console.Write("Over hoeveel seconden moet de wekker afgaan? ");
            sec = int.Parse(Console.ReadLine() ?? "0");

            timer.Change(sec * 1000, sluimertijd * 1000);
            break;

        default:
            Console.WriteLine("Ongeldige keuze, probeer opnieuw.");
            break;
    }



} while (keuze != 'S' || keuze != 'S');

void dummy() {
    
}

void TimerAf(object? state)
{
    alarmDelegate();
}

void ToonBericht()
{
    Console.WriteLine();
    Console.WriteLine(">>> HET MOMENT IS DAAR <<<");
    Console.WriteLine();
}

void SpeelGeluid()
{
    Console.Beep();
}

void FlitsLampen()
{
    for (int i = 0; i < 3; i++) 
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("~ *** DE LAMPEN KNIPPEREN HEEN EN WEER *** ~");
        Console.WriteLine();
        Thread.Sleep(200); 

        Console.Clear();
        Thread.Sleep(200); 
    }
}


delegate void AlarmDelegate();

