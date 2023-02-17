int sensorIndice = 0;
int sensorCorazon = 1;
int sensorAnular = 2;
//const int sensorIndice = 4;
//int sensorCorazon = 33;
//const int sensorAnular = 14;
int lecturaIndice;
int lecturaCorazon;
int lecturaAnular;
int flexionIndice;
int flexionCorazon;
int flexionAnular;
String enviado;
//char separador = '|';
int enteroEnviado;

void setup() 
{
  pinMode(sensorIndice, INPUT);
  pinMode(sensorCorazon, INPUT);
  pinMode(sensorAnular, INPUT);
  //analogReference();
  Serial.begin(115200);
  //analogReadResolution(11);
}

void loop() 
{
  lecturaIndice = analogRead(sensorIndice);
  lecturaCorazon = analogRead(sensorCorazon);
  lecturaAnular = analogRead(sensorAnular);

  flexionIndice = map(lecturaIndice, 968, 1010, 0, 180);
  flexionCorazon = map(lecturaCorazon,  970, 1012, 0, 180);
  flexionAnular = map(lecturaAnular, 968, 1013, 0, 180); // 236 y 634 son numeros para hallar segun la conversion analoga

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
  //enviado += flexionIndice;
  //enviado += separador; 
  //enviado += flexionCorazon;
  //enviado += separador;
  //enviado += flexionAnular;
/*
  enviado += lecturaIndice;
  enviado += separador; 
  enviado += lecturaCorazon;
  enviado += separador;
  enviado += lecturaAnular;
  */
  Serial.println(enteroEnviado);
  //Serial.println(enviado);
  //enviado =  "";
  delay(300);
}