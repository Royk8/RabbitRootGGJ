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
int enteroEnviado;

void setup() 
{
  pinMode(sensorIndice, INPUT);
  pinMode(sensorCorazon, INPUT);
  pinMode(sensorAnular, INPUT);
  analogReference(DEFAULT);
  Serial.begin(115200);
}

void loop() 
{
  lecturaIndice = analogRead(sensorIndice);
  lecturaCorazon = analogRead(sensorCorazon);
  lecturaAnular = analogRead(sensorAnular);
  
  flexionIndice = map(lecturaIndice, 968, 1015, 0, 180);
  flexionCorazon = map(lecturaCorazon,  970, 1016, 0, 180);
  flexionAnular = map(lecturaAnular,  950, 1023, 0, 180); // 236 y 634 son numeros para hallar segun la conversion analoga
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

  int datoIndice = (int) round(flexionIndice*9/180);
  int datoCorazon = (int) round(flexionCorazon*9/180);
  int datoAnular = (int) round(flexionAnular*9/180);

  enteroEnviado = (datoIndice*100)+(datoCorazon*10)+(datoAnular);

  enviado += flexionIndice;
  enviado += separador; 
  enviado += flexionCorazon;
  enviado += separador;
  enviado += datoAnular;

  Serial.println(enteroEnviado);
  //enviado =  "";
  delay(500);
}