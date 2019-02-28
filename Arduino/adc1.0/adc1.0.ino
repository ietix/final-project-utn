void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  int ADCValue;
  float volts;
  float current;

  ADCValue = analogRead(A0);
  volts = ADCValue * 5.0 / 1023.0;
  current = (volts - 2.5) * (300 / 0.625);
  Serial.println(volts, 3);
  //Serial.println(current, 1);
  delay(2);
}
