#include <LiquidCrystal.h>
LiquidCrystal lcd(12, 11, 5, 4, 3, 2);

char message[16] = "";
long duree = 60 * 60;
bool buzzed = false;
long secondesRestantes = duree;
bool start = false;
long startedAt = 0;
int nbBascule = 0;
int derniereBascule = HIGH;

void(* resetFunc) (void) = 0;

void setup()
{
  pinMode(6, OUTPUT); //led rouge
  pinMode(10, OUTPUT); //buzzer
  pinMode(8, INPUT); //interrupteur levier
  digitalWrite(8, HIGH);
  
  lcd.begin(16, 2);
  lcd.display();
}

void loop()
{
  lcd.clear();
  
  if (derniereBascule != digitalRead(8))
  {
    nbBascule++;
    derniereBascule = digitalRead(8);

    if (nbBascule > 10 && millis() < 5000)
      resetFunc();
  }
  

  if (!start)
  {
    if (digitalRead(8) == LOW)
    {
      start = true;
      startedAt = millis() / 1000;
    }
    return;
  }
  
  secondesRestantes = duree - (millis() / 1000) + startedAt;
  
  if (secondesRestantes > 0)
  {
    long minutes = secondesRestantes / 60;
    long secondes = secondesRestantes - (minutes * 60);

    sprintf(message, "%02" PRId32 ":%02d",minutes,secondes);
  }
  else
  {
    if (!buzzed)
    {
      tone (10, 400, 1000);
      buzzed = true;
    }
    digitalWrite(6, LOW);
    sprintf(message, "Trop tard...");
  }

  lcd.print(message);
  delay(100);
}
