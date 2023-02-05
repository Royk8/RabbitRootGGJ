int sensorIndice = 0;
int sensorCorazon = 1;
int sensorAnular = 2;
int lecturaIndice;
int lecturaCorazon;
int lecturaAnular;
int flexionIndice;
int flexionCorazon;
int flexionAnular;
String enviado;
char separador = '|';

void setup() 
{
  pinMode(sensorIndice, INPUT);
  pinMode(sensorCorazon, INPUT);
  pinMode(sensorAnular, INPUT);
  analogReference(DEFAULT);
  Serial.begin(9600);
}

void loop() 
{
  lecturaIndice = analogRead(sensorIndice);
  lecturaCorazon = analogRead(sensorCorazon);
  lecturaAnular = analogRead(sensorAnular);
  
  flexionIndice = map(lecturaIndice, 968, 1015, 0, 180);
  flexionCorazon = map(lecturaCorazon,  970, 1016, 0, 180);
  flexionAnular = map(lecturaAnular,  0, 1023, 0, 180); // 236 y 634 son numeros para hallar segun la conversion analoga
  //flexion_indice = flexion_indice + 7.0; // Numero para linealizar la conversion
  //flexion_corazon = flexion_corazon + 7.0; // Numero para linealizar la conversion
  //flexion_anular = flexion_anular + 7.0; // Numero para linealizar la conversio

  if(flexionIndice > 180)
  {
    flexionIndice = 180;
  }
  else if(flexionIndice < 0)
  {
    flexionIndice = 0;
  }

  if(flexionCorazon > 180)
  {
    flexionCorazon = 180;
  }
  else if(flexionCorazon < 0)
  {
    flexionCorazon = 0;
  }

  if(flexionAnular > 180)
  {
    flexionAnular = 180;
  }
  else if(flexionAnular < 0)
  {
    flexionAnular = 0;
  }

  enviado += flexionIndice;
  enviado += separador;
  enviado += flexionCorazon;
  enviado += separador;
  enviado += flexionAnular;

  Serial.println(enviado);
  enviado =  "";
/*
  Serial.print("Indice: ");
  Serial.print(lectura_indice); 
  Serial.print("  Corazon: "); 
  Serial.print(lectura_corazon); 
  Serial.print("  Anular: "); 
  Serial.print(lectura_anular);
  Serial.println();
*/
  delay(500);

  //Serial.print("Indice: ");
  //Serial.print(flexion_indice); 
  //Serial.print("  Corazon: "); 
  //Serial.print(flexion_corazon); 
  //Serial.print("  Anular: "); 
  //Serial.print(flexion_anular);
  //Serial.println();
  //delay(100);
}